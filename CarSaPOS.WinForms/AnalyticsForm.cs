using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class AnalyticsForm : Form
	{
		private const int TopCount = 10;
		private readonly AnalyticsService _analytics = new AnalyticsService();

		public AnalyticsForm()
		{
			InitializeComponent();

			ConfigureGrid(_gridDaily);
			ConfigureGrid(_gridProducts);
			ConfigureGrid(_gridCashier);
			ConfigureGrid(_gridCategory);
			ConfigureGrid(_gridInventory);

			Load += OnLoad;
			_btnRefresh.Click += (s, e) => RefreshAll();
			_btnExport.Click += (s, e) => ExportCurrent();
			_btnClose.Click += (s, e) => Close();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (DesignMode) return;

			_dtpFrom.Value = DateTime.Today.AddDays(-29);
			_dtpTo.Value = DateTime.Today;
			RefreshAll();
		}

		private void RefreshAll()
		{
			var from = _dtpFrom.Value.Date;
			var to = _dtpTo.Value.Date;

			if (to < from)
			{
				SetStatus("The end date must be on or after the start date.");
				return;
			}

			try
			{
				var daily = _analytics.SalesByDay(from, to);
				_gridDaily.DataSource = daily;
				SetFormat(_gridDaily, "yyyy-MM-dd", "SaleDay");
				SetFormat(_gridDaily, "N2", "GrossSales", "Discounts", "TaxTotal", "NetSales");

				_gridProducts.DataSource = _analytics.TopProducts(from, to, TopCount);
				SetFormat(_gridProducts, "N2", "Revenue");

				_gridCashier.DataSource = _analytics.SalesByCashier(from, to);
				SetFormat(_gridCashier, "N2", "NetSales");

				_gridCategory.DataSource = _analytics.SalesByCategory(from, to);
				SetFormat(_gridCategory, "N2", "Revenue");

				_gridInventory.DataSource = _analytics.InventoryValuation();
				SetFormat(_gridInventory, "N2", "Cost", "Price", "CostValue", "RetailValue");

				int orders = daily.Sum(x => x.OrderCount);
				decimal net = daily.Sum(x => x.NetSales);
				SetStatus(string.Format(CultureInfo.InvariantCulture,
					"Orders: {0}    Net sales: {1:N2}    Range: {2:yyyy-MM-dd} to {3:yyyy-MM-dd}",
					orders, net, from, to));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Sales Analytics", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void ExportCurrent()
		{
			var grid = CurrentGrid();
			if (grid == null || grid.Rows.Count == 0)
			{
				MessageBox.Show("Nothing to export yet. Click Refresh first.", "Export CSV");
				return;
			}

			using (var dialog = new SaveFileDialog { Filter = "CSV file (*.csv)|*.csv", FileName = "sales-report.csv" })
			{
				if (dialog.ShowDialog(this) != DialogResult.OK) return;

				var columns = grid.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
				var sb = new StringBuilder();
				sb.AppendLine(string.Join(",", columns.Select(c => Quote(c.HeaderText))));

				foreach (DataGridViewRow row in grid.Rows)
				{
					if (row.IsNewRow) continue;
					sb.AppendLine(string.Join(",", columns.Select(c =>
						Quote(Convert.ToString(row.Cells[c.Index].Value, CultureInfo.InvariantCulture)))));
				}

				File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
				SetStatus("Exported to " + dialog.FileName);
			}
		}

		private DataGridView CurrentGrid()
		{
			if (_tabs.SelectedTab == _tabDaily) return _gridDaily;
			if (_tabs.SelectedTab == _tabProducts) return _gridProducts;
			if (_tabs.SelectedTab == _tabCashier) return _gridCashier;
			if (_tabs.SelectedTab == _tabCategory) return _gridCategory;
			if (_tabs.SelectedTab == _tabInventory) return _gridInventory;
			return null;
		}

		private void SetStatus(string text)
		{
			_lblStatus.Text = text;
		}

		private static void ConfigureGrid(DataGridView grid)
		{
			grid.ReadOnly = true;
			grid.AllowUserToAddRows = false;
			grid.AllowUserToDeleteRows = false;
			grid.RowHeadersVisible = false;
			grid.MultiSelect = false;
			grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			grid.DataError += (s, e) => { e.ThrowException = false; };
		}

		private static void SetFormat(DataGridView grid, string format, params string[] columns)
		{
			foreach (var name in columns)
			{
				var column = grid.Columns[name];
				if (column != null) column.DefaultCellStyle.Format = format;
			}
		}

		private static string Quote(string value)
		{
			return "\"" + (value ?? string.Empty).Replace("\"", "\"\"") + "\"";
		}
	}
}