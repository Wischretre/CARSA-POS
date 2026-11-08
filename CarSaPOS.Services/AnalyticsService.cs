using System;
using System.Collections.Generic;
using CarSaPOS.Data;
using CarSaPOS.Domain;

namespace CarSaPOS.Services
{
	public sealed class AnalyticsService
	{
		public const int MaxRangeDays = 366;

		private readonly SalesReportRepository _reports = new SalesReportRepository();

		// Daily sales. The UI passes an inclusive "to" date; we convert it to exclusive for SQL.
		public List<SalesDaySummary> SalesByDay(DateTime from, DateTime to)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return _reports.SalesByDay(from.Date, to.Date.AddDays(1));
		}

		public List<SalesTopProductRow> TopProducts(DateTime from, DateTime to, int top)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			if (top < 1 || top > 100)
				throw new ArgumentException("Top must be between 1 and 100.");
			return _reports.TopProducts(from.Date, to.Date.AddDays(1), top);
		}

		public List<SalesCategoryRow> SalesByCategory(DateTime from, DateTime to)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return _reports.SalesByCategory(from.Date, to.Date.AddDays(1));
		}

		public List<SalesCashierRow> SalesByCashier(DateTime from, DateTime to)
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			ValidateRange(from, to);
			return _reports.SalesByCashier(from.Date, to.Date.AddDays(1));
		}

		// No date range: this reports current stock value.
		public List<InventoryValueRow> InventoryValuation()
		{
			Session.Require(UserRole.Admin, UserRole.Manager);
			return _reports.InventoryValuation();
		}

		private static void ValidateRange(DateTime from, DateTime to)
		{
			if (to.Date < from.Date)
				throw new ArgumentException("The end date must be on or after the start date.");
			if ((to.Date - from.Date).TotalDays > MaxRangeDays)
				throw new ArgumentException("The date range can be at most " + MaxRangeDays + " days.");
		}
	}
}