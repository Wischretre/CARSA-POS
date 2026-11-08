using System.Windows.Forms;

namespace CarSaPOS.WinForms
{
	partial class AnalyticsForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this._topPanel = new System.Windows.Forms.Panel();
			this._lblFrom = new System.Windows.Forms.Label();
			this._dtpFrom = new System.Windows.Forms.DateTimePicker();
			this._lblTo = new System.Windows.Forms.Label();
			this._dtpTo = new System.Windows.Forms.DateTimePicker();
			this._btnRefresh = new System.Windows.Forms.Button();
			this._btnExport = new System.Windows.Forms.Button();
			this._tabs = new System.Windows.Forms.TabControl();
			this._tabDaily = new System.Windows.Forms.TabPage();
			this._gridDaily = new System.Windows.Forms.DataGridView();
			this._tabProducts = new System.Windows.Forms.TabPage();
			this._gridProducts = new System.Windows.Forms.DataGridView();
			this._tabCashier = new System.Windows.Forms.TabPage();
			this._gridCashier = new System.Windows.Forms.DataGridView();
			this._tabCategory = new System.Windows.Forms.TabPage();
			this._gridCategory = new System.Windows.Forms.DataGridView();
			this._tabInventory = new System.Windows.Forms.TabPage();
			this._gridInventory = new System.Windows.Forms.DataGridView();
			this._bottomPanel = new System.Windows.Forms.Panel();
			this._lblStatus = new System.Windows.Forms.Label();
			this._btnClose = new System.Windows.Forms.Button();
			this._topPanel.SuspendLayout();
			this._tabs.SuspendLayout();
			this._tabDaily.SuspendLayout();
			this._tabProducts.SuspendLayout();
			this._tabCashier.SuspendLayout();
			this._tabCategory.SuspendLayout();
			this._tabInventory.SuspendLayout();
			this._bottomPanel.SuspendLayout();
			this.SuspendLayout();

			// _topPanel: date range and buttons
			this._topPanel.Controls.Add(this._lblFrom);
			this._topPanel.Controls.Add(this._dtpFrom);
			this._topPanel.Controls.Add(this._lblTo);
			this._topPanel.Controls.Add(this._dtpTo);
			this._topPanel.Controls.Add(this._btnRefresh);
			this._topPanel.Controls.Add(this._btnExport);
			this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._topPanel.Height = 56;
			this._topPanel.Name = "_topPanel";

			this._lblFrom.AutoSize = true;
			this._lblFrom.Location = new System.Drawing.Point(12, 18);
			this._lblFrom.Name = "_lblFrom";
			this._lblFrom.Text = "From:";

			this._dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this._dtpFrom.Location = new System.Drawing.Point(56, 14);
			this._dtpFrom.Name = "_dtpFrom";
			this._dtpFrom.Size = new System.Drawing.Size(130, 23);

			this._lblTo.AutoSize = true;
			this._lblTo.Location = new System.Drawing.Point(200, 18);
			this._lblTo.Name = "_lblTo";
			this._lblTo.Text = "To:";

			this._dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this._dtpTo.Location = new System.Drawing.Point(232, 14);
			this._dtpTo.Name = "_dtpTo";
			this._dtpTo.Size = new System.Drawing.Size(130, 23);

			this._btnRefresh.Location = new System.Drawing.Point(380, 12);
			this._btnRefresh.Name = "_btnRefresh";
			this._btnRefresh.Size = new System.Drawing.Size(90, 30);
			this._btnRefresh.Text = "Refresh";
			this._btnRefresh.UseVisualStyleBackColor = true;

			this._btnExport.Location = new System.Drawing.Point(478, 12);
			this._btnExport.Name = "_btnExport";
			this._btnExport.Size = new System.Drawing.Size(110, 30);
			this._btnExport.Text = "Export CSV";
			this._btnExport.UseVisualStyleBackColor = true;

			// _tabs: fills the middle. Added first so the docked top and bottom panels lay out correctly.
			this._tabs.Controls.Add(this._tabDaily);
			this._tabs.Controls.Add(this._tabProducts);
			this._tabs.Controls.Add(this._tabCashier);
			this._tabs.Controls.Add(this._tabCategory);
			this._tabs.Controls.Add(this._tabInventory);
			this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tabs.Name = "_tabs";

			this._tabDaily.Controls.Add(this._gridDaily);
			this._tabDaily.Name = "_tabDaily";
			this._tabDaily.Text = "Daily Sales";
			this._tabDaily.Padding = new System.Windows.Forms.Padding(3);

			this._tabProducts.Controls.Add(this._gridProducts);
			this._tabProducts.Name = "_tabProducts";
			this._tabProducts.Text = "Top Products";
			this._tabProducts.Padding = new System.Windows.Forms.Padding(3);

			this._tabCashier.Controls.Add(this._gridCashier);
			this._tabCashier.Name = "_tabCashier";
			this._tabCashier.Text = "By Cashier";
			this._tabCashier.Padding = new System.Windows.Forms.Padding(3);

			this._tabCategory.Controls.Add(this._gridCategory);
			this._tabCategory.Name = "_tabCategory";
			this._tabCategory.Text = "By Category";
			this._tabCategory.Padding = new System.Windows.Forms.Padding(3);

			this._tabInventory.Controls.Add(this._gridInventory);
			this._tabInventory.Name = "_tabInventory";
			this._tabInventory.Text = "Inventory Value";
			this._tabInventory.Padding = new System.Windows.Forms.Padding(3);

			this._gridDaily.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridDaily.Name = "_gridDaily";
			this._gridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridProducts.Name = "_gridProducts";
			this._gridCashier.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridCashier.Name = "_gridCashier";
			this._gridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridCategory.Name = "_gridCategory";
			this._gridInventory.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridInventory.Name = "_gridInventory";

			// _bottomPanel: status text and close button
			this._bottomPanel.Controls.Add(this._lblStatus);
			this._bottomPanel.Controls.Add(this._btnClose);
			this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._bottomPanel.Height = 44;
			this._bottomPanel.Name = "_bottomPanel";

			this._lblStatus.AutoSize = true;
			this._lblStatus.Location = new System.Drawing.Point(12, 14);
			this._lblStatus.Name = "_lblStatus";
			this._lblStatus.Text = "";

			this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnClose.Location = new System.Drawing.Point(880, 8);
			this._btnClose.Name = "_btnClose";
			this._btnClose.Size = new System.Drawing.Size(90, 28);
			this._btnClose.Text = "Close";
			this._btnClose.UseVisualStyleBackColor = true;

			// AnalyticsForm
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 620);
			this.Controls.Add(this._tabs);
			this.Controls.Add(this._bottomPanel);
			this.Controls.Add(this._topPanel);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "AnalyticsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sales Analytics";

			this._topPanel.ResumeLayout(false);
			this._topPanel.PerformLayout();
			this._tabDaily.ResumeLayout(false);
			this._tabProducts.ResumeLayout(false);
			this._tabCashier.ResumeLayout(false);
			this._tabCategory.ResumeLayout(false);
			this._tabInventory.ResumeLayout(false);
			this._tabs.ResumeLayout(false);
			this._bottomPanel.ResumeLayout(false);
			this._bottomPanel.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private Panel _topPanel;
		private Label _lblFrom;
		private DateTimePicker _dtpFrom;
		private Label _lblTo;
		private DateTimePicker _dtpTo;
		private Button _btnRefresh;
		private Button _btnExport;
		private TabControl _tabs;
		private TabPage _tabDaily;
		private TabPage _tabProducts;
		private TabPage _tabCashier;
		private TabPage _tabCategory;
		private TabPage _tabInventory;
		private DataGridView _gridDaily;
		private DataGridView _gridProducts;
		private DataGridView _gridCashier;
		private DataGridView _gridCategory;
		private DataGridView _gridInventory;
		private Panel _bottomPanel;
		private Label _lblStatus;
		private Button _btnClose;
	}
}