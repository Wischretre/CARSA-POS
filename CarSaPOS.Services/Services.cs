using System;
using System.Collections.Generic;
using System.Linq;
using CarSaPOS.Data;
using CarSaPOS.Domain;

namespace CarSaPOS.Services
{
	// Holds the logged-in user and their permissions for the whole application session.
	public static class Session
	{
		private static readonly HashSet<string> _permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		public static User CurrentUser { get; set; }

		public static void SetPermissions(IEnumerable<string> permissions)
		{
			_permissions.Clear();
			foreach (string permission in permissions)
			{
				_permissions.Add(permission);
			}
		}

		public static void ClearPermissions()
		{
			_permissions.Clear();
		}

		public static bool HasPermission(string permission)
		{
			return CurrentUser != null && _permissions.Contains(permission);
		}

		public static void RequirePermission(string permission)
		{
			if (!HasPermission(permission))
				throw new UnauthorizedAccessException("You do not have permission for this action.");
		}

		public static void Require(params UserRole[] allowedRoles)
		{
			if (CurrentUser == null || !allowedRoles.Contains(CurrentUser.Role))
				throw new UnauthorizedAccessException("You do not have permission for this action.");
		}
	}

	public sealed class SalesTotals
	{
		public decimal Subtotal { get; set; }
		public decimal Discount { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }
	}

	public sealed class AuthService
	{
		private readonly UserRepository users = new UserRepository();
		private readonly PermissionRepository permissions = new PermissionRepository();

		// Returns the user when the credentials are valid and the account is active; otherwise null.
		public User Login(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
				return null;

			User user = users.GetByUsername(username.Trim());
			if (user == null || !user.IsActive)
				return null;

			if (!PasswordHasher.Verify(password, user.Salt, user.PasswordHash))
				return null;

			users.TouchLogin(user.Id);
			Session.CurrentUser = user;
			Session.SetPermissions(permissions.ListForUser(user.Id));
			return user;
		}

		public void Logout()
		{
			Session.CurrentUser = null;
			Session.ClearPermissions();
		}
	}

	public sealed class InventoryService
	{
		private readonly ProductRepository products = new ProductRepository();
		private readonly InventoryRepository inventory = new InventoryRepository();
		private readonly CategoryRepository categories = new CategoryRepository();

		public List<Category> GetCategories()
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return categories.GetAll();
		}

		public List<ProductListItem> Search(string text, bool lowStockOnly, bool includeInactive)
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return products.Search(text, lowStockOnly, includeInactive);
		}

		public Product GetById(int productId)
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return products.GetById(productId);
		}

		// Inserts when product.Id is 0, otherwise updates. Returns the product ID.
		// product.ImagePath must already be set by ProductImageStorage.Import, or be null.
		public int Save(Product product)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			Validate(product);
			return products.Save(product, Session.CurrentUser.Id);
		}

		// Soft delete: the product is hidden but sales history is kept.
		public void Deactivate(int productId)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			products.Deactivate(productId);
		}

		// Positive numbers add stock, negative numbers remove it. Returns the new stock level.
		public int AdjustStock(int productId, int changeQty, string reason)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);

			if (changeQty == 0)
				throw new ArgumentException("The adjustment cannot be zero.");
			if (string.IsNullOrWhiteSpace(reason))
				throw new ArgumentException("A reason is required for a stock adjustment.");

			return inventory.Adjust(productId, changeQty, reason.Trim(), Session.CurrentUser.Id);
		}

		private static void Validate(Product p)
		{
			if (p == null)
				throw new ArgumentNullException("product");

			p.Sku = (p.Sku ?? string.Empty).Trim();
			p.Name = (p.Name ?? string.Empty).Trim();
			p.Barcode = string.IsNullOrWhiteSpace(p.Barcode) ? null : p.Barcode.Trim();
			p.ImagePath = string.IsNullOrWhiteSpace(p.ImagePath) ? null : p.ImagePath.Trim();

			if (p.Sku.Length == 0 || p.Sku.Length > 30)
				throw new ArgumentException("SKU is required and must be 30 characters or fewer.");
			if (p.Name.Length == 0 || p.Name.Length > 150)
				throw new ArgumentException("Product name is required and must be 150 characters or fewer.");
			if (p.Barcode != null && p.Barcode.Length > 50)
				throw new ArgumentException("Barcode must be 50 characters or fewer.");
			if (p.CategoryId <= 0)
				throw new ArgumentException("Choose a category.");
			if (p.Price < 0)
				throw new ArgumentException("Selling price cannot be negative.");
			if (p.Cost < 0)
				throw new ArgumentException("Cost cannot be negative.");
			if (p.StockQty < 0)
				throw new ArgumentException("Stock cannot be negative.");
			if (p.ReorderLevel < 0)
				throw new ArgumentException("Reorder level cannot be negative.");

			// The image path must be a short relative path inside the media folder.
			if (p.ImagePath != null)
			{
				if (p.ImagePath.Length > 260)
					throw new ArgumentException("The image path is too long.");
				if (p.ImagePath.Contains("..") || System.IO.Path.IsPathRooted(p.ImagePath))
					throw new ArgumentException("The image path is not valid.");
			}
		}
	}

	public sealed class SalesService
	{
		// Tax rate used when none is given. The screenshots show 8%; change this if your rate differs.
		public const decimal DefaultTaxRate = 8m;

		private readonly OrderRepository orders = new OrderRepository();
		private readonly CustomerRepository customers = new CustomerRepository();

		private static readonly string[] PaymentMethods = { "Cash", "Card", "Mobile" };

		public List<Customer> GetCustomers()
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return customers.GetAll();
		}

		// Calculates the totals shown on screen. The database recalculates them at checkout.
		public SalesTotals Preview(IList<CartLine> cart, decimal discount, decimal taxRate)
		{
			decimal subtotal = cart == null ? 0m : cart.Sum(line => line.LineTotal);
			decimal taxable = subtotal - discount;
			decimal tax = Math.Round(taxable * taxRate / 100m, 2, MidpointRounding.AwayFromZero);

			return new SalesTotals
			{
				Subtotal = subtotal,
				Discount = discount,
				Tax = tax,
				Total = subtotal - discount + tax
			};
		}

		// Saves the order in one transaction and returns the new order ID.
		public int Checkout(IList<CartLine> cart, int? customerId, string paymentMethod,
							decimal discount, decimal amountPaid, decimal taxRate)
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);

			if (cart == null || cart.Count == 0)
				throw new ArgumentException("The cart is empty.");
			if (cart.Any(line => line.Quantity <= 0))
				throw new ArgumentException("Every item needs a quantity of at least 1.");
			if (!PaymentMethods.Contains(paymentMethod))
				throw new ArgumentException("Choose a payment method: Cash, Card, or Mobile.");
			if (discount < 0)
				throw new ArgumentException("Discount cannot be negative.");

			SalesTotals totals = Preview(cart, discount, taxRate);
			if (discount > totals.Subtotal)
				throw new ArgumentException("Discount cannot be more than the subtotal.");

			// Card and mobile payments are taken for the exact total.
			decimal paid = paymentMethod == "Cash" ? amountPaid : totals.Total;
			if (paid < totals.Total)
				throw new ArgumentException("Amount paid is less than the total.");

			return orders.Create(Session.CurrentUser.Id, customerId, paymentMethod,
								 discount, taxRate, paid, cart);
		}

		public Order GetOrder(int orderId)
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return orders.GetById(orderId);
		}
	}

	public sealed class ReportingService
	{
		private readonly ReportRepository reports = new ReportRepository();
		private readonly OrderRepository orders = new OrderRepository();

		public DashboardSummary Dashboard()
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return reports.Dashboard();
		}

		// Newest orders for the dashboard. Cashiers can view sales, so all roles may see this.
		public List<RecentOrderItem> RecentOrders()
		{
			Session.Require(UserRole.Admin, UserRole.Manager, UserRole.Cashier);
			return orders.GetRecent(10);
		}

		public List<DailySalesSummary> DailySales(DateTime from, DateTime to)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return reports.DailySales(from, to);
		}

		public List<TopProductSummary> TopProducts(DateTime from, DateTime to, int top)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return reports.TopProducts(from, to, top <= 0 ? 10 : top);
		}

		public List<CategorySalesSummary> SalesByCategory(DateTime from, DateTime to)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return reports.SalesByCategory(from, to);
		}

		public List<LowStockItem> LowStock()
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			return reports.LowStock();
		}

		private static void ValidateRange(DateTime from, DateTime to)
		{
			if (from > to)
				throw new ArgumentException("The start date must be on or before the end date.");
		}
	}
}