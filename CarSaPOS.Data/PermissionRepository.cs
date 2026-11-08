using System.Collections.Generic;
using System.Data;

namespace CarSaPOS.Data
{
	// Reads the permission names a user has through their role.
	public sealed class PermissionRepository
	{
		public List<string> ListForUser(int userId)
		{
			var list = new List<string>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Permission_ListForUser"))
			{
				command.Parameters.Add(Db.Param("@UserId", userId));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add((string)r["PermissionName"]);
					}
				}
			}
			return list;
		}
	}
}