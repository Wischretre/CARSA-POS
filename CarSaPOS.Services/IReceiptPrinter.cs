using CarSaPOS.Domain;

namespace CarSaPOS.Services
{
	// Checkout depends on this interface, not on a specific printer.
	// The WinForms ReceiptPrinter implements it using PrintDocument.
	public interface IReceiptPrinter
	{
		void Print(ReceiptData receipt);
		void Preview(ReceiptData receipt);
	}
}