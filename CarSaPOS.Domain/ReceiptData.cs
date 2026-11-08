using System;
using System.Collections.Generic;

namespace CarSaPOS.Domain
{
	// Store details printed at the top and bottom of every receipt.
	// Change the values here to match your business.
	public static class ReceiptStoreInfo
	{
		public const string BusinessName = "CarSaPOS";
		public const string Address = "123 Main Street, City";
		public const string Phone = "+1 555 0100";
		public const string ReturnPolicy = "Returns accepted within 7 days with receipt.";
	}

	// One product line on the receipt.
	public sealed class ReceiptLine
	{
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
	}

	// Receipt-specific model. The printer uses this, not the database entity,
	// so printing does not depend on the Order class.
	public sealed class ReceiptData
	{
		public string BusinessName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string OrderNumber { get; set; }
		public DateTime Date { get; set; }
		public string CashierName { get; set; }
		public List<ReceiptLine> Lines { get; } = new List<ReceiptLine>();
		public decimal Subtotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Discount { get; set; }
		public decimal Total { get; set; }
		public string PaymentMethod { get; set; }
		public decimal AmountTendered { get; set; }
		public decimal Change { get; set; }
		public string ReturnPolicy { get; set; }
	}
}