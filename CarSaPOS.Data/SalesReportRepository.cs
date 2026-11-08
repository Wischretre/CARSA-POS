using System;
using System.Collections.Generic;

namespace CarSaPOS.Data
{
	// One row of the Sales Analytics report: one sale day.
	public sealed class SalesDaySummary
	{
		public DateTime SaleDay { get; set; }
		public int OrderCount { get; set; }
		public decimal GrossSales { get; set; }
		public decimal Discounts { get; set; }
		public decimal TaxTotal { get; set; }
		public decimal NetSales { get; set; }
	}

	// One row of the Top Products report.
	public sealed class SalesTopProductRow
	{
		public string ProductName { get; set; }
		public int QtySold { get; set; }
		public decimal Revenue { get; set; }
	}

	// One row of the Sales by Category report.
	public sealed class SalesCategoryRow
	{
		public string CategoryName { get; set; }
		public decimal Revenue { get; set; }
	}

	// One row of the Sales by Cashier report.
	public sealed class SalesCashierRow
	{
		public string CashierName { get; set; }
		public int OrderCount { get; set; }
		public decimal NetSales { get; set; }
	}

	// One row of the Inventory Valuation report.
	public sealed class InventoryValueRow
	{
		public string Sku { get; set; }
		public string Name { get; set; }
		public int StockQty { get; set; }
		public decimal Cost { get; set; }
		public decimal Price { get; set; }
		public decimal CostValue { get; set; }
		public decimal RetailValue { get; set; }
	}

	public sealed class SalesReportRepository
	{
		// Calls usp_Report_Sales. @To is exclusive, so pass the day after the last day in the range.
		public List<SalesDaySummary> SalesByDay(DateTime from, DateTime to)
		{
			var list = new List<SalesDaySummary>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_Sales"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new SalesDaySummary
						{
							SaleDay = (DateTime)r["SaleDay"],
							OrderCount = (int)r["OrderCount"],
							GrossSales = (decimal)r["GrossSales"],
							Discounts = (decimal)r["Discounts"],
							TaxTotal = (decimal)r["TaxTotal"],
							NetSales = (decimal)r["NetSales"]
						});
					}
				}
			}
			return list;
		}

		// Calls usp_Report_TopProducts. @To is exclusive.
		public List<SalesTopProductRow> TopProducts(DateTime from, DateTime to, int top)
		{
			var list = new List<SalesTopProductRow>();
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
						list.Add(new SalesTopProductRow
						{
							ProductName = Convert.ToString(r["ProductName"]),
							QtySold = Convert.ToInt32(r["QtySold"]),
							Revenue = Convert.ToDecimal(r["Revenue"])
						});
					}
				}
			}
			return list;
		}

		// Calls usp_Report_SalesByCategory. @To is exclusive.
		public List<SalesCategoryRow> SalesByCategory(DateTime from, DateTime to)
		{
			var list = new List<SalesCategoryRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_SalesByCategory"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new SalesCategoryRow
						{
							CategoryName = Convert.ToString(r["CategoryName"]),
							Revenue = Convert.ToDecimal(r["Revenue"])
						});
					}
				}
			}
			return list;
		}

		// Calls usp_Report_SalesByCashier. @To is exclusive.
		public List<SalesCashierRow> SalesByCashier(DateTime from, DateTime to)
		{
			var list = new List<SalesCashierRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_SalesByCashier"))
			{
				command.Parameters.Add(Db.Param("@From", from));
				command.Parameters.Add(Db.Param("@To", to));
				using (var r = command.ExecuteReader())
				{
					while (r.Read())
					{
						list.Add(new SalesCashierRow
						{
							CashierName = Convert.ToString(r["CashierName"]),
							OrderCount = Convert.ToInt32(r["OrderCount"]),
							NetSales = Convert.ToDecimal(r["NetSales"])
						});
					}
				}
			}
			return list;
		}

		// Calls usp_Report_InventoryValuation. No date range, because it reflects current stock.
		public List<InventoryValueRow> InventoryValuation()
		{
			var list = new List<InventoryValueRow>();
			using (var connection = Db.Open())
			using (var command = Db.Procedure(connection, "dbo.usp_Report_InventoryValuation"))
			using (var r = command.ExecuteReader())
			{
				while (r.Read())
				{
					list.Add(new InventoryValueRow
					{
						Sku = Convert.ToString(r["Sku"]),
						Name = Convert.ToString(r["Name"]),
						StockQty = Convert.ToInt32(r["StockQty"]),
						Cost = Convert.ToDecimal(r["Cost"]),
						Price = Convert.ToDecimal(r["Price"]),
						CostValue = Convert.ToDecimal(r["CostValue"]),
						RetailValue = Convert.ToDecimal(r["RetailValue"])
					});
				}
			}
			return list;
		}
	}
}