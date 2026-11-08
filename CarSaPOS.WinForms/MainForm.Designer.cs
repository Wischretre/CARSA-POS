namespace CarSaPOS.WinForms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._sidebar = new System.Windows.Forms.Panel();
			this._navPanel = new System.Windows.Forms.FlowLayoutPanel();
			this._btnDashboard = new System.Windows.Forms.Button();
			this._btnPos = new System.Windows.Forms.Button();
			this._btnInventory = new System.Windows.Forms.Button();
			this._btnAnalytics = new System.Windows.Forms.Button();
			this._btnUsers = new System.Windows.Forms.Button();
			this._logoutPanel = new System.Windows.Forms.Panel();
			this._btnLogout = new System.Windows.Forms.Button();
			this._userPanel = new System.Windows.Forms.Panel();
			this._lblUser = new System.Windows.Forms.Label();
			this._brandPanel = new System.Windows.Forms.Panel();
			this._brandLabel = new System.Windows.Forms.Label();
			this._content = new System.Windows.Forms.Panel();
			this._dashboardPanel = new System.Windows.Forms.Panel();
			this._bodyLayout = new System.Windows.Forms.TableLayoutPanel();
			this._lblLowStockHeading = new System.Windows.Forms.Label();
			this._lblRecentHeading = new System.Windows.Forms.Label();
			this._lblLowStockNote = new System.Windows.Forms.Label();
			this._gridLowStock = new System.Windows.Forms.DataGridView();
			this._gridRecent = new System.Windows.Forms.DataGridView();
			this._cardsLayout = new System.Windows.Forms.TableLayoutPanel();
			this._cardSales = new System.Windows.Forms.Panel();
			this._lblSalesTitle = new System.Windows.Forms.Label();
			this._lblSalesValue = new System.Windows.Forms.Label();
			this._cardOrders = new System.Windows.Forms.Panel();
			this._lblOrdersTitle = new System.Windows.Forms.Label();
			this._lblOrdersValue = new System.Windows.Forms.Label();
			this._cardLowStock = new System.Windows.Forms.Panel();
			this._lblLowStockTitle = new System.Windows.Forms.Label();
			this._lblLowStockValue = new System.Windows.Forms.Label();
			this._cardProducts = new System.Windows.Forms.Panel();
			this._lblProductsTitle = new System.Windows.Forms.Label();
			this._lblProductsValue = new System.Windows.Forms.Label();
			this._lblDashboardTitle = new System.Windows.Forms.Label();
			this._placeholder = new System.Windows.Forms.Panel();
			this._placeholderMessage = new System.Windows.Forms.Label();
			this._placeholderTitle = new System.Windows.Forms.Label();
			this._sidebar.SuspendLayout();
			this._navPanel.SuspendLayout();
			this._logoutPanel.SuspendLayout();
			this._userPanel.SuspendLayout();
			this._brandPanel.SuspendLayout();
			this._content.SuspendLayout();
			this._dashboardPanel.SuspendLayout();
			this._bodyLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridLowStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._gridRecent)).BeginInit();
			this._cardsLayout.SuspendLayout();
			this._cardSales.SuspendLayout();
			this._cardOrders.SuspendLayout();
			this._cardLowStock.SuspendLayout();
			this._cardProducts.SuspendLayout();
			this._placeholder.SuspendLayout();
			this.SuspendLayout();
			// 
			// _sidebar
			// 
			this._sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
			this._sidebar.Controls.Add(this._navPanel);
			this._sidebar.Controls.Add(this._logoutPanel);
			this._sidebar.Controls.Add(this._userPanel);
			this._sidebar.Controls.Add(this._brandPanel);
			this._sidebar.Dock = System.Windows.Forms.DockStyle.Left;
			this._sidebar.Location = new System.Drawing.Point(0, 0);
			this._sidebar.Name = "_sidebar";
			this._sidebar.Size = new System.Drawing.Size(220, 737);
			this._sidebar.TabIndex = 1;
			// 
			// _navPanel
			// 
			this._navPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
			this._navPanel.Controls.Add(this._btnDashboard);
			this._navPanel.Controls.Add(this._btnPos);
			this._navPanel.Controls.Add(this._btnInventory);
			this._navPanel.Controls.Add(this._btnAnalytics);
			this._navPanel.Controls.Add(this._btnUsers);
			this._navPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._navPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._navPanel.Location = new System.Drawing.Point(0, 70);
			this._navPanel.Name = "_navPanel";
			this._navPanel.Size = new System.Drawing.Size(220, 551);
			this._navPanel.TabIndex = 0;
			this._navPanel.WrapContents = false;
			// 
			// _btnDashboard
			// 
			this._btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnDashboard.FlatAppearance.BorderSize = 0;
			this._btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnDashboard.ForeColor = System.Drawing.Color.White;
			this._btnDashboard.Location = new System.Drawing.Point(0, 0);
			this._btnDashboard.Margin = new System.Windows.Forms.Padding(0);
			this._btnDashboard.Name = "_btnDashboard";
			this._btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnDashboard.Size = new System.Drawing.Size(220, 48);
			this._btnDashboard.TabIndex = 0;
			this._btnDashboard.Text = "Dashboard";
			this._btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnDashboard.UseVisualStyleBackColor = true;
			// 
			// _btnPos
			// 
			this._btnPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnPos.FlatAppearance.BorderSize = 0;
			this._btnPos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnPos.ForeColor = System.Drawing.Color.White;
			this._btnPos.Location = new System.Drawing.Point(0, 48);
			this._btnPos.Margin = new System.Windows.Forms.Padding(0);
			this._btnPos.Name = "_btnPos";
			this._btnPos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnPos.Size = new System.Drawing.Size(220, 48);
			this._btnPos.TabIndex = 1;
			this._btnPos.Text = "Point of Sale";
			this._btnPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnPos.UseVisualStyleBackColor = true;
			// 
			// _btnInventory
			// 
			this._btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnInventory.FlatAppearance.BorderSize = 0;
			this._btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnInventory.ForeColor = System.Drawing.Color.White;
			this._btnInventory.Location = new System.Drawing.Point(0, 96);
			this._btnInventory.Margin = new System.Windows.Forms.Padding(0);
			this._btnInventory.Name = "_btnInventory";
			this._btnInventory.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnInventory.Size = new System.Drawing.Size(220, 48);
			this._btnInventory.TabIndex = 2;
			this._btnInventory.Text = "Inventory";
			this._btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnInventory.UseVisualStyleBackColor = true;
			// 
			// _btnAnalytics
			// 
			this._btnAnalytics.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnAnalytics.FlatAppearance.BorderSize = 0;
			this._btnAnalytics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnAnalytics.ForeColor = System.Drawing.Color.White;
			this._btnAnalytics.Location = new System.Drawing.Point(0, 144);
			this._btnAnalytics.Margin = new System.Windows.Forms.Padding(0);
			this._btnAnalytics.Name = "_btnAnalytics";
			this._btnAnalytics.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnAnalytics.Size = new System.Drawing.Size(220, 48);
			this._btnAnalytics.TabIndex = 3;
			this._btnAnalytics.Text = "Sales Analytics";
			this._btnAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnAnalytics.UseVisualStyleBackColor = true;
			// 
			// _btnUsers
			// 
			this._btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnUsers.FlatAppearance.BorderSize = 0;
			this._btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnUsers.ForeColor = System.Drawing.Color.White;
			this._btnUsers.Location = new System.Drawing.Point(0, 192);
			this._btnUsers.Margin = new System.Windows.Forms.Padding(0);
			this._btnUsers.Name = "_btnUsers";
			this._btnUsers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnUsers.Size = new System.Drawing.Size(220, 48);
			this._btnUsers.TabIndex = 4;
			this._btnUsers.Text = "Users && Roles";
			this._btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnUsers.UseVisualStyleBackColor = true;
			// 
			// _logoutPanel
			// 
			this._logoutPanel.Controls.Add(this._btnLogout);
			this._logoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._logoutPanel.Location = new System.Drawing.Point(0, 621);
			this._logoutPanel.Name = "_logoutPanel";
			this._logoutPanel.Size = new System.Drawing.Size(220, 56);
			this._logoutPanel.TabIndex = 1;
			// 
			// _btnLogout
			// 
			this._btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
			this._btnLogout.FlatAppearance.BorderSize = 0;
			this._btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this._btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnLogout.ForeColor = System.Drawing.Color.White;
			this._btnLogout.Location = new System.Drawing.Point(0, 0);
			this._btnLogout.Name = "_btnLogout";
			this._btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this._btnLogout.Size = new System.Drawing.Size(220, 56);
			this._btnLogout.TabIndex = 0;
			this._btnLogout.Text = "Log out";
			this._btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._btnLogout.UseVisualStyleBackColor = true;
			// 
			// _userPanel
			// 
			this._userPanel.Controls.Add(this._lblUser);
			this._userPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._userPanel.Location = new System.Drawing.Point(0, 677);
			this._userPanel.Name = "_userPanel";
			this._userPanel.Size = new System.Drawing.Size(220, 60);
			this._userPanel.TabIndex = 2;
			// 
			// _lblUser
			// 
			this._lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblUser.ForeColor = System.Drawing.Color.Gainsboro;
			this._lblUser.Location = new System.Drawing.Point(0, 0);
			this._lblUser.Name = "_lblUser";
			this._lblUser.Padding = new System.Windows.Forms.Padding(20, 8, 0, 0);
			this._lblUser.Size = new System.Drawing.Size(220, 60);
			this._lblUser.TabIndex = 0;
			this._lblUser.Text = "Not signed in";
			// 
			// _brandPanel
			// 
			this._brandPanel.Controls.Add(this._brandLabel);
			this._brandPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._brandPanel.Location = new System.Drawing.Point(0, 0);
			this._brandPanel.Name = "_brandPanel";
			this._brandPanel.Size = new System.Drawing.Size(220, 70);
			this._brandPanel.TabIndex = 3;
			// 
			// _brandLabel
			// 
			this._brandLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._brandLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this._brandLabel.ForeColor = System.Drawing.Color.White;
			this._brandLabel.Location = new System.Drawing.Point(0, 0);
			this._brandLabel.Name = "_brandLabel";
			this._brandLabel.Padding = new System.Windows.Forms.Padding(20, 16, 0, 0);
			this._brandLabel.Size = new System.Drawing.Size(220, 70);
			this._brandLabel.TabIndex = 0;
			this._brandLabel.Text = "CarSaPOS";
			// 
			// _content
			// 
			this._content.Controls.Add(this._dashboardPanel);
			this._content.Controls.Add(this._placeholder);
			this._content.Dock = System.Windows.Forms.DockStyle.Fill;
			this._content.Location = new System.Drawing.Point(220, 0);
			this._content.Name = "_content";
			this._content.Padding = new System.Windows.Forms.Padding(24);
			this._content.Size = new System.Drawing.Size(1454, 737);
			this._content.TabIndex = 0;
			// 
			// _dashboardPanel
			// 
			this._dashboardPanel.Controls.Add(this._bodyLayout);
			this._dashboardPanel.Controls.Add(this._cardsLayout);
			this._dashboardPanel.Controls.Add(this._lblDashboardTitle);
			this._dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._dashboardPanel.Location = new System.Drawing.Point(24, 24);
			this._dashboardPanel.Name = "_dashboardPanel";
			this._dashboardPanel.Size = new System.Drawing.Size(1406, 689);
			this._dashboardPanel.TabIndex = 1;
			// 
			// _bodyLayout
			// 
			this._bodyLayout.ColumnCount = 2;
			this._bodyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this._bodyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this._bodyLayout.Controls.Add(this._lblLowStockHeading, 0, 0);
			this._bodyLayout.Controls.Add(this._lblRecentHeading, 1, 0);
			this._bodyLayout.Controls.Add(this._lblLowStockNote, 0, 1);
			this._bodyLayout.Controls.Add(this._gridLowStock, 0, 1);
			this._bodyLayout.Controls.Add(this._gridRecent, 1, 1);
			this._bodyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this._bodyLayout.Location = new System.Drawing.Point(0, 132);
			this._bodyLayout.Name = "_bodyLayout";
			this._bodyLayout.RowCount = 2;
			this._bodyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._bodyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._bodyLayout.Size = new System.Drawing.Size(1406, 557);
			this._bodyLayout.TabIndex = 0;
			// 
			// _lblLowStockHeading
			// 
			this._lblLowStockHeading.AutoSize = true;
			this._lblLowStockHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this._lblLowStockHeading.Location = new System.Drawing.Point(0, 12);
			this._lblLowStockHeading.Margin = new System.Windows.Forms.Padding(0, 12, 0, 6);
			this._lblLowStockHeading.Name = "_lblLowStockHeading";
			this._lblLowStockHeading.Size = new System.Drawing.Size(147, 20);
			this._lblLowStockHeading.TabIndex = 5;
			this._lblLowStockHeading.Text = "Low-stock products";
			// 
			// _lblRecentHeading
			// 
			this._lblRecentHeading.AutoSize = true;
			this._lblRecentHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this._lblRecentHeading.Location = new System.Drawing.Point(562, 12);
			this._lblRecentHeading.Margin = new System.Windows.Forms.Padding(0, 12, 0, 6);
			this._lblRecentHeading.Name = "_lblRecentHeading";
			this._lblRecentHeading.Size = new System.Drawing.Size(147, 20);
			this._lblRecentHeading.TabIndex = 8;
			this._lblRecentHeading.Text = "Recent transactions";
			// 
			// _lblLowStockNote
			// 
			this._lblLowStockNote.AutoSize = true;
			this._lblLowStockNote.Dock = System.Windows.Forms.DockStyle.Top;
			this._lblLowStockNote.ForeColor = System.Drawing.Color.Gray;
			this._lblLowStockNote.Location = new System.Drawing.Point(565, 38);
			this._lblLowStockNote.Name = "_lblLowStockNote";
			this._lblLowStockNote.Size = new System.Drawing.Size(838, 19);
			this._lblLowStockNote.TabIndex = 7;
			this._lblLowStockNote.Text = "Low-stock details are available to Admins and Managers.";
			this._lblLowStockNote.Visible = false;
			// 
			// _gridLowStock
			// 
			this._gridLowStock.AllowUserToAddRows = false;
			this._gridLowStock.AllowUserToDeleteRows = false;
			this._gridLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this._gridLowStock.BackgroundColor = System.Drawing.Color.White;
			this._gridLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._gridLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridLowStock.Location = new System.Drawing.Point(0, 38);
			this._gridLowStock.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this._gridLowStock.Name = "_gridLowStock";
			this._gridLowStock.ReadOnly = true;
			this._gridLowStock.RowHeadersVisible = false;
			this._gridLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._gridLowStock.Size = new System.Drawing.Size(550, 363);
			this._gridLowStock.TabIndex = 6;
			// 
			// _gridRecent
			// 
			this._gridRecent.AllowUserToAddRows = false;
			this._gridRecent.AllowUserToDeleteRows = false;
			this._gridRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this._gridRecent.BackgroundColor = System.Drawing.Color.White;
			this._gridRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._gridRecent.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridRecent.Location = new System.Drawing.Point(3, 404);
			this._gridRecent.Name = "_gridRecent";
			this._gridRecent.ReadOnly = true;
			this._gridRecent.RowHeadersVisible = false;
			this._gridRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._gridRecent.Size = new System.Drawing.Size(556, 150);
			this._gridRecent.TabIndex = 9;
			// 
			// _cardsLayout
			// 
			this._cardsLayout.ColumnCount = 4;
			this._cardsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._cardsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._cardsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._cardsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._cardsLayout.Controls.Add(this._cardSales, 0, 0);
			this._cardsLayout.Controls.Add(this._cardOrders, 1, 0);
			this._cardsLayout.Controls.Add(this._cardLowStock, 2, 0);
			this._cardsLayout.Controls.Add(this._cardProducts, 3, 0);
			this._cardsLayout.Dock = System.Windows.Forms.DockStyle.Top;
			this._cardsLayout.Location = new System.Drawing.Point(0, 32);
			this._cardsLayout.Name = "_cardsLayout";
			this._cardsLayout.RowCount = 1;
			this._cardsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._cardsLayout.Size = new System.Drawing.Size(1406, 100);
			this._cardsLayout.TabIndex = 1;
			// 
			// _cardSales
			// 
			this._cardSales.BackColor = System.Drawing.Color.White;
			this._cardSales.Controls.Add(this._lblSalesTitle);
			this._cardSales.Controls.Add(this._lblSalesValue);
			this._cardSales.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cardSales.Location = new System.Drawing.Point(0, 0);
			this._cardSales.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this._cardSales.Name = "_cardSales";
			this._cardSales.Size = new System.Drawing.Size(339, 100);
			this._cardSales.TabIndex = 0;
			// 
			// _lblSalesTitle
			// 
			this._lblSalesTitle.AutoSize = true;
			this._lblSalesTitle.ForeColor = System.Drawing.Color.Gray;
			this._lblSalesTitle.Location = new System.Drawing.Point(12, 10);
			this._lblSalesTitle.Name = "_lblSalesTitle";
			this._lblSalesTitle.Size = new System.Drawing.Size(125, 19);
			this._lblSalesTitle.TabIndex = 0;
			this._lblSalesTitle.Text = "Today\'s sales (PHP)";
			// 
			// _lblSalesValue
			// 
			this._lblSalesValue.AutoSize = true;
			this._lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._lblSalesValue.Location = new System.Drawing.Point(12, 34);
			this._lblSalesValue.Name = "_lblSalesValue";
			this._lblSalesValue.Size = new System.Drawing.Size(63, 32);
			this._lblSalesValue.TabIndex = 1;
			this._lblSalesValue.Text = "0.00";
			// 
			// _cardOrders
			// 
			this._cardOrders.BackColor = System.Drawing.Color.White;
			this._cardOrders.Controls.Add(this._lblOrdersTitle);
			this._cardOrders.Controls.Add(this._lblOrdersValue);
			this._cardOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cardOrders.Location = new System.Drawing.Point(351, 0);
			this._cardOrders.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this._cardOrders.Name = "_cardOrders";
			this._cardOrders.Size = new System.Drawing.Size(339, 100);
			this._cardOrders.TabIndex = 1;
			// 
			// _lblOrdersTitle
			// 
			this._lblOrdersTitle.AutoSize = true;
			this._lblOrdersTitle.ForeColor = System.Drawing.Color.Gray;
			this._lblOrdersTitle.Location = new System.Drawing.Point(12, 10);
			this._lblOrdersTitle.Name = "_lblOrdersTitle";
			this._lblOrdersTitle.Size = new System.Drawing.Size(97, 19);
			this._lblOrdersTitle.TabIndex = 0;
			this._lblOrdersTitle.Text = "Today\'s orders";
			// 
			// _lblOrdersValue
			// 
			this._lblOrdersValue.AutoSize = true;
			this._lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._lblOrdersValue.Location = new System.Drawing.Point(12, 34);
			this._lblOrdersValue.Name = "_lblOrdersValue";
			this._lblOrdersValue.Size = new System.Drawing.Size(28, 32);
			this._lblOrdersValue.TabIndex = 1;
			this._lblOrdersValue.Text = "0";
			// 
			// _cardLowStock
			// 
			this._cardLowStock.BackColor = System.Drawing.Color.White;
			this._cardLowStock.Controls.Add(this._lblLowStockTitle);
			this._cardLowStock.Controls.Add(this._lblLowStockValue);
			this._cardLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cardLowStock.Location = new System.Drawing.Point(702, 0);
			this._cardLowStock.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this._cardLowStock.Name = "_cardLowStock";
			this._cardLowStock.Size = new System.Drawing.Size(339, 100);
			this._cardLowStock.TabIndex = 2;
			// 
			// _lblLowStockTitle
			// 
			this._lblLowStockTitle.AutoSize = true;
			this._lblLowStockTitle.ForeColor = System.Drawing.Color.Gray;
			this._lblLowStockTitle.Location = new System.Drawing.Point(12, 10);
			this._lblLowStockTitle.Name = "_lblLowStockTitle";
			this._lblLowStockTitle.Size = new System.Drawing.Size(109, 19);
			this._lblLowStockTitle.TabIndex = 0;
			this._lblLowStockTitle.Text = "Low-stock items";
			// 
			// _lblLowStockValue
			// 
			this._lblLowStockValue.AutoSize = true;
			this._lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._lblLowStockValue.Location = new System.Drawing.Point(12, 34);
			this._lblLowStockValue.Name = "_lblLowStockValue";
			this._lblLowStockValue.Size = new System.Drawing.Size(28, 32);
			this._lblLowStockValue.TabIndex = 1;
			this._lblLowStockValue.Text = "0";
			// 
			// _cardProducts
			// 
			this._cardProducts.BackColor = System.Drawing.Color.White;
			this._cardProducts.Controls.Add(this._lblProductsTitle);
			this._cardProducts.Controls.Add(this._lblProductsValue);
			this._cardProducts.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cardProducts.Location = new System.Drawing.Point(1053, 0);
			this._cardProducts.Margin = new System.Windows.Forms.Padding(0);
			this._cardProducts.Name = "_cardProducts";
			this._cardProducts.Size = new System.Drawing.Size(353, 100);
			this._cardProducts.TabIndex = 3;
			// 
			// _lblProductsTitle
			// 
			this._lblProductsTitle.AutoSize = true;
			this._lblProductsTitle.ForeColor = System.Drawing.Color.Gray;
			this._lblProductsTitle.Location = new System.Drawing.Point(12, 10);
			this._lblProductsTitle.Name = "_lblProductsTitle";
			this._lblProductsTitle.Size = new System.Drawing.Size(104, 19);
			this._lblProductsTitle.TabIndex = 0;
			this._lblProductsTitle.Text = "Active products";
			// 
			// _lblProductsValue
			// 
			this._lblProductsValue.AutoSize = true;
			this._lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._lblProductsValue.Location = new System.Drawing.Point(12, 34);
			this._lblProductsValue.Name = "_lblProductsValue";
			this._lblProductsValue.Size = new System.Drawing.Size(28, 32);
			this._lblProductsValue.TabIndex = 1;
			this._lblProductsValue.Text = "0";
			// 
			// _lblDashboardTitle
			// 
			this._lblDashboardTitle.AutoSize = true;
			this._lblDashboardTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this._lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._lblDashboardTitle.Location = new System.Drawing.Point(0, 0);
			this._lblDashboardTitle.Name = "_lblDashboardTitle";
			this._lblDashboardTitle.Size = new System.Drawing.Size(138, 32);
			this._lblDashboardTitle.TabIndex = 2;
			this._lblDashboardTitle.Text = "Dashboard";
			// 
			// _placeholder
			// 
			this._placeholder.Controls.Add(this._placeholderMessage);
			this._placeholder.Controls.Add(this._placeholderTitle);
			this._placeholder.Dock = System.Windows.Forms.DockStyle.Fill;
			this._placeholder.Location = new System.Drawing.Point(24, 24);
			this._placeholder.Name = "_placeholder";
			this._placeholder.Size = new System.Drawing.Size(1406, 689);
			this._placeholder.TabIndex = 0;
			this._placeholder.Visible = false;
			// 
			// _placeholderMessage
			// 
			this._placeholderMessage.AutoSize = true;
			this._placeholderMessage.ForeColor = System.Drawing.Color.Gray;
			this._placeholderMessage.Location = new System.Drawing.Point(0, 60);
			this._placeholderMessage.Name = "_placeholderMessage";
			this._placeholderMessage.Size = new System.Drawing.Size(94, 19);
			this._placeholderMessage.TabIndex = 0;
			this._placeholderMessage.Text = "Coming soon.";
			// 
			// _placeholderTitle
			// 
			this._placeholderTitle.AutoSize = true;
			this._placeholderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
			this._placeholderTitle.Location = new System.Drawing.Point(0, 0);
			this._placeholderTitle.Name = "_placeholderTitle";
			this._placeholderTitle.Size = new System.Drawing.Size(90, 32);
			this._placeholderTitle.TabIndex = 1;
			this._placeholderTitle.Text = "Screen";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
			this.ClientSize = new System.Drawing.Size(1674, 737);
			this.Controls.Add(this._content);
			this.Controls.Add(this._sidebar);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.MinimumSize = new System.Drawing.Size(900, 600);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CarSaPOS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this._sidebar.ResumeLayout(false);
			this._navPanel.ResumeLayout(false);
			this._logoutPanel.ResumeLayout(false);
			this._userPanel.ResumeLayout(false);
			this._brandPanel.ResumeLayout(false);
			this._content.ResumeLayout(false);
			this._dashboardPanel.ResumeLayout(false);
			this._dashboardPanel.PerformLayout();
			this._bodyLayout.ResumeLayout(false);
			this._bodyLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridLowStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._gridRecent)).EndInit();
			this._cardsLayout.ResumeLayout(false);
			this._cardSales.ResumeLayout(false);
			this._cardSales.PerformLayout();
			this._cardOrders.ResumeLayout(false);
			this._cardOrders.PerformLayout();
			this._cardLowStock.ResumeLayout(false);
			this._cardLowStock.PerformLayout();
			this._cardProducts.ResumeLayout(false);
			this._cardProducts.PerformLayout();
			this._placeholder.ResumeLayout(false);
			this._placeholder.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel _sidebar;
		private System.Windows.Forms.FlowLayoutPanel _navPanel;
		private System.Windows.Forms.Button _btnDashboard;
		private System.Windows.Forms.Button _btnPos;
		private System.Windows.Forms.Button _btnInventory;
		private System.Windows.Forms.Button _btnAnalytics;
		private System.Windows.Forms.Button _btnUsers;
		private System.Windows.Forms.Panel _logoutPanel;
		private System.Windows.Forms.Button _btnLogout;
		private System.Windows.Forms.Panel _userPanel;
		private System.Windows.Forms.Label _lblUser;
		private System.Windows.Forms.Panel _brandPanel;
		private System.Windows.Forms.Label _brandLabel;
		private System.Windows.Forms.Panel _content;
		private System.Windows.Forms.Panel _dashboardPanel;
		private System.Windows.Forms.TableLayoutPanel _bodyLayout;
		private System.Windows.Forms.TableLayoutPanel _cardsLayout;
		private System.Windows.Forms.Label _lblDashboardTitle;
		private System.Windows.Forms.Panel _cardSales;
		private System.Windows.Forms.Label _lblSalesTitle;
		private System.Windows.Forms.Label _lblSalesValue;
		private System.Windows.Forms.Panel _cardOrders;
		private System.Windows.Forms.Label _lblOrdersTitle;
		private System.Windows.Forms.Label _lblOrdersValue;
		private System.Windows.Forms.Panel _cardLowStock;
		private System.Windows.Forms.Label _lblLowStockTitle;
		private System.Windows.Forms.Label _lblLowStockValue;
		private System.Windows.Forms.Panel _cardProducts;
		private System.Windows.Forms.Label _lblProductsTitle;
		private System.Windows.Forms.Label _lblProductsValue;
		private System.Windows.Forms.Label _lblLowStockHeading;
		private System.Windows.Forms.DataGridView _gridLowStock;
		private System.Windows.Forms.Label _lblLowStockNote;
		private System.Windows.Forms.Label _lblRecentHeading;
		private System.Windows.Forms.DataGridView _gridRecent;
		private System.Windows.Forms.Panel _placeholder;
		private System.Windows.Forms.Label _placeholderTitle;
		private System.Windows.Forms.Label _placeholderMessage;
	}
}