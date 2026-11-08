using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace CarSaPOS.Services
{
	// Writes application logs to %ProgramData%\CarSaPOS\Logs, one file per day.
	// Logs are for support staff. Never show their contents to users.
	public static class AppLogger
	{
		public const int RetentionDays = 30;

		private static readonly object _sync = new object();

		public static string LogDirectory
		{
			get
			{
				return Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
					"CarSaPOS", "Logs");
			}
		}

		// Today's log file. The name includes the date.
		public static string CurrentLogPath
		{
			get
			{
				return Path.Combine(LogDirectory,
					"carsapos-" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ".log");
			}
		}

		// Call once at startup. Creates the folder and deletes logs older than the retention period.
		public static void Initialize()
		{
			try
			{
				Directory.CreateDirectory(LogDirectory);
				DeleteOldLogs();
			}
			catch (Exception)
			{
				// Logging must never stop the application from starting.
			}
		}

		public static void Info(string message)
		{
			Write("INFO", message, null);
		}

		public static void Error(string message, Exception ex)
		{
			Write("ERROR", message, ex);
		}

		private static void Write(string level, string message, Exception ex)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
				  .Append(" [").Append(level).Append("] ")
				  .AppendLine(message);

				if (ex != null)
				{
					sb.AppendLine(ex.ToString());
				}

				lock (_sync)
				{
					Directory.CreateDirectory(LogDirectory);
					File.AppendAllText(CurrentLogPath, sb.ToString(), Encoding.UTF8);
				}
			}
			catch (Exception)
			{
				// If the log cannot be written, do not throw from the logger.
			}
		}

		private static void DeleteOldLogs()
		{
			DateTime cutoff = DateTime.Now.Date.AddDays(-RetentionDays);

			foreach (string file in Directory.GetFiles(LogDirectory, "carsapos-*.log"))
			{
				if (File.GetLastWriteTime(file) < cutoff)
				{
					File.Delete(file);
				}
			}
		}
	}
}