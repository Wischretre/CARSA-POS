using System;
using System.Windows.Forms;
using CarSaPOS.Data;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class MainForm : Form
	{
		private readonly ReportingService reporting = new ReportingService();

		public MainForm()
		{
			InitializeComponent();

			_btnDashboard.Click += (s, e) => ShowScreen("Dashboard");
			_btnPos.Click += (s, e) => OpenCheckout();
			_btnInventory.Click += (s, e) => OpenProductForm();
			_btnAnalytics.Click += (s, e) => OpenAnalytics();
			_btnUsers.Click += (s, e) => OpenUserAdmin();
			_btnLogout.Click += (s, e) => Close();
			Load += (s, e) => ShowScreen("Dashboard");

			ApplyUserInfo();
			ApplyRoleVisibility();
		}

		private void ApplyUserInfo()
		{
			User user = Session.CurrentUser;
			_lblUser.Text = user == null
				? "Not signed in"
				: user.FullName + "\n" + user.Role;
		}

		private void ApplyRoleVisibility()
		{
			User user = Session.CurrentUser;
			UserRole? role = user == null ? (UserRole?)null : user.Role;

			bool isAdmin = role == UserRole.Admin;
			bool isCashier = role == UserRole.Cashier;

			_btnUsers.Visible = isAdmin;
			_btnInventory.Visible = !isCashier;
			_btnAnalytics.Visible = !isCashier;
		}

		private void ShowScreen(string name)
		{
			bool isDashboard = name == "Dashboard";
			_dashboardPanel.Visible = isDashboard;
			_placeholder.Visible = !isDashboard;
			_placeholderTitle.Text = name;

			if (isDashboard)
			{
				LoadDashboard();
			}
		}

		private void OpenProductForm()
		{
			using (var products = new ProductForm())
			{
				products.ShowDialog(this);
			}
		}

		private void OpenCheckout()
		{
			using (var checkout = new CheckoutForm())
			{
				checkout.ShowDialog(this);
			}
		}

		private void OpenAnalytics()
		{
			try
			{
				using (var analytics = new AnalyticsForm())
				{
					analytics.ShowDialog(this);
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show(ex.Message, "CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void OpenUserAdmin()
		{
			try
			{
				using (var users = new UserAdminForm())
				{
					users.ShowDialog(this);
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show(ex.Message, "CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void LoadDashboard()
		{
			try
			{
				DashboardSummary summary = reporting.Dashboard();
				_lblSalesValue.Text = summary.TodaySales.ToString("N2");
				_lblOrdersValue.Text = summary.TodayOrders.ToString();
				_lblLowStockValue.Text = summary.LowStockCount.ToString();
				_lblProductsValue.Text = summary.ActiveProducts.ToString();

				_gridRecent.DataSource = reporting.RecentOrders();

				bool canSeeLowStock = Session.CurrentUser != null &&
					(Session.CurrentUser.Role == UserRole.Admin ||
					 Session.CurrentUser.Role == UserRole.Manager);

				_lblLowStockNote.Visible = !canSeeLowStock;
				_gridLowStock.Visible = canSeeLowStock;
				_lblLowStockHeading.Visible = canSeeLowStock;

				if (canSeeLowStock)
				{
					_gridLowStock.DataSource = reporting.LowStock();
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show(ex.Message, "CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception)
			{
				MessageBox.Show("Unable to load the dashboard. Contact the administrator.",
					"CarSaPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}