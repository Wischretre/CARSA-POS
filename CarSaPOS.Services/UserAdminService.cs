using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CarSaPOS.Data;
using CarSaPOS.Domain;

namespace CarSaPOS.Services
{
	// Every method here requires the Users.Manage permission. Passwords are hashed in C# with the same PasswordHasher used at login.
	public sealed class UserAdminService
	{
		private const string RequiredPermission = "Users.Manage";
		private const int MinPasswordLength = 8;

		private readonly UserAdminRepository _repo = new UserAdminRepository();

		public List<RoleRow> GetRoles()
		{
			Session.RequirePermission(RequiredPermission);
			return _repo.Roles();
		}

		public List<UserListRow> GetUsers()
		{
			Session.RequirePermission(RequiredPermission);
			return _repo.List();
		}

		public User GetUser(int userId)
		{
			Session.RequirePermission(RequiredPermission);
			return _repo.GetById(userId);
		}

		// Creates a user and returns the new user ID.
		public int CreateUser(string username, string fullName, UserRole role, string password, bool isActive)
		{
			Session.RequirePermission(RequiredPermission);

			username = (username ?? string.Empty).Trim();
			ValidateUsername(username);
			fullName = CleanFullName(fullName);
			ValidateRole(role);
			ValidatePassword(password);

			string salt = PasswordHasher.NewSalt();
			string hash = PasswordHasher.Hash(password, salt);

			return _repo.Insert(Session.CurrentUser.Id, username, hash, salt, fullName, (int)role, isActive);
		}

		// Changes name, role, and active status. Username and password are not changed here.
		public void UpdateUser(int userId, string fullName, UserRole role, bool isActive)
		{
			Session.RequirePermission(RequiredPermission);

			fullName = CleanFullName(fullName);
			ValidateRole(role);

			_repo.Update(Session.CurrentUser.Id, userId, fullName, (int)role, isActive);
		}

		public void ResetPassword(int userId, string newPassword)
		{
			Session.RequirePermission(RequiredPermission);
			ValidatePassword(newPassword);

			string salt = PasswordHasher.NewSalt();
			string hash = PasswordHasher.Hash(newPassword, salt);

			_repo.SetPassword(Session.CurrentUser.Id, userId, hash, salt);
		}

		// Audit entries from the start date through the end date, inclusive. Pass null to show every user.
		public List<AuditRow> GetAuditHistory(DateTime from, DateTime to, int? targetUserId)
		{
			Session.RequirePermission(RequiredPermission);

			if (to.Date < from.Date)
				throw new ArgumentException("The end date must be on or after the start date.");

			return _repo.Audit(from.Date, to.Date.AddDays(1), targetUserId);
		}

		private static void ValidateUsername(string username)
		{
			if (!Regex.IsMatch(username, "^[A-Za-z0-9._-]{3,50}$"))
				throw new ArgumentException("Username must be 3 to 50 letters, numbers, dots, underscores, or hyphens.");
		}

		private static string CleanFullName(string fullName)
		{
			string value = (fullName ?? string.Empty).Trim();
			if (value.Length == 0 || value.Length > 100)
				throw new ArgumentException("Full name is required and must be 100 characters or fewer.");
			return value;
		}

		private static void ValidateRole(UserRole role)
		{
			if (!Enum.IsDefined(typeof(UserRole), role))
				throw new ArgumentException("Choose a valid role.");
		}

		// The hasher uses ASCII bytes, so only plain characters are allowed in passwords.
		private static void ValidatePassword(string password)
		{
			if (string.IsNullOrEmpty(password) || password.Length < MinPasswordLength)
				throw new ArgumentException("Password must be at least " + MinPasswordLength + " characters.");

			foreach (char c in password)
			{
				if (c > 127)
					throw new ArgumentException("Password must use plain letters, numbers, and common symbols only.");
			}
		}
	}
}