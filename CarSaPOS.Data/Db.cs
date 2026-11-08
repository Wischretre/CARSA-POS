using System;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;

namespace CarSaPOS.Data
{
	public sealed class PosDataContext : DataContext
	{
		public PosDataContext(string connectionString) : base(connectionString)
		{
			ObjectTrackingEnabled = true;
			DeferredLoadingEnabled = false;
		}
	}

	public static class Db
	{
		public static string ConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings["EnterprisePOS"].ConnectionString; }
		}

		public static SqlConnection Open()
		{
			var connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection;
		}

		public static SqlCommand Procedure(SqlConnection connection, string name)
		{
			return new SqlCommand(name, connection) { CommandType = CommandType.StoredProcedure };
		}

		public static SqlParameter Param(string name, object value)
		{
			return new SqlParameter(name, value ?? DBNull.Value);
		}
	}
}