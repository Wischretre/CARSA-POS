using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using CarSaPOS.Domain;

namespace CarSaPOS.Data
{
	// Helpers that turn SQL NULLs into C# nulls.
	internal static class Col
	{
		public static string Text(SqlDataReader r, string name)
		{
			object value = r[name];
			return value == DBNull.Value ? null : (string)value;
		}

		public static int? Int(SqlDataReader r, string name)
		{
			object value = r[name];
			return value == DBNull.Value ? (int?)null : (int)value;
		}
	}

	public sealed class DashboardSummary
	{
		public decimal TodaySales { get; set; }
		public int TodayOrders { get; set; }
		public int LowStockCount { get; set; }
		public int ActiveProducts { get; set; }
	}

	// Product row for the grid, including the category name and image path.
	public sealed class ProductListItem
	{
		public int Id { get; set; }
		public string Sku { get; set; }
		public string Barcode { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public decimal Price { get; set; }
		public decimal Cost { get; set; }
		public int StockQty { get; set; }
		public int ReorderLevel { get; set; }
		public string ImagePath { get; set; }
		public bool IsActive { get; set; }
		public bool IsLowStock { get; set; }
	}

	// Row for the dashboard's recent transactions list.
	public sealed class RecentOrderItem
	{
		public int OrderId { get; set; }
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Total { get; set; }
		public string PaymentMethod { get; set; }
		public string Status { get; set; }
		public string CashierName { get; set; }
	}

	public sealed class UserRepository
	{
		public User GetByUsername(string username)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Login"))
			{
				command.Parameters.Add(Db.Param("@Username", username));
				using (var r = command.ExecuteReader())
				{
					if (!r.Read()) return null;
					return new User
					{
						Id = (int)r["UserId"],
						Username = (string)r["Username"],
						PasswordHash = (string)r["PasswordHash"],
						Salt = (string)r["Salt"],
						FullName = (string)r["FullName"],
						Role = (UserRole)(int)r["RoleId"],
						IsActive = (bool)r["IsActive"]
					};
				}
			}
		}

		public void TouchLogin(int userId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_TouchLogin"))
			{
				command.Parameters.Add(Db.Param("@UserId", userId));
				command.ExecuteNonQuery();
			}
		}

		public int Create(User user, string password)
		{
			string salt = PasswordHasher.NewSalt();
			string hash = PasswordHasher.Hash(password, salt);

			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_Insert"))
			{
				command.Parameters.Add(Db.Param("@Username", user.Username));
				command.Parameters.Add(Db.Param("@PasswordHash", hash));
				command.Parameters.Add(Db.Param("@Salt", salt));
				command.Parameters.Add(Db.Param("@FullName", user.FullName));
				command.Parameters.Add(Db.Param("@RoleId", (int)user.Role));
				return Convert.ToInt32(command.ExecuteScalar());
			}
		}

		public void SetPassword(int userId, string password)
		{
			string salt = PasswordHasher.NewSalt();
			string hash = PasswordHasher.Hash(password, salt);

			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_User_SetPassword"))
			{
				command.Parameters.Add(Db.Param("@UserId", userId));
				command.Parameters.Add(Db.Param("@PasswordHash", hash));
				command.Parameters.Add(Db.Param("@Salt", salt));
				command.ExecuteNonQuery();
			}
		}
	}

	public sealed class CategoryRepository
	{
		public List<Category> GetAll()
		{
			var list = new List<Category>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Category_List"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new Category
					{
						Id = (int)r["CategoryId"],
						Name = (string)r["Name"],
						Description = Col.Text(r, "Description")
					});
				}
			}
			return list;
		}
	}

	public sealed class CustomerRepository
	{
		public List<Customer> GetAll()
		{
			var list = new List<Customer>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Customer_List"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new Customer
					{
						Id = (int)r["CustomerId"],
						FullName = (string)r["FullName"],
						Phone = Col.Text(r, "Phone"),
						Email = Col.Text(r, "Email"),
						Address = Col.Text(r, "Address"),
						CreatedAt = (DateTime)r["CreatedAt"]
					});
				}
			}
			return list;
		}
	}

	public sealed class ProductRepository
	{
		public List<ProductListItem> Search(string text, bool lowStockOnly, bool includeInactive)
		{
			var list = new List<ProductListItem>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Product_Search"))
			{
				command.Parameters.Add(Db.Param("@Search", string.IsNullOrWhiteSpace(text) ? null : text.Trim()));
				command.Parameters.Add(Db.Param("@LowStockOnly", lowStockOnly));
				command.Parameters.Add(Db.Param("@IncludeInactive", includeInactive));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new ProductListItem
						{
							Id = (int)r["ProductId"],
							Sku = (string)r["Sku"],
							Barcode = Col.Text(r, "Barcode"),
							Name = (string)r["Name"],
							CategoryId = (int)r["CategoryId"],
							CategoryName = (string)r["CategoryName"],
							Price = (decimal)r["Price"],
							Cost = (decimal)r["Cost"],
							StockQty = (int)r["StockQty"],
							ReorderLevel = (int)r["ReorderLevel"],
							ImagePath = Col.Text(r, "ImagePath"),
							IsActive = (bool)r["IsActive"],
							IsLowStock = (int)r["IsLowStock"] == 1
						});
					}
				}
			}
			return list;
		}

		public Product GetById(int productId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Product_GetById"))
			{
				command.Parameters.Add(Db.Param("@ProductId", productId));
				using (var r = command.ExecuteReader())
				{
					if (!r.Read()) return null;
					return new Product
					{
						Id = (int)r["ProductId"],
						Sku = (string)r["Sku"],
						Barcode = Col.Text(r, "Barcode"),
						Name = (string)r["Name"],
						CategoryId = (int)r["CategoryId"],
						Price = (decimal)r["Price"],
						Cost = (decimal)r["Cost"],
						StockQty = (int)r["StockQty"],
						ReorderLevel = (int)r["ReorderLevel"],
						ImagePath = Col.Text(r, "ImagePath"),
						IsActive = (bool)r["IsActive"],
						CreatedAt = (DateTime)r["CreatedAt"],
						UpdatedAt = (DateTime)r["UpdatedAt"]
					};
				}
			}
		}

		// Inserts when product.Id is 0, otherwise updates. Returns the product ID.
		public int Save(Product product, int userId)
		{
			using (var connection = Db.Open())
			{
				if (product.Id == 0)
				{
					using (var command = Db.Procedure(connection, "dbo.usp_Product_Insert"))
					{
						command.Parameters.Add(Db.Param("@Sku", product.Sku));
						command.Parameters.Add(Db.Param("@Barcode", product.Barcode));
						command.Parameters.Add(Db.Param("@Name", product.Name));
						command.Parameters.Add(Db.Param("@CategoryId", product.CategoryId));
						command.Parameters.Add(Db.Param("@Price", product.Price));
						command.Parameters.Add(Db.Param("@Cost", product.Cost));
						command.Parameters.Add(Db.Param("@StockQty", product.StockQty));
						command.Parameters.Add(Db.Param("@ReorderLevel", product.ReorderLevel));
						command.Parameters.Add(Db.Param("@ImagePath", product.ImagePath));
						command.Parameters.Add(Db.Param("@UserId", userId));
						return Convert.ToInt32(command.ExecuteScalar());
					}
				}

				using (var command = Db.Procedure(connection, "dbo.usp_Product_Update"))
				{
					command.Parameters.Add(Db.Param("@ProductId", product.Id));
					command.Parameters.Add(Db.Param("@Sku", product.Sku));
					command.Parameters.Add(Db.Param("@Barcode", product.Barcode));
					command.Parameters.Add(Db.Param("@Name", product.Name));
					command.Parameters.Add(Db.Param("@CategoryId", product.CategoryId));
					command.Parameters.Add(Db.Param("@Price", product.Price));
					command.Parameters.Add(Db.Param("@Cost", product.Cost));
					command.Parameters.Add(Db.Param("@ReorderLevel", product.ReorderLevel));
					command.Parameters.Add(Db.Param("@IsActive", product.IsActive));
					command.Parameters.Add(Db.Param("@ImagePath", product.ImagePath));
					command.ExecuteNonQuery();
					return product.Id;
				}
			}
		}

		// Soft delete: keeps sales history intact.
		public void Deactivate(int productId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Product_Delete"))
			{
				command.Parameters.Add(Db.Param("@ProductId", productId));
				command.ExecuteNonQuery();
			}
		}
	}

	public sealed class InventoryRepository
	{
		// Returns the new stock level.
		public int Adjust(int productId, int changeQty, string reason, int userId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Inventory_Adjust"))
			{
				command.Parameters.Add(Db.Param("@ProductId", productId));
				command.Parameters.Add(Db.Param("@ChangeQty", changeQty));
				command.Parameters.Add(Db.Param("@Reason", reason));
				command.Parameters.Add(Db.Param("@UserId", userId));
				return Convert.ToInt32(command.ExecuteScalar());
			}
		}
	}

	public sealed class OrderRepository
	{
		// Sends the cart to usp_Order_Create. Prices and stock are checked in SQL Server.
		// Returns the new order ID.
		public int Create(int userId, int? customerId, string paymentMethod,
						  decimal discountAmount, decimal taxRate, decimal amountPaid,
						  IList<CartLine> lines)
		{
			if (lines == null || lines.Count == 0)
				throw new ArgumentException("The cart is empty.");

			var xml = new StringBuilder("<Items>");
			foreach (var line in lines)
			{
				xml.Append(string.Format(CultureInfo.InvariantCulture,
					"<Item ProductId=\"{0}\" Quantity=\"{1}\"/>", line.ProductId, line.Quantity));
			}
			xml.Append("</Items>");

			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Order_Create"))
			{
				command.Parameters.Add(Db.Param("@UserId", userId));
				command.Parameters.Add(Db.Param("@CustomerId", customerId));
				command.Parameters.Add(Db.Param("@PaymentMethod", paymentMethod));
				command.Parameters.Add(Db.Param("@DiscountAmount", discountAmount));
				command.Parameters.Add(Db.Param("@TaxRate", taxRate));
				command.Parameters.Add(Db.Param("@AmountPaid", amountPaid));
				command.Parameters.Add(new SqlParameter("@ItemsXml", SqlDbType.Xml) { Value = xml.ToString() });
				return Convert.ToInt32(command.ExecuteScalar());
			}
		}

		// Loads an order header and its lines, for receipts and reprints.
		public Order GetById(int orderId)
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Order_Get"))
			{
				command.Parameters.Add(Db.Param("@OrderId", orderId));
				using (var r = command.ExecuteReader())
				{
					if (!r.Read()) return null;

					var order = new Order
					{
						Id = (int)r["OrderId"],
						OrderNumber = (string)r["OrderNumber"],
						CustomerId = Col.Int(r, "CustomerId"),
						UserId = (int)r["UserId"],
						OrderDate = (DateTime)r["OrderDate"],
						Subtotal = (decimal)r["Subtotal"],
						TaxAmount = (decimal)r["TaxAmount"],
						DiscountAmount = (decimal)r["DiscountAmount"],
						Total = (decimal)r["Total"],
						PaymentMethod = (string)r["PaymentMethod"],
						AmountPaid = (decimal)r["AmountPaid"],
						ChangeDue = (decimal)r["ChangeDue"],
						Status = (string)r["Status"]
					};

					if (r.NextResult())
					{
						while (r.Read())
						{
							order.Lines.Add(new OrderDetail
							{
								OrderDetailId = (int)r["OrderDetailId"],
								OrderId = (int)r["OrderId"],
								ProductId = (int)r["ProductId"],
								ProductName = (string)r["ProductName"],
								Quantity = (int)r["Quantity"],
								UnitPrice = (decimal)r["UnitPrice"],
								LineTotal = (decimal)r["LineTotal"]
							});
						}
					}
					return order;
				}
			}
		}

		// Lists the newest orders for the dashboard.
		public List<RecentOrderItem> GetRecent(int count)
		{
			var list = new List<RecentOrderItem>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Order_Recent"))
			{
				command.Parameters.Add(Db.Param("@Top", count));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new RecentOrderItem
						{
							OrderId = (int)r["OrderId"],
							OrderNumber = (string)r["OrderNumber"],
							OrderDate = (DateTime)r["OrderDate"],
							Total = (decimal)r["Total"],
							PaymentMethod = (string)r["PaymentMethod"],
							Status = (string)r["Status"],
							CashierName = (string)r["CashierName"]
						});
					}
				}
			}
			return list;
		}
	}

	public sealed class ReportRepository
	{
		public DashboardSummary Dashboard()
		{
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_Dashboard"))
			using (var r = command.ExecuteReader())
			{
				if (!r.Read()) return new DashboardSummary();
				return new DashboardSummary
				{
					TodaySales = (decimal)r["TodaySales"],
					TodayOrders = (int)r["TodayOrders"],
					LowStockCount = (int)r["LowStockCount"],
					ActiveProducts = (int)r["ActiveProducts"]
				};
			}
		}

		public List<DailySalesSummary> DailySales(DateTime from, DateTime to)
		{
			var list = new List<DailySalesSummary>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_DailySales"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new DailySalesSummary
						{
							SaleDate = (DateTime)r["SaleDate"],
							OrderCount = (int)r["OrderCount"],
							Revenue = (decimal)r["Revenue"]
						});
					}
				}
			}
			return list;
		}

		public List<TopProductSummary> TopProducts(DateTime from, DateTime to, int top)
		{
			var list = new List<TopProductSummary>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_TopProducts"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				command.Parameters.Add(Db.Param("@Top", top));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new TopProductSummary
						{
							ProductName = (string)r["ProductName"],
							QtySold = (int)r["QtySold"],
							Revenue = (decimal)r["Revenue"]
						});
					}
				}
			}
			return list;
		}

		public List<CategorySalesSummary> SalesByCategory(DateTime from, DateTime to)
		{
			var list = new List<CategorySalesSummary>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_SalesByCategory"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new CategorySalesSummary
						{
							CategoryName = (string)r["CategoryName"],
							Revenue = (decimal)r["Revenue"]
						});
					}
				}
			}
			return list;
		}

		public List<LowStockItem> LowStock()
		{
			var list = new List<LowStockItem>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_LowStock"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new LowStockItem
					{
						ProductId = (int)r["ProductId"],
						Sku = (string)r["Sku"],
						Name = (string)r["Name"],
						StockQty = (int)r["StockQty"],
						ReorderLevel = (int)r["ReorderLevel"]
					});
				}
			}
			return list;
		}
	}
}