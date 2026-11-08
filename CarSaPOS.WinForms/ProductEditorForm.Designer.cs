namespace CarSaPOS.WinForms
{
	partial class ProductEditorForm
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
			this.pnlFields = new System.Windows.Forms.TableLayoutPanel();
			this.pnlImage = new System.Windows.Forms.TableLayoutPanel();
			this.pnlBottom = new System.Windows.Forms.TableLayoutPanel();
			this.lblSku = new System.Windows.Forms.Label();
			this.txtSku = new System.Windows.Forms.TextBox();
			this.lblBarcode = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.lblCost = new System.Windows.Forms.Label();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.lblPrice = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.lblStock = new System.Windows.Forms.Label();
			this.txtStock = new System.Windows.Forms.TextBox();
			this.lblReorder = new System.Windows.Forms.Label();
			this.txtReorder = new System.Windows.Forms.TextBox();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.picPreview = new System.Windows.Forms.PictureBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.lblImageHint = new System.Windows.Forms.Label();
			this.tlpMain.SuspendLayout();
			this.pnlFields.SuspendLayout();
			this.pnlImage.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// tlpMain: row 0 = fields (left) and image (right), row 1 = status and buttons.
			// 
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.Padding = new System.Windows.Forms.Padding(16);
			this.tlpMain.TabIndex = 0;
			this.tlpMain.Controls.Add(this.pnlFields, 0, 0);
			this.tlpMain.Controls.Add(this.pnlImage, 1, 0);
			this.tlpMain.Controls.Add(this.pnlBottom, 0, 1);
			this.tlpMain.SetColumnSpan(this.pnlBottom, 2);
			// 
			// pnlFields: label and input rows for the product data
			// 
			this.pnlFields.ColumnCount = 2;
			this.pnlFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlFields.RowCount = 9;
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFields.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
			this.pnlFields.Name = "pnlFields";
			this.pnlFields.TabIndex = 1;
			this.pnlFields.Controls.Add(this.lblSku, 0, 0);
			this.pnlFields.Controls.Add(this.txtSku, 1, 0);
			this.pnlFields.Controls.Add(this.lblBarcode, 0, 1);
			this.pnlFields.Controls.Add(this.txtBarcode, 1, 1);
			this.pnlFields.Controls.Add(this.lblName, 0, 2);
			this.pnlFields.Controls.Add(this.txtName, 1, 2);
			this.pnlFields.Controls.Add(this.lblCategory, 0, 3);
			this.pnlFields.Controls.Add(this.cboCategory, 1, 3);
			this.pnlFields.Controls.Add(this.lblCost, 0, 4);
			this.pnlFields.Controls.Add(this.txtCost, 1, 4);
			this.pnlFields.Controls.Add(this.lblPrice, 0, 5);
			this.pnlFields.Controls.Add(this.txtPrice, 1, 5);
			this.pnlFields.Controls.Add(this.lblStock, 0, 6);
			this.pnlFields.Controls.Add(this.txtStock, 1, 6);
			this.pnlFields.Controls.Add(this.lblReorder, 0, 7);
			this.pnlFields.Controls.Add(this.txtReorder, 1, 7);
			this.pnlFields.Controls.Add(this.chkActive, 1, 8);
			// 
			// pnlImage: preview, browse button, and hint
			// 
			this.pnlImage.ColumnCount = 1;
			this.pnlImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlImage.RowCount = 3;
			this.pnlImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlImage.Margin = new System.Windows.Forms.Padding(0);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.TabIndex = 2;
			this.pnlImage.Controls.Add(this.picPreview, 0, 0);
			this.pnlImage.Controls.Add(this.btnBrowse, 0, 1);
			this.pnlImage.Controls.Add(this.lblImageHint, 0, 2);
			// 
			// pnlBottom: status message, Save, and Cancel
			// 
			this.pnlBottom.ColumnCount = 3;
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlBottom.RowCount = 1;
			this.pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBottom.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.TabIndex = 3;
			this.pnlBottom.Controls.Add(this.lblStatus, 0, 0);
			this.pnlBottom.Controls.Add(this.btnSave, 1, 0);
			this.pnlBottom.Controls.Add(this.btnCancel, 2, 0);
			// 
			// lblSku
			// 
			this.lblSku.AutoSize = true;
			this.lblSku.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblSku.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblSku.Name = "lblSku";
			this.lblSku.TabIndex = 0;
			this.lblSku.Text = "SKU";
			// 
			// txtSku
			// 
			this.txtSku.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSku.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtSku.MaxLength = 30;
			this.txtSku.Name = "txtSku";
			this.txtSku.TabIndex = 1;
			// 
			// lblBarcode
			// 
			this.lblBarcode.AutoSize = true;
			this.lblBarcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblBarcode.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.TabIndex = 2;
			this.lblBarcode.Text = "Barcode";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBarcode.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtBarcode.MaxLength = 50;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.TabIndex = 3;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblName.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblName.Name = "lblName";
			this.lblName.TabIndex = 4;
			this.lblName.Text = "Product name";
			// 
			// txtName
			// 
			this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtName.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtName.MaxLength = 150;
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 5;
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblCategory.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.TabIndex = 6;
			this.lblCategory.Text = "Category";
			// 
			// cboCategory
			// 
			this.cboCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.TabIndex = 7;
			// 
			// lblCost
			// 
			this.lblCost.AutoSize = true;
			this.lblCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblCost.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblCost.Name = "lblCost";
			this.lblCost.TabIndex = 8;
			this.lblCost.Text = "Cost price";
			// 
			// txtCost
			// 
			this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCost.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtCost.Name = "txtCost";
			this.txtCost.TabIndex = 9;
			// 
			// lblPrice
			// 
			this.lblPrice.AutoSize = true;
			this.lblPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPrice.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.TabIndex = 10;
			this.lblPrice.Text = "Selling price";
			// 
			// txtPrice
			// 
			this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPrice.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.TabIndex = 11;
			// 
			// lblStock
			// 
			this.lblStock.AutoSize = true;
			this.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblStock.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblStock.Name = "lblStock";
			this.lblStock.TabIndex = 12;
			this.lblStock.Text = "Stock";
			// 
			// txtStock
			// 
			this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtStock.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtStock.Name = "txtStock";
			this.txtStock.TabIndex = 13;
			// 
			// lblReorder
			// 
			this.lblReorder.AutoSize = true;
			this.lblReorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblReorder.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this.lblReorder.Name = "lblReorder";
			this.lblReorder.TabIndex = 14;
			this.lblReorder.Text = "Reorder level";
			// 
			// txtReorder
			// 
			this.txtReorder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtReorder.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.txtReorder.Name = "txtReorder";
			this.txtReorder.TabIndex = 15;
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chkActive.Checked = true;
			this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkActive.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.chkActive.Name = "chkActive";
			this.chkActive.TabIndex = 16;
			this.chkActive.Text = "Active";
			this.chkActive.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblStatus.ForeColor = System.Drawing.Color.Firebrick;
			this.lblStatus.MaximumSize = new System.Drawing.Size(400, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.TabIndex = 17;
			// 
			// btnSave
			// 
			this.btnSave.AutoSize = true;
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnSave.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnSave.MinimumSize = new System.Drawing.Size(88, 27);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnCancel.MinimumSize = new System.Drawing.Size(88, 27);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// picPreview
			// 
			this.picPreview.BackColor = System.Drawing.Color.White;
			this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picPreview.MinimumSize = new System.Drawing.Size(120, 120);
			this.picPreview.Name = "picPreview";
			this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPreview.TabIndex = 20;
			this.picPreview.TabStop = false;
			// 
			// btnBrowse
			// 
			this.btnBrowse.AutoSize = true;
			this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnBrowse.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.btnBrowse.MinimumSize = new System.Drawing.Size(120, 27);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 21;
			this.btnBrowse.Text = "Browse image...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			// 
			// lblImageHint
			// 
			this.lblImageHint.AutoSize = true;
			this.lblImageHint.ForeColor = System.Drawing.Color.Gray;
			this.lblImageHint.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.lblImageHint.MaximumSize = new System.Drawing.Size(220, 0);
			this.lblImageHint.Name = "lblImageHint";
			this.lblImageHint.TabIndex = 22;
			this.lblImageHint.Text = "JPG or PNG, 2 MB max, 2000 x 2000 px.";
			// 
			// ProductEditorForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(610, 415);
			this.Controls.Add(this.tlpMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(560, 400);
			this.Name = "ProductEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Product";
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.pnlFields.ResumeLayout(false);
			this.pnlFields.PerformLayout();
			this.pnlImage.ResumeLayout(false);
			this.pnlImage.PerformLayout();
			this.pnlBottom.ResumeLayout(false);
			this.pnlBottom.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel pnlFields;
		private System.Windows.Forms.TableLayoutPanel pnlImage;
		private System.Windows.Forms.TableLayoutPanel pnlBottom;
		private System.Windows.Forms.Label lblSku;
		private System.Windows.Forms.TextBox txtSku;
		private System.Windows.Forms.Label lblBarcode;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.Label lblCost;
		private System.Windows.Forms.TextBox txtCost;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label lblStock;
		private System.Windows.Forms.TextBox txtStock;
		private System.Windows.Forms.Label lblReorder;
		private System.Windows.Forms.TextBox txtReorder;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label lblImageHint;
	}
}