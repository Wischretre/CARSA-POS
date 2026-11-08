namespace CarSaPOS.WinForms
{
	partial class ProductForm
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
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.pnlTop = new System.Windows.Forms.TableLayoutPanel();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.chkLowStock = new System.Windows.Forms.CheckBox();
			this.chkInactive = new System.Windows.Forms.CheckBox();
			this.grid = new System.Windows.Forms.DataGridView();
			this.pnlBottom = new System.Windows.Forms.TableLayoutPanel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.tlpMain.SuspendLayout();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.pnlTop, 0, 0);
			this.tlpMain.Controls.Add(this.grid, 0, 1);
			this.tlpMain.Controls.Add(this.pnlBottom, 0, 2);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(12);
			this.tlpMain.RowCount = 3;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(884, 551);
			this.tlpMain.TabIndex = 0;
			// 
			// pnlTop
			// 
			this.pnlTop.ColumnCount = 5;
			this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlTop.Controls.Add(this.lblSearch, 0, 0);
			this.pnlTop.Controls.Add(this.txtSearch, 1, 0);
			this.pnlTop.Controls.Add(this.btnSearch, 2, 0);
			this.pnlTop.Controls.Add(this.chkLowStock, 3, 0);
			this.pnlTop.Controls.Add(this.chkInactive, 4, 0);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlTop.Location = new System.Drawing.Point(12, 12);
			this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.RowCount = 1;
			this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlTop.Size = new System.Drawing.Size(860, 100);
			this.pnlTop.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(0, 43);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(119, 13);
			this.lblSearch.TabIndex = 0;
			this.lblSearch.Text = "SKU / barcode / name:";
			// 
			// txtSearch
			// 
			this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSearch.Location = new System.Drawing.Point(127, 3);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(405, 20);
			this.txtSearch.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnSearch.AutoSize = true;
			this.btnSearch.Location = new System.Drawing.Point(540, 37);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 2, 16, 2);
			this.btnSearch.MinimumSize = new System.Drawing.Size(90, 25);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(90, 25);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			// 
			// chkLowStock
			// 
			this.chkLowStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chkLowStock.AutoSize = true;
			this.chkLowStock.Location = new System.Drawing.Point(646, 41);
			this.chkLowStock.Margin = new System.Windows.Forms.Padding(0, 6, 16, 6);
			this.chkLowStock.Name = "chkLowStock";
			this.chkLowStock.Size = new System.Drawing.Size(97, 17);
			this.chkLowStock.TabIndex = 3;
			this.chkLowStock.Text = "Low stock only";
			this.chkLowStock.UseVisualStyleBackColor = true;
			// 
			// chkInactive
			// 
			this.chkInactive.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chkInactive.AutoSize = true;
			this.chkInactive.Location = new System.Drawing.Point(759, 41);
			this.chkInactive.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.chkInactive.Name = "chkInactive";
			this.chkInactive.Size = new System.Drawing.Size(101, 17);
			this.chkInactive.TabIndex = 4;
			this.chkInactive.Text = "Include inactive";
			this.chkInactive.UseVisualStyleBackColor = true;
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.grid.BackgroundColor = System.Drawing.Color.White;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(12, 120);
			this.grid.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.grid.MultiSelect = false;
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(860, 311);
			this.grid.TabIndex = 5;
			// 
			// pnlBottom
			// 
			this.pnlBottom.ColumnCount = 5;
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.Controls.Add(this.btnAdd, 0, 0);
			this.pnlBottom.Controls.Add(this.btnEdit, 1, 0);
			this.pnlBottom.Controls.Add(this.btnRefresh, 2, 0);
			this.pnlBottom.Controls.Add(this.lblStatus, 3, 0);
			this.pnlBottom.Controls.Add(this.btnClose, 4, 0);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBottom.Location = new System.Drawing.Point(12, 439);
			this.pnlBottom.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.RowCount = 1;
			this.pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlBottom.Size = new System.Drawing.Size(860, 100);
			this.pnlBottom.TabIndex = 2;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnAdd.AutoSize = true;
			this.btnAdd.Location = new System.Drawing.Point(0, 36);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
			this.btnAdd.MinimumSize = new System.Drawing.Size(90, 27);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(90, 27);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEdit.AutoSize = true;
			this.btnEdit.Location = new System.Drawing.Point(96, 36);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
			this.btnEdit.MinimumSize = new System.Drawing.Size(90, 27);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(90, 27);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnRefresh.AutoSize = true;
			this.btnRefresh.Location = new System.Drawing.Point(192, 36);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this.btnRefresh.MinimumSize = new System.Drawing.Size(90, 27);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(90, 27);
			this.btnRefresh.TabIndex = 8;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblStatus.AutoSize = true;
			this.lblStatus.ForeColor = System.Drawing.Color.Firebrick;
			this.lblStatus.Location = new System.Drawing.Point(294, 46);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 6, 12, 0);
			this.lblStatus.MaximumSize = new System.Drawing.Size(500, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 13);
			this.lblStatus.TabIndex = 9;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnClose.AutoSize = true;
			this.btnClose.Location = new System.Drawing.Point(770, 36);
			this.btnClose.Margin = new System.Windows.Forms.Padding(0);
			this.btnClose.MinimumSize = new System.Drawing.Size(90, 27);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 27);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// ProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 551);
			this.Controls.Add(this.tlpMain);
			this.MinimumSize = new System.Drawing.Size(700, 450);
			this.Name = "ProductForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Inventory Management";
			this.tlpMain.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			this.pnlBottom.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel pnlTop;
		private System.Windows.Forms.TableLayoutPanel pnlBottom;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.CheckBox chkLowStock;
		private System.Windows.Forms.CheckBox chkInactive;
		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnClose;
	}
}