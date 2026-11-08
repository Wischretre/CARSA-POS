namespace CarSaPOS.WinForms
{
	partial class CheckoutForm
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
			this.pnlLeft = new System.Windows.Forms.TableLayoutPanel();
			this.lblBarcode = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.gridProducts = new System.Windows.Forms.DataGridView();
			this.btnAddToCart = new System.Windows.Forms.Button();
			this.pnlRight = new System.Windows.Forms.TableLayoutPanel();
			this.lblCart = new System.Windows.Forms.Label();
			this.gridCart = new System.Windows.Forms.DataGridView();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.lblCustomer = new System.Windows.Forms.Label();
			this.cboCustomer = new System.Windows.Forms.ComboBox();
			this.lblPayment = new System.Windows.Forms.Label();
			this.cboPayment = new System.Windows.Forms.ComboBox();
			this.lblDiscount = new System.Windows.Forms.Label();
			this.txtDiscount = new System.Windows.Forms.TextBox();
			this.lblAmountPaid = new System.Windows.Forms.Label();
			this.txtAmountPaid = new System.Windows.Forms.TextBox();
			this.lblTotals = new System.Windows.Forms.Label();
			this.pnlBottom = new System.Windows.Forms.TableLayoutPanel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnCheckout = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.tlpMain.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
			this.pnlRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
			this.tlpMain.Controls.Add(this.pnlLeft, 0, 0);
			this.tlpMain.Controls.Add(this.pnlRight, 1, 0);
			this.tlpMain.Controls.Add(this.pnlBottom, 0, 1);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(12);
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(1000, 510);
			this.tlpMain.TabIndex = 0;
			// 
			// pnlLeft
			// 
			this.pnlLeft.ColumnCount = 3;
			this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlLeft.Controls.Add(this.lblBarcode, 0, 0);
			this.pnlLeft.Controls.Add(this.txtBarcode, 1, 0);
			this.pnlLeft.Controls.Add(this.lblSearch, 0, 1);
			this.pnlLeft.Controls.Add(this.txtSearch, 1, 1);
			this.pnlLeft.Controls.Add(this.btnSearch, 2, 1);
			this.pnlLeft.Controls.Add(this.gridProducts, 0, 2);
			this.pnlLeft.Controls.Add(this.btnAddToCart, 0, 3);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeft.Location = new System.Drawing.Point(12, 12);
			this.pnlLeft.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.RowCount = 5;
			this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlLeft.Size = new System.Drawing.Size(427, 374);
			this.pnlLeft.TabIndex = 1;
			// 
			// lblBarcode
			// 
			this.lblBarcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblBarcode.AutoSize = true;
			this.lblBarcode.Location = new System.Drawing.Point(3, 7);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Size = new System.Drawing.Size(85, 15);
			this.lblBarcode.TabIndex = 0;
			this.lblBarcode.Text = "Barcode / SKU:";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBarcode.Location = new System.Drawing.Point(94, 3);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(249, 23);
			this.txtBarcode.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(3, 37);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(78, 15);
			this.lblSearch.TabIndex = 2;
			this.lblSearch.Text = "Find product:";
			// 
			// txtSearch
			// 
			this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSearch.Location = new System.Drawing.Point(94, 32);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(249, 23);
			this.txtSearch.TabIndex = 3;
			// 
			// btnSearch
			// 
			this.btnSearch.AutoSize = true;
			this.btnSearch.Location = new System.Drawing.Point(349, 32);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 25);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			// 
			// gridProducts
			// 
			this.gridProducts.AllowUserToAddRows = false;
			this.gridProducts.AllowUserToDeleteRows = false;
			this.gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridProducts.BackgroundColor = System.Drawing.Color.White;
			this.gridProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.pnlLeft.SetColumnSpan(this.gridProducts, 3);
			this.gridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridProducts.Location = new System.Drawing.Point(0, 66);
			this.gridProducts.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.gridProducts.MultiSelect = false;
			this.gridProducts.Name = "gridProducts";
			this.gridProducts.ReadOnly = true;
			this.gridProducts.RowHeadersVisible = false;
			this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridProducts.Size = new System.Drawing.Size(427, 271);
			this.gridProducts.TabIndex = 5;
			// 
			// btnAddToCart
			// 
			this.btnAddToCart.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnAddToCart.AutoSize = true;
			this.pnlLeft.SetColumnSpan(this.btnAddToCart, 3);
			this.btnAddToCart.Location = new System.Drawing.Point(3, 346);
			this.btnAddToCart.Name = "btnAddToCart";
			this.btnAddToCart.Size = new System.Drawing.Size(76, 25);
			this.btnAddToCart.TabIndex = 6;
			this.btnAddToCart.Text = "Add to cart";
			this.btnAddToCart.UseVisualStyleBackColor = true;
			// 
			// pnlRight
			// 
			this.pnlRight.ColumnCount = 4;
			this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.pnlRight.Controls.Add(this.lblCart, 0, 0);
			this.pnlRight.Controls.Add(this.gridCart, 0, 1);
			this.pnlRight.Controls.Add(this.btnRemove, 0, 2);
			this.pnlRight.Controls.Add(this.btnClear, 2, 2);
			this.pnlRight.Controls.Add(this.lblCustomer, 0, 3);
			this.pnlRight.Controls.Add(this.cboCustomer, 1, 3);
			this.pnlRight.Controls.Add(this.lblPayment, 0, 4);
			this.pnlRight.Controls.Add(this.cboPayment, 1, 4);
			this.pnlRight.Controls.Add(this.lblDiscount, 0, 5);
			this.pnlRight.Controls.Add(this.txtDiscount, 1, 5);
			this.pnlRight.Controls.Add(this.lblAmountPaid, 0, 6);
			this.pnlRight.Controls.Add(this.txtAmountPaid, 1, 6);
			this.pnlRight.Controls.Add(this.lblTotals, 0, 7);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRight.Location = new System.Drawing.Point(451, 12);
			this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.RowCount = 9;
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlRight.Size = new System.Drawing.Size(537, 374);
			this.pnlRight.TabIndex = 2;
			// 
			// lblCart
			// 
			this.lblCart.AutoSize = true;
			this.pnlRight.SetColumnSpan(this.lblCart, 4);
			this.lblCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.lblCart.Location = new System.Drawing.Point(3, 0);
			this.lblCart.Name = "lblCart";
			this.lblCart.Size = new System.Drawing.Size(38, 20);
			this.lblCart.TabIndex = 7;
			this.lblCart.Text = "Cart";
			// 
			// gridCart
			// 
			this.gridCart.AllowUserToAddRows = false;
			this.gridCart.AllowUserToDeleteRows = false;
			this.gridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridCart.BackgroundColor = System.Drawing.Color.White;
			this.gridCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.pnlRight.SetColumnSpan(this.gridCart, 4);
			this.gridCart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridCart.Location = new System.Drawing.Point(0, 26);
			this.gridCart.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.gridCart.MultiSelect = false;
			this.gridCart.Name = "gridCart";
			this.gridCart.RowHeadersVisible = false;
			this.gridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridCart.Size = new System.Drawing.Size(537, 180);
			this.gridCart.TabIndex = 8;
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnRemove.AutoSize = true;
			this.pnlRight.SetColumnSpan(this.btnRemove, 2);
			this.btnRemove.Location = new System.Drawing.Point(3, 215);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(82, 25);
			this.btnRemove.TabIndex = 9;
			this.btnRemove.Text = "Remove line";
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnClear.AutoSize = true;
			this.pnlRight.SetColumnSpan(this.btnClear, 2);
			this.btnClear.Location = new System.Drawing.Point(271, 215);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(67, 25);
			this.btnClear.TabIndex = 10;
			this.btnClear.Text = "Clear sale";
			this.btnClear.UseVisualStyleBackColor = true;
			// 
			// lblCustomer
			// 
			this.lblCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblCustomer.AutoSize = true;
			this.lblCustomer.Location = new System.Drawing.Point(3, 249);
			this.lblCustomer.Name = "lblCustomer";
			this.lblCustomer.Size = new System.Drawing.Size(62, 15);
			this.lblCustomer.TabIndex = 11;
			this.lblCustomer.Text = "Customer:";
			// 
			// cboCustomer
			// 
			this.pnlRight.SetColumnSpan(this.cboCustomer, 3);
			this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomer.FormattingEnabled = true;
			this.cboCustomer.Location = new System.Drawing.Point(137, 246);
			this.cboCustomer.Name = "cboCustomer";
			this.cboCustomer.Size = new System.Drawing.Size(397, 23);
			this.cboCustomer.TabIndex = 12;
			// 
			// lblPayment
			// 
			this.lblPayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPayment.AutoSize = true;
			this.lblPayment.Location = new System.Drawing.Point(3, 276);
			this.lblPayment.Name = "lblPayment";
			this.lblPayment.Size = new System.Drawing.Size(102, 15);
			this.lblPayment.TabIndex = 13;
			this.lblPayment.Text = "Payment method:";
			// 
			// cboPayment
			// 
			this.pnlRight.SetColumnSpan(this.cboPayment, 3);
			this.cboPayment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPayment.FormattingEnabled = true;
			this.cboPayment.Location = new System.Drawing.Point(137, 273);
			this.cboPayment.Name = "cboPayment";
			this.cboPayment.Size = new System.Drawing.Size(397, 23);
			this.cboPayment.TabIndex = 14;
			// 
			// lblDiscount
			// 
			this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblDiscount.AutoSize = true;
			this.lblDiscount.Location = new System.Drawing.Point(3, 304);
			this.lblDiscount.Name = "lblDiscount";
			this.lblDiscount.Size = new System.Drawing.Size(57, 15);
			this.lblDiscount.TabIndex = 15;
			this.lblDiscount.Text = "Discount:";
			// 
			// txtDiscount
			// 
			this.pnlRight.SetColumnSpan(this.txtDiscount, 3);
			this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDiscount.Location = new System.Drawing.Point(137, 300);
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(397, 23);
			this.txtDiscount.TabIndex = 16;
			// 
			// lblAmountPaid
			// 
			this.lblAmountPaid.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblAmountPaid.AutoSize = true;
			this.lblAmountPaid.Location = new System.Drawing.Point(3, 333);
			this.lblAmountPaid.Name = "lblAmountPaid";
			this.lblAmountPaid.Size = new System.Drawing.Size(80, 15);
			this.lblAmountPaid.TabIndex = 17;
			this.lblAmountPaid.Text = "Amount paid:";
			// 
			// txtAmountPaid
			// 
			this.pnlRight.SetColumnSpan(this.txtAmountPaid, 3);
			this.txtAmountPaid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAmountPaid.Location = new System.Drawing.Point(137, 329);
			this.txtAmountPaid.Name = "txtAmountPaid";
			this.txtAmountPaid.Size = new System.Drawing.Size(397, 23);
			this.txtAmountPaid.TabIndex = 18;
			// 
			// lblTotals
			// 
			this.lblTotals.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblTotals.AutoSize = true;
			this.pnlRight.SetColumnSpan(this.lblTotals, 4);
			this.lblTotals.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.lblTotals.Location = new System.Drawing.Point(3, 355);
			this.lblTotals.Name = "lblTotals";
			this.lblTotals.Size = new System.Drawing.Size(78, 19);
			this.lblTotals.TabIndex = 19;
			this.lblTotals.Text = "Total: 0.00";
			// 
			// pnlBottom
			// 
			this.pnlBottom.ColumnCount = 3;
			this.tlpMain.SetColumnSpan(this.pnlBottom, 2);
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.pnlBottom.Controls.Add(this.lblStatus, 0, 0);
			this.pnlBottom.Controls.Add(this.btnCheckout, 1, 0);
			this.pnlBottom.Controls.Add(this.btnClose, 2, 0);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBottom.Location = new System.Drawing.Point(12, 398);
			this.pnlBottom.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.RowCount = 1;
			this.pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.pnlBottom.Size = new System.Drawing.Size(976, 100);
			this.pnlBottom.TabIndex = 3;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblStatus.AutoSize = true;
			this.lblStatus.ForeColor = System.Drawing.Color.Firebrick;
			this.lblStatus.Location = new System.Drawing.Point(3, 42);
			this.lblStatus.MaximumSize = new System.Drawing.Size(700, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 15);
			this.lblStatus.TabIndex = 20;
			// 
			// btnCheckout
			// 
			this.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnCheckout.AutoSize = true;
			this.btnCheckout.Location = new System.Drawing.Point(767, 34);
			this.btnCheckout.MinimumSize = new System.Drawing.Size(110, 32);
			this.btnCheckout.Name = "btnCheckout";
			this.btnCheckout.Size = new System.Drawing.Size(110, 32);
			this.btnCheckout.TabIndex = 21;
			this.btnCheckout.Text = "Checkout";
			this.btnCheckout.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnClose.AutoSize = true;
			this.btnClose.Location = new System.Drawing.Point(883, 34);
			this.btnClose.MinimumSize = new System.Drawing.Size(90, 32);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 32);
			this.btnClose.TabIndex = 22;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// CheckoutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 510);
			this.Controls.Add(this.tlpMain);
			this.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.MinimumSize = new System.Drawing.Size(1000, 540);
			this.Name = "CheckoutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Point of Sale - Checkout";
			this.tlpMain.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlLeft.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
			this.pnlRight.ResumeLayout(false);
			this.pnlRight.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			this.pnlBottom.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel pnlLeft;
		private System.Windows.Forms.TableLayoutPanel pnlRight;
		private System.Windows.Forms.TableLayoutPanel pnlBottom;
		private System.Windows.Forms.Label lblBarcode;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DataGridView gridProducts;
		private System.Windows.Forms.Button btnAddToCart;
		private System.Windows.Forms.Label lblCart;
		private System.Windows.Forms.DataGridView gridCart;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label lblCustomer;
		private System.Windows.Forms.ComboBox cboCustomer;
		private System.Windows.Forms.Label lblPayment;
		private System.Windows.Forms.ComboBox cboPayment;
		private System.Windows.Forms.Label lblDiscount;
		private System.Windows.Forms.TextBox txtDiscount;
		private System.Windows.Forms.Label lblAmountPaid;
		private System.Windows.Forms.TextBox txtAmountPaid;
		private System.Windows.Forms.Label lblTotals;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnCheckout;
		private System.Windows.Forms.Button btnClose;
	}
}