using System;
using System.Linq;
using CarSaPOS.Data;

namespace CarSaPOS.Services
{
	public sealed class BarcodeLookupService
	{
		private readonly InventoryService inventory = new InventoryService();

		// Finds exactly one active product by barcode or SKU.
		// Throws ArgumentException with a message the screen can show when none or several match.
		public ProductListItem FindOne(string code)
		{
			string value = (code ?? string.Empty).Trim();
			if (value.Length == 0)
				throw new ArgumentException("Scan or type a barcode or SKU.");

			var matches = inventory.Search(value, false, false)
				.Where(p => p.IsActive &&
					(string.Equals(p.Barcode, value, StringComparison.OrdinalIgnoreCase) ||
					 string.Equals(p.Sku, value, StringComparison.OrdinalIgnoreCase)))
				.ToList();

			if (matches.Count == 0)
				throw new ArgumentException("No product matches \"" + value + "\".");
			if (matches.Count > 1)
				throw new ArgumentException("More than one product matches \"" + value + "\". Use the exact barcode.");

			return matches[0];
		}
	}
}