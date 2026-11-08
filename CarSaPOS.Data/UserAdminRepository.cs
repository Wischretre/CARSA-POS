using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarSaPOS.Domain;

namespace CarSaPOS.Data
{
	// One row of the user list grid.
	public sealed class UserListRow
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string FullName { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public bool IsActive { get; set; }
		public DateTime? LastLoginAt { get; set; }
		public DateTime CreatedAt { get; set; }
	}

	// One row of the role dropdown.
	public sealed class RoleRow
	{
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public string Description { get; set; }
	}

	// One row of the audit history grid.
	public sealed class AuditRow
	{
		public int AuditId { get; set; }
		public DateTime OccurredAt { get; set; }
		public string ActorUsername { get; set; }
		public string Action { get; set; }
		public string TargetUsername { get; set; }
		public string Details { get; set; }
	}

	public sealed class UserAdminRepository
	{
		public List<UserListRow> List()
		{
			var list = new List<UserListRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_List"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new UserListRow
					{
						Id = (int)r["UserId"],
						Username = (string)r["Username"],
						FullName = (string)r["FullName"],
						RoleId = (int)r["RoleId"],
						RoleName = (string)r["RoleName"],
						IsActive = (bool)r["IsActive"],
						LastLoginAt = ReadNullableDate(r["LastLoginAt"]),
						CreatedAt = (DateTime)r["CreatedAt"]
					});
				}
			}
			return list;
		}

		public User GetById(int userId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_GetById"))
			{
				command.Parameters.Add(Db.Param("@UserId", userId));
				using (var r = command.ExecuteReader())
				{
					if (!r.Read()) return null;
					return new User
					{
						Id = (int)r["UserId"],
						Username = (string)r["Username"],
						FullName = (string)r["FullName"],
						Role = (UserRole)(int)r["RoleId"],
						IsActive = (bool)r["IsActive"]
					};
				}
			}
		}

		public List<RoleRow> Roles()
		{
			var list = new List<RoleRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Role_List"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new RoleRow
					{
						RoleId = (int)r["RoleId"],
						RoleName = (string)r["RoleName"],
						Description = Col.Text(r, "Description")
					});
				}
			}
			return list;
		}

		// Returns the new user ID. The database raises an error if the username already exists.
		public int Insert(int actorUserId, string username, string passwordHash, string salt,
						  string fullName, int roleId, bool isActive)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_Insert"))
			{
				command.Parameters.Add(Db.Param("@ActorUserId", actorUserId));
				command.Parameters.Add(Db.Param("@Username", username));
				command.Parameters.Add(Db.Param("@PasswordHash", passwordHash));
				command.Parameters.Add(Db.Param("@Salt", salt));
				command.Parameters.Add(Db.Param("@FullName", fullName));
				command.Parameters.Add(Db.Param("@RoleId", roleId));
				command.Parameters.Add(Db.Param("@IsActive", isActive));

				var newId = new SqlParameter("@NewUserId", SqlDbType.Int) { Direction = ParameterDirection.Output };
				command.Parameters.Add(newId);

				command.ExecuteNonQuery();
				return (int)newId.Value;
			}
		}

		// The database blocks changes that would lock out the last Admin or the signed-in Admin.
		public void Update(int actorUserId, int userId, string fullName, int roleId, bool isActive)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_Update"))
			{
				command.Parameters.Add(Db.Param("@ActorUserId", actorUserId));
				command.Parameters.Add(Db.Param("@UserId", userId));
				command.Parameters.Add(Db.Param("@FullName", fullName));
				command.Parameters.Add(Db.Param("@RoleId", roleId));
				command.Parameters.Add(Db.Param("@IsActive", isActive));
				command.ExecuteNonQuery();
			}
		}

		public void SetPassword(int actorUserId, int userId, string passwordHash, string salt)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_SetPassword"))
			{
				command.Parameters.Add(Db.Param("@ActorUserId", actorUserId));
				command.Parameters.Add(Db.Param("@UserId", userId));
				command.Parameters.Add(Db.Param("@PasswordHash", passwordHash));
				command.Parameters.Add(Db.Param("@Salt", salt));
				command.ExecuteNonQuery();
			}
		}

		// Reads audit entries for a date range. The "to" value is exclusive.
		public List<AuditRow> Audit(DateTime from, DateTime to, int? targetUserId)
		{
			var list = new List<AuditRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Audit_List"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				command.Parameters.Add(Db.Param("@TargetUserId", targetUserId));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new AuditRow
						{
							AuditId = (int)r["AuditId"],
							OccurredAt = (DateTime)r["OccurredAt"],
							ActorUsername = Col.Text(r, "ActorUsername"),
							Action = (string)r["Action"],
							TargetUsername = Col.Text(r, "TargetUsername"),
							Details = Col.Text(r, "Details")
						});
					}
				}
			}
			return list;
		}

		private static DateTime? ReadNullableDate(object value)
		{
			return value == DBNull.Value ? (DateTime?)null : (DateTime)value;
		}
	}
}