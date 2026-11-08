using System;
using System.Threading;
using System.Windows.Forms;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	internal static class Program
	{
		private static bool _handlingCrash;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			AppLogger.Initialize();
			AppLogger.Info("CarSaPOS started.");

			// Catch errors on the UI thread and report them through OnThreadException.
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += OnThreadException;

			// Catch any other unhandled error, such as one on a background thread.
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LoginForm());
		}

		private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
		{
			HandleCrash("Unhandled UI exception", e.Exception);
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			HandleCrash("Unhandled exception", e.ExceptionObject as Exception);
		}

		// Logs the full details for support, then shows a message that contains no SQL, no
		// connection string, and no technical text. The app then closes, because continuing
		// after an unexpected error can leave data in an unknown state.
		private static void HandleCrash(string title, Exception ex)
		{
			if (_handlingCrash) return;
			_handlingCrash = true;

			AppLogger.Error(title, ex);

			MessageBox.Show(
				"CarSaPOS ran into an unexpected problem and needs to close.\n\n" +
				"Technical details were saved to:\n" + AppLogger.CurrentLogPath + "\n\n" +
				"Please send that file to your administrator.",
				"CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

			Environment.Exit(1);
		}
	}
}