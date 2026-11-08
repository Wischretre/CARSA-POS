using System;

namespace CarSaPOS.Services
{
	public sealed class BarcodeScannedEventArgs : EventArgs
	{
		public BarcodeScannedEventArgs(string code)
		{
			Code = code;
		}

		public string Code { get; private set; }
	}

	// Any scanner source raises BarcodeScanned. A USB keyboard-style scanner works today,
	// and a hardware SDK can be added later without changing the checkout screen.
	public interface IBarcodeScanner
	{
		event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
	}
}