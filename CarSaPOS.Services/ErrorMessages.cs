using System;
using System.Data.SqlClient;

namespace CarSaPOS.Services
{
	// Turns any exception into a message that is safe to show to the user.
	// Technical details are written to the log for support instead.
	public static class ErrorMessages
	{
		private const string Generic =
			"Something went wrong while saving. Please try again. If it keeps happening, contact the administrator.";

		public static string For(Exception ex)
		{
			// Our own permission and validation messages are written to be read by users.
			if (ex is UnauthorizedAccessException || ex is ArgumentException)
				return ex.Message;

			var sql = ex as SqlException;
			if (sql != null)
			{
				// Messages raised by our stored procedures with RAISERROR use number 50000 and are written to be shown.
				if (sql.Number == 50000)
					return sql.Message;

				// Duplicate value (unique constraint).
				if (sql.Number == 2601 || sql.Number == 2627)
					return "That value already exists. Please use a different one.";

				// Foreign key: the record is used by other records.
				if (sql.Number == 547)
					return "This item is linked to other records, so the change can't be completed.";

				// Timeout or connection problem.
				if (sql.Number == -2 || sql.Number == 53)
					return "The database could not be reached. Check the connection and try again.";

				AppLogger.Error("Database error " + sql.Number, sql);
				return "A database error occurred. Please try again. If it keeps happening, contact the administrator.";
			}

			AppLogger.Error("Unexpected error", ex);
			return Generic;
		}
	}
}