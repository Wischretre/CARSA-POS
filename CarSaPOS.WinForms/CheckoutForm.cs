using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CarSaPOS.Data;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class CheckoutForm : Form
	{
		private readonly InventoryService inventory = new InventoryService();
		private readonly SalesService sales = new SalesService();
		private readonly BarcodeLookupService lookup = new BarcodeLookupService();
		private readonly BindingList<CartLine> cart = new BindingList<CartLine>();
		private readonly ErrorProvider errors = new ErrorProvider();

		// Stock when each product was added. Quantities above this are refused on screen.
		private readonly Dictionary<int, int> stockByProduct = new Dictionary<int, int>();

		// Receipt for the most recent completed sale.
		private ReceiptData lastReceipt;

		public CheckoutForm()
		{
			InitializeComponent();

			Load += (s, e) => LoadScreen();
			txtBarcode.KeyDown += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					e.SuppressKeyPress = true;
					ScanCode();
				}
			};
			txtSearch.KeyDown += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					e.SuppressKeyPress = true;
					SearchProducts();
				}
			};
			btnSearch.Click += (s, e) => SearchProducts();
			btnAddToCart.Click += (s, e) => AddSelectedProduct();
			gridProducts.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) AddSelectedProduct(); };
			btnRemove.Click += (s, e) => RemoveSelectedLine();
			btnClear.Click += (s, e) => ClearSale();
			btnCheckout.Click += (s, e) => Checkout();
			btnClose.Click += (s, e) => Close();

			txtDiscount.TextChanged += (s, e) => RefreshTotals();
			txtAmountPaid.TextChanged += (s, e) => RefreshTotals();
			cboPayment.SelectedIndexChanged += (s, e) => RefreshTotals();

			gridCart.CellValidating += GridCartCellValidating;
			gridCart.CellEndEdit += (s, e) => { cart.ResetBindings(); RefreshTotals(); };
			gridCart.DataError += (s, e) => { e.ThrowException = false; };
			gridProducts.DataError += (s, e) => { e.ThrowException = false; };
		}

		private void LoadScreen()
		{
			try
			{
				// "Walk-in customer" (Id 0) means no customer is attached to the sale.
				var customers = new List<Customer> { new Customer { Id = 0, FullName = "Walk-in customer" } };
				customers.AddRange(sales.GetCustomers());
				cboCustomer.DisplayMember = "FullName";
				cboCustomer.ValueMember = "Id";
				cboCustomer.DataSource = customers;

				cboPayment.Items.Clear();
				cboPayment.Items.AddRange(new object[] { "Cash", "Card", "Mobile" });
				cboPayment.SelectedIndex = 0;

				gridCart.DataSource = cart;
				ConfigureCartGrid();

				txtDiscount.Text = "0.00";
				RefreshTotals();
				SearchProducts();
				txtBarcode.Focus();
			}
			catch (UnauthorizedAccessException ex)
			{
				lblStatus.Text = ex.Message;
				btnCheckout.Enabled = false;
			}
			catch (Exception)
			{
				lblStatus.Text = "Unable to load checkout. Contact the administrator.";
				btnCheckout.Enabled = false;
			}
		}

		private void ConfigureCartGrid()
		{
			HideColumn(gridCart, "ProductId");
			foreach (DataGridViewColumn column in gridCart.Columns)
			{
				// Only the quantity can be edited on screen.
				column.ReadOnly = column.Name != "Quantity";
			}
		}

		private void ConfigureProductGrid()
		{
			HideColumn(gridProducts, "Id");
			HideColumn(gridProducts, "CategoryId");
			HideColumn(gridProducts, "CategoryName");
			HideColumn(gridProducts, "Barcode");
			HideColumn(gridProducts, "Cost");
			HideColumn(gridProducts, "ImagePath");
			HideColumn(gridProducts, "IsActive");
			HideColumn(gridProducts, "IsLowStock");
		}

		private static void HideColumn(DataGridView grid, string name)
		{
			if (grid.Columns.Contains(name))
			{
				grid.Columns[name].Visible = false;
			}
		}

		private void SearchProducts()
		{
			try
			{
				gridProducts.DataSource = inventory.Search(txtSearch.Text, false, false);
				ConfigureProductGrid();
			}
			catch (UnauthorizedAccessException ex)
			{
				lblStatus.Text = ex.Message;
			}
			catch (Exception)
			{
				lblStatus.Text = "Unable to search products. Contact the administrator.";
			}
		}

		// Barcode box: Enter looks up one product and adds it. Focus returns to the box for the next scan.
		private void ScanCode()
		{
			try
			{
				ProductListItem product = lookup.FindOne(txtBarcode.Text);
				if (AddToCart(product))
				{
					txtBarcode.Clear();
				}
			}
			catch (ArgumentException ex)
			{
				lblStatus.Text = ex.Message;
			}
			catch (UnauthorizedAccessException ex)
			{
				lblStatus.Text = ex.Message;
			}
			catch (Exception)
			{
				lblStatus.Text = "Lookup failed. Contact the administrator.";
			}
			txtBarcode.Focus();
			txtBarcode.SelectAll();
		}

		private void AddSelectedProduct()
		{
			ProductListItem product = gridProducts.CurrentRow == null
				? null
				: gridProducts.CurrentRow.DataBoundItem as ProductListItem;

			if (product == null)
			{
				lblStatus.Text = "Select a product first.";
				return;
			}
			AddToCart(product);
		}

		// Adds one unit, or increases the quantity of a line already in the cart. Returns false when refused.
		private bool AddToCart(ProductListItem product)
		{
			if (product.StockQty <= 0)
			{
				lblStatus.Text = product.Name + " is out of stock.";
				return false;
			}

			CartLine line = cart.FirstOrDefault(l => l.ProductId == product.Id);
			int newQuantity = line == null ? 1 : line.Quantity + 1;
			if (newQuantity > product.StockQty)
			{
				lblStatus.Text = "Only " + product.StockQty + " in stock for " + product.Name + ".";
				return false;
			}

			if (line == null)
			{
				cart.Add(new CartLine
				{
					ProductId = product.Id,
					Sku = product.Sku,
					ProductName = product.Name,
					Quantity = 1,
					UnitPrice = product.Price
				});
			}
			else
			{
				line.Quantity = newQuantity;
			}

			stockByProduct[product.Id] = product.StockQty;
			lblStatus.Text = string.Empty;
			cart.ResetBindings();
			RefreshTotals();
			return true;
		}

		private void RemoveSelectedLine()
		{
			CartLine line = gridCart.CurrentRow == null
				? null
				: gridCart.CurrentRow.DataBoundItem as CartLine;

			if (line == null)
			{
				lblStatus.Text = "Select a cart line to remove.";
				return;
			}

			cart.Remove(line);
			lblStatus.Text = string.Empty;
			RefreshTotals();
		}

		// Stops an invalid or over-stock quantity before it is saved to the cart.
		private void GridCartCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (gridCart.Columns[e.ColumnIndex].Name != "Quantity")
				return;

			var line = gridCart.Rows[e.RowIndex].DataBoundItem as CartLine;
			int quantity;
			if (line == null ||
				!int.TryParse(Convert.ToString(e.FormattedValue).Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out quantity) ||
				quantity < 1)
			{
				lblStatus.Text = "Quantity must be a whole number of at least 1.";
				e.Cancel = true;
				return;
			}

			int stock;
			if (stockByProduct.TryGetValue(line.ProductId, out stock) && quantity > stock)
			{
				lblStatus.Text = "Only " + stock + " in stock for " + line.ProductName + ".";
				e.Cancel = true;
				return;
			}

			lblStatus.Text = string.Empty;
		}

		private void ClearSale()
		{
			cart.Clear();
			stockByProduct.Clear();
			txtDiscount.Text = "0.00";
			txtAmountPaid.Clear();
			errors.Clear();
			lblStatus.Text = string.Empty;
			RefreshTotals();
			txtBarcode.Focus();
		}

		// Blank means zero. Invalid text is treated as zero here, and Checkout rejects it.
		private static bool TryParseMoney(string text, out decimal value)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				value = 0m;
				return true;
			}
			return decimal.TryParse(text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out value);
		}

		private void RefreshTotals()
		{
			decimal discount;
			decimal paid;
			if (!TryParseMoney(txtDiscount.Text, out discount))
				discount = 0m;
			TryParseMoney(txtAmountPaid.Text, out paid);

			SalesTotals totals = sales.Preview(cart, discount, SalesService.DefaultTaxRate);

			string change = string.Empty;
			if (cboPayment.SelectedItem != null &&
				cboPayment.SelectedItem.ToString() == "Cash" &&
				paid >= totals.Total)
			{
				change = "\nChange: " + (paid - totals.Total).ToString("N2");
			}

			lblTotals.Text =
				"Subtotal: " + totals.Subtotal.ToString("N2") + "\n" +
				"Discount: -" + totals.Discount.ToString("N2") + "\n" +
				"Tax (" + SalesService.DefaultTaxRate.ToString("0") + "%): " + totals.Tax.ToString("N2") + "\n" +
				"Total: " + totals.Total.ToString("N2") +
				change;
		}

		private void Checkout()
		{
			if (cart.Count == 0)
			{
				lblStatus.Text = "Add at least one item to the cart.";
				return;
			}

			decimal discount;
			decimal paid;
			if (!ValidatePayment(out discount, out paid))
			{
				lblStatus.Text = "Please fix the highlighted fields.";
				return;
			}

			int? customerId = null;
			var selectedCustomer = cboCustomer.SelectedItem as Customer;
			if (selectedCustomer != null && selectedCustomer.Id != 0)
			{
				customerId = selectedCustomer.Id;
			}

			string payment = cboPayment.SelectedItem.ToString();

			int orderId;
			try
			{
				// The order is saved in one database transaction. Nothing below runs unless this succeeds.
				orderId = sales.Checkout(cart, customerId, payment, discount, paid, SalesService.DefaultTaxRate);
			}
			catch (Exception ex)
			{
				lblStatus.Text = ErrorMessages.For(ex);
				return;
			}

			CompleteSale(orderId);
		}

		// Checks the discount, payment method, and amount paid. Marks bad fields and returns true only when all are valid.
		private bool ValidatePayment(out decimal discount, out decimal paid)
		{
			errors.Clear();
			bool ok = true;
			discount = 0m;
			paid = 0m;

			if (!TryParseMoney(txtDiscount.Text, out discount))
			{
				ok = Invalid(txtDiscount, "Enter a number, such as 5.00.");
			}
			else if (discount < 0)
			{
				ok = Invalid(txtDiscount, "Discount cannot be negative.");
			}
			else
			{
				decimal subtotal = sales.Preview(cart, 0m, SalesService.DefaultTaxRate).Subtotal;
				if (discount > subtotal)
					ok = Invalid(txtDiscount, "Discount cannot be more than the subtotal.");
			}

			if (cboPayment.SelectedItem == null)
				ok = Invalid(cboPayment, "Choose a payment method.");

			if (!TryParseMoney(txtAmountPaid.Text, out paid))
			{
				ok = Invalid(txtAmountPaid, "Enter a number, such as 100.00.");
			}
			else if (IsCash())
			{
				// Only cash needs an amount typed in. Card and mobile are charged the exact total.
				if (paid < 0)
				{
					ok = Invalid(txtAmountPaid, "Amount paid cannot be negative.");
				}
				else if (ok)
				{
					decimal total = sales.Preview(cart, discount, SalesService.DefaultTaxRate).Total;
					if (paid < total)
						ok = Invalid(txtAmountPaid, "Amount paid is less than the total.");
				}
			}

			return ok;
		}

		private bool IsCash()
		{
			return cboPayment.SelectedItem != null && cboPayment.SelectedItem.ToString() == "Cash";
		}

		// Marks one field with a message and returns false, so the caller can record the failure.
		private bool Invalid(Control control, string message)
		{
			errors.SetError(control, message);
			return false;
		}

		// Runs after the order is saved. A receipt problem never duplicates or cancels the order.
		private void CompleteSale(int orderId)
		{
			string message;
			try
			{
				Order order = sales.GetOrder(orderId);
				lastReceipt = CreateReceipt(order);
				message = "Order " + order.OrderNumber + " saved.\n" +
					"Total: " + order.Total.ToString("N2") + "\n" +
					"Change: " + order.ChangeDue.ToString("N2");
			}
			catch (Exception)
			{
				lastReceipt = null;
				message = "Order " + orderId + " saved. The receipt could not be loaded.";
			}

			ClearSale();

			MessageBox.Show(message, "CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);

			if (lastReceipt != null)
			{
				ShowReceipt();
			}
		}

		// Builds the receipt from the committed order (PDF Appendix B.5).
		private ReceiptData CreateReceipt(Order order)
		{
			var receipt = new ReceiptData
			{
				BusinessName = ReceiptStoreInfo.BusinessName,
				Address = ReceiptStoreInfo.Address,
				Phone = ReceiptStoreInfo.Phone,
				OrderNumber = order.OrderNumber,
				Date = order.OrderDate,
				CashierName = Session.CurrentUser == null ? string.Empty : Session.CurrentUser.FullName,
				Subtotal = order.Subtotal,
				Tax = order.TaxAmount,
				Discount = order.DiscountAmount,
				Total = order.Total,
				PaymentMethod = order.PaymentMethod,
				AmountTendered = order.AmountPaid,
				Change = order.ChangeDue,
				ReturnPolicy = ReceiptStoreInfo.ReturnPolicy
			};

			foreach (OrderDetail line in order.Lines)
			{
				receipt.Lines.Add(new ReceiptLine
				{
					ProductName = line.ProductName,
					Quantity = line.Quantity,
					Amount = line.LineTotal
				});
			}

			return receipt;
		}

		// Opens the print preview. The preview window has its own Print button.
		private void ShowReceipt()
		{
			try
			{
				var printer = new ReceiptPrinter();
				printer.Preview(lastReceipt);
			}
			catch (Exception)
			{
				lblStatus.Text = "The receipt could not be shown. Check the printer setup.";
			}
		}
	}
}