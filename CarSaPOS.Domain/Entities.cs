using System;
using System.Collections.Generic;

namespace CarSaPOS.Domain
{
	// Role IDs match the seed order in 01_CreateDatabase.sql:
	// Admin = 1, Manager = 2, Cashier = 3.
	public enum UserRole
	{
		Admin = 1,
		Manager = 2,
		Cashier = 3
	}

	public sealed class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string Salt { get; set; }
		public string FullName { get; set; }
		public UserRole Role { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastLoginAt { get; set; }
	}

	public sealed class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public sealed class Product
	{
		public int Id { get; set; }
		public string Sku { get; set; }
		public string Barcode { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public decimal Price { get; set; }
		public decimal Cost { get; set; }
		public int StockQty { get; set; }
		public int ReorderLevel { get; set; }
		// Relative path such as "products\<guid>.jpg", or null when there is no image.
		public string ImagePath { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public bool IsLowStock
		{
			get { return StockQty <= ReorderLevel; }
		}
	}

	public sealed class Customer
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public DateTime CreatedAt { get; set; }
	}

	// One item in the shopping cart, before the order is saved.
	public sealed class CartLine
	{
		public int ProductId { get; set; }
		public string Sku { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		public decimal LineTotal
		{
			get { return Quantity * UnitPrice; }
		}
	}

	// One saved line of a completed order.
	public sealed class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal LineTotal { get; set; }
	}

	public sealed class Order
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public int? CustomerId { get; set; }
		public int UserId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Subtotal { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal Total { get; set; }
		public string PaymentMethod { get; set; }   // "Cash", "Card" or "Mobile"
		public decimal AmountPaid { get; set; }
		public decimal ChangeDue { get; set; }
		public string Status { get; set; }          // "Completed" or "Voided"
		public List<OrderDetail> Lines { get; set; }

		public Order()
		{
			Lines = new List<OrderDetail>();
		}
	}

	public sealed class InventoryLogEntry
	{
		public int LogId { get; set; }
		public int ProductId { get; set; }
		public int ChangeQty { get; set; }
		public string Reason { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedAt { get; set; }
	}

	// Report rows returned by the usp_Report_* procedures.
	public sealed class DailySalesSummary
	{
		public DateTime SaleDate { get; set; }
		public int OrderCount { get; set; }
		public decimal Revenue { get; set; }
	}

	public sealed class TopProductSummary
	{
		public string ProductName { get; set; }
		public int QtySold { get; set; }
		public decimal Revenue { get; set; }
	}

	public sealed class CategorySalesSummary
	{
		public string CategoryName { get; set; }
		public decimal Revenue { get; set; }
	}

	public sealed class LowStockItem
	{
		public int ProductId { get; set; }
		public string Sku { get; set; }
		public string Name { get; set; }
		public int StockQty { get; set; }
		public int ReorderLevel { get; set; }
	}
}