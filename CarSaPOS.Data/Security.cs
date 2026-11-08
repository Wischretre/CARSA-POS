using System;
using System.Security.Cryptography;
using System.Text;

namespace CarSaPOS.Data
{
	// Salted SHA-256, matching the seed data in 01_CreateDatabase.sql:
	// SHA-256 of (salt + password) using ASCII bytes, stored as uppercase hex.
	public static class PasswordHasher
	{
		public static string NewSalt()
		{
			byte[] bytes = new byte[16];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(bytes);
			}
			return ToHex(bytes);
		}

		public static string Hash(string password, string salt)
		{
			byte[] input = Encoding.ASCII.GetBytes(salt + password);
			using (var sha = SHA256.Create())
			{
				return ToHex(sha.ComputeHash(input));
			}
		}

		public static bool Verify(string password, string salt, string storedHash)
		{
			if (password == null || salt == null || storedHash == null)
				return false;

			string computed = Hash(password, salt);
			if (computed.Length != storedHash.Length)
				return false;

			int difference = 0;
			for (int i = 0; i < computed.Length; i++)
			{
				difference |= computed[i] ^ char.ToUpperInvariant(storedHash[i]);
			}
			return difference == 0;
		}

		private static string ToHex(byte[] bytes)
		{
			var sb = new StringBuilder(bytes.Length * 2);
			foreach (byte b in bytes)
			{
				sb.Append(b.ToString("X2"));
			}
			return sb.ToString();
		}
	}
}