using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	// Prints or previews a receipt on an 80 mm thermal printer (or any printer with the same paper size).
	public sealed class ReceiptPrinter : IReceiptPrinter
	{
		// Characters per line for the monospace font on an 80 mm receipt.
		private const int LineWidth = 42;

		private readonly PrintDocument document = new PrintDocument();
		private readonly Font font = new Font("Courier New", 8F);
		private List<string> lines = new List<string>();
		private int nextLine;

		public ReceiptPrinter()
		{
			document.DocumentName = "CarSaPOS Receipt";
			// 315 x 900 hundredths of an inch is about 80 mm wide, as in the PDF.
			document.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 315, 900);
			document.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
			document.PrintPage += PrintPage;
		}

		public void Print(ReceiptData receipt)
		{
			Prepare(receipt);
			document.Print();
		}

		public void Preview(ReceiptData receipt)
		{
			Prepare(receipt);
			using (var dialog = new PrintPreviewDialog())
			{
				dialog.Document = document;
				dialog.Width = 500;
				dialog.Height = 700;
				dialog.ShowDialog();
			}
		}

		private void Prepare(ReceiptData receipt)
		{
			if (receipt == null)
				throw new ArgumentNullException("receipt");

			lines = BuildLines(receipt);
			nextLine = 0;
		}

		// Draws the prepared lines. Continues on another page if the receipt is longer than one page.
		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			float y = e.MarginBounds.Top;
			float lineHeight = font.GetHeight(e.Graphics);

			while (nextLine < lines.Count && y + lineHeight <= e.MarginBounds.Bottom)
			{
				e.Graphics.DrawString(lines[nextLine], font, Brushes.Black, e.MarginBounds.Left, y);
				y += lineHeight;
				nextLine++;
			}

			e.HasMorePages = nextLine < lines.Count;
		}

		// Builds the receipt as text lines. Follows the PDF's Appendix B.1 sample.
		private static List<string> BuildLines(ReceiptData r)
		{
			var list = new List<string>();

			list.Add(Center(Fit(r.BusinessName ?? ReceiptStoreInfo.BusinessName, LineWidth)));
			list.Add(Center(Fit(r.Address ?? ReceiptStoreInfo.Address, LineWidth)));
			list.Add(Center("Tel: " + (r.Phone ?? ReceiptStoreInfo.Phone)));
			list.Add(Rule());

			list.Add("Order: " + r.OrderNumber);
			list.Add("Date : " + r.Date.ToString("yyyy-MM-dd HH:mm"));
			list.Add("Cashier: " + r.CashierName);
			list.Add(Rule());

			list.Add(Row("Product", "Qty", "Amount"));
			foreach (ReceiptLine line in r.Lines)
			{
				list.Add(Row(line.ProductName, line.Quantity.ToString(), Money(line.Amount)));
			}
			list.Add(Rule());

			list.Add(Summary("Subtotal", r.Subtotal));
			list.Add(Summary("Tax", r.Tax));
			list.Add(Summary("Discount", r.Discount));
			list.Add(Summary("TOTAL", r.Total));
			list.Add(Rule());

			list.Add("Payment: " + (r.PaymentMethod ?? string.Empty).ToUpperInvariant());
			list.Add(Summary("Tendered", r.AmountTendered));
			list.Add(Summary("Change", r.Change));
			list.Add(string.Empty);

			list.Add(Center("Thank you for your purchase!"));
			foreach (string part in WrapText(r.ReturnPolicy ?? ReceiptStoreInfo.ReturnPolicy, LineWidth))
			{
				list.Add(Center(part));
			}

			return list;
		}

		// Name on the left (24 characters), quantity and amount right-aligned.
		private static string Row(string name, string qty, string amount)
		{
			return string.Format("{0,-24}{1,4}{2,14}", Fit(name ?? string.Empty, 24), qty, amount);
		}

		// Label on the left, amount right-aligned across the full width.
		private static string Summary(string label, decimal amount)
		{
			return string.Format("{0,-28}{1,14}", label, Money(amount));
		}

		private static string Money(decimal amount)
		{
			return amount.ToString("N2");
		}

		private static string Rule()
		{
			return new string('-', LineWidth);
		}

		private static string Center(string text)
		{
			string fitted = Fit(text ?? string.Empty, LineWidth);
			int padding = Math.Max(0, (LineWidth - fitted.Length) / 2);
			return new string(' ', padding) + fitted;
		}

		// Cuts text that is too long, so it never overlaps the amount column.
		private static string Fit(string text, int width)
		{
			if (text.Length <= width)
				return text;
			return text.Substring(0, width);
		}

		// Splits a long sentence into lines that fit the receipt width.
		private static IEnumerable<string> WrapText(string text, int width)
		{
			var current = string.Empty;
			foreach (string word in text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
			{
				string candidate = current.Length == 0 ? word : current + " " + word;
				if (candidate.Length > width && current.Length > 0)
				{
					yield return current;
					current = word;
				}
				else
				{
					current = candidate;
				}
			}
			if (current.Length > 0)
				yield return current;
		}
	}
}