using System.Windows.Forms;

namespace CarSaPOS.WinForms
{
	partial class UserAdminForm
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
			this._topPanel = new System.Windows.Forms.TableLayoutPanel();
			this._btnAdd = new System.Windows.Forms.Button();
			this._btnEdit = new System.Windows.Forms.Button();
			this._btnRefresh = new System.Windows.Forms.Button();
			this._tabs = new System.Windows.Forms.TabControl();
			this._tabUsers = new System.Windows.Forms.TabPage();
			this._gridUsers = new System.Windows.Forms.DataGridView();
			this._tabAudit = new System.Windows.Forms.TabPage();
			this._tlpAudit = new System.Windows.Forms.TableLayoutPanel();
			this._auditTop = new System.Windows.Forms.TableLayoutPanel();
			this._lblAuditFrom = new System.Windows.Forms.Label();
			this._dtpAuditFrom = new System.Windows.Forms.DateTimePicker();
			this._lblAuditTo = new System.Windows.Forms.Label();
			this._dtpAuditTo = new System.Windows.Forms.DateTimePicker();
			this._btnLoadAudit = new System.Windows.Forms.Button();
			this._gridAudit = new System.Windows.Forms.DataGridView();
			this._bottomPanel = new System.Windows.Forms.TableLayoutPanel();
			this._lblStatus = new System.Windows.Forms.Label();
			this._btnClose = new System.Windows.Forms.Button();
			this._topPanel.SuspendLayout();
			this._tabs.SuspendLayout();
			this._tabUsers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridUsers)).BeginInit();
			this._tabAudit.SuspendLayout();
			this._tlpAudit.SuspendLayout();
			this._auditTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridAudit)).BeginInit();
			this._bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _topPanel
			// 
			this._topPanel.AutoSize = true;
			this._topPanel.ColumnCount = 4;
			this._topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._topPanel.Controls.Add(this._btnAdd, 0, 0);
			this._topPanel.Controls.Add(this._btnEdit, 1, 0);
			this._topPanel.Controls.Add(this._btnRefresh, 2, 0);
			this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._topPanel.Location = new System.Drawing.Point(0, 0);
			this._topPanel.Name = "_topPanel";
			this._topPanel.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
			this._topPanel.RowCount = 1;
			this._topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._topPanel.Size = new System.Drawing.Size(857, 44);
			this._topPanel.TabIndex = 2;
			// 
			// _btnAdd
			// 
			this._btnAdd.AutoSize = true;
			this._btnAdd.Location = new System.Drawing.Point(10, 9);
			this._btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
			this._btnAdd.MinimumSize = new System.Drawing.Size(86, 26);
			this._btnAdd.Name = "_btnAdd";
			this._btnAdd.Size = new System.Drawing.Size(86, 26);
			this._btnAdd.TabIndex = 0;
			this._btnAdd.Text = "Add user";
			this._btnAdd.UseVisualStyleBackColor = true;
			// 
			// _btnEdit
			// 
			this._btnEdit.AutoSize = true;
			this._btnEdit.Location = new System.Drawing.Point(103, 9);
			this._btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
			this._btnEdit.MinimumSize = new System.Drawing.Size(86, 26);
			this._btnEdit.Name = "_btnEdit";
			this._btnEdit.Size = new System.Drawing.Size(86, 26);
			this._btnEdit.TabIndex = 1;
			this._btnEdit.Text = "Edit user";
			this._btnEdit.UseVisualStyleBackColor = true;
			// 
			// _btnRefresh
			// 
			this._btnRefresh.AutoSize = true;
			this._btnRefresh.Location = new System.Drawing.Point(196, 9);
			this._btnRefresh.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
			this._btnRefresh.MinimumSize = new System.Drawing.Size(77, 26);
			this._btnRefresh.Name = "_btnRefresh";
			this._btnRefresh.Size = new System.Drawing.Size(77, 26);
			this._btnRefresh.TabIndex = 2;
			this._btnRefresh.Text = "Refresh";
			this._btnRefresh.UseVisualStyleBackColor = true;
			// 
			// _tabs
			// 
			this._tabs.Controls.Add(this._tabUsers);
			this._tabs.Controls.Add(this._tabAudit);
			this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tabs.Location = new System.Drawing.Point(0, 44);
			this._tabs.Name = "_tabs";
			this._tabs.SelectedIndex = 0;
			this._tabs.Size = new System.Drawing.Size(857, 438);
			this._tabs.TabIndex = 0;
			// 
			// _tabUsers
			// 
			this._tabUsers.Controls.Add(this._gridUsers);
			this._tabUsers.Location = new System.Drawing.Point(4, 22);
			this._tabUsers.Name = "_tabUsers";
			this._tabUsers.Padding = new System.Windows.Forms.Padding(3);
			this._tabUsers.Size = new System.Drawing.Size(849, 412);
			this._tabUsers.TabIndex = 0;
			this._tabUsers.Text = "Users";
			// 
			// _gridUsers
			// 
			this._gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridUsers.Location = new System.Drawing.Point(3, 3);
			this._gridUsers.Name = "_gridUsers";
			this._gridUsers.Size = new System.Drawing.Size(843, 406);
			this._gridUsers.TabIndex = 0;
			// 
			// _tabAudit
			// 
			this._tabAudit.Controls.Add(this._tlpAudit);
			this._tabAudit.Location = new System.Drawing.Point(4, 22);
			this._tabAudit.Name = "_tabAudit";
			this._tabAudit.Padding = new System.Windows.Forms.Padding(3);
			this._tabAudit.Size = new System.Drawing.Size(163, 61);
			this._tabAudit.TabIndex = 1;
			this._tabAudit.Text = "Audit History";
			// 
			// _tlpAudit
			// 
			this._tlpAudit.ColumnCount = 1;
			this._tlpAudit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpAudit.Controls.Add(this._auditTop, 0, 0);
			this._tlpAudit.Controls.Add(this._gridAudit, 0, 1);
			this._tlpAudit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpAudit.Location = new System.Drawing.Point(3, 3);
			this._tlpAudit.Name = "_tlpAudit";
			this._tlpAudit.RowCount = 2;
			this._tlpAudit.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._tlpAudit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpAudit.Size = new System.Drawing.Size(157, 55);
			this._tlpAudit.TabIndex = 0;
			// 
			// _auditTop
			// 
			this._auditTop.AutoSize = true;
			this._auditTop.ColumnCount = 6;
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._auditTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._auditTop.Controls.Add(this._lblAuditFrom, 0, 0);
			this._auditTop.Controls.Add(this._dtpAuditFrom, 1, 0);
			this._auditTop.Controls.Add(this._lblAuditTo, 2, 0);
			this._auditTop.Controls.Add(this._dtpAuditTo, 3, 0);
			this._auditTop.Controls.Add(this._btnLoadAudit, 4, 0);
			this._auditTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this._auditTop.Location = new System.Drawing.Point(3, 3);
			this._auditTop.Name = "_auditTop";
			this._auditTop.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this._auditTop.RowCount = 1;
			this._auditTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._auditTop.Size = new System.Drawing.Size(151, 40);
			this._auditTop.TabIndex = 0;
			// 
			// _lblAuditFrom
			// 
			this._lblAuditFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblAuditFrom.AutoSize = true;
			this._lblAuditFrom.Location = new System.Drawing.Point(7, 16);
			this._lblAuditFrom.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
			this._lblAuditFrom.Name = "_lblAuditFrom";
			this._lblAuditFrom.Size = new System.Drawing.Size(33, 13);
			this._lblAuditFrom.TabIndex = 0;
			this._lblAuditFrom.Text = "From:";
			// 
			// _dtpAuditFrom
			// 
			this._dtpAuditFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this._dtpAuditFrom.Location = new System.Drawing.Point(45, 7);
			this._dtpAuditFrom.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this._dtpAuditFrom.Name = "_dtpAuditFrom";
			this._dtpAuditFrom.Size = new System.Drawing.Size(112, 20);
			this._dtpAuditFrom.TabIndex = 1;
			// 
			// _lblAuditTo
			// 
			this._lblAuditTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblAuditTo.AutoSize = true;
			this._lblAuditTo.Location = new System.Drawing.Point(167, 16);
			this._lblAuditTo.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
			this._lblAuditTo.Name = "_lblAuditTo";
			this._lblAuditTo.Size = new System.Drawing.Size(23, 13);
			this._lblAuditTo.TabIndex = 2;
			this._lblAuditTo.Text = "To:";
			// 
			// _dtpAuditTo
			// 
			this._dtpAuditTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this._dtpAuditTo.Location = new System.Drawing.Point(195, 7);
			this._dtpAuditTo.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this._dtpAuditTo.Name = "_dtpAuditTo";
			this._dtpAuditTo.Size = new System.Drawing.Size(112, 20);
			this._dtpAuditTo.TabIndex = 3;
			// 
			// _btnLoadAudit
			// 
			this._btnLoadAudit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._btnLoadAudit.AutoSize = true;
			this._btnLoadAudit.Location = new System.Drawing.Point(317, 7);
			this._btnLoadAudit.Margin = new System.Windows.Forms.Padding(0);
			this._btnLoadAudit.MinimumSize = new System.Drawing.Size(77, 26);
			this._btnLoadAudit.Name = "_btnLoadAudit";
			this._btnLoadAudit.Size = new System.Drawing.Size(77, 26);
			this._btnLoadAudit.TabIndex = 4;
			this._btnLoadAudit.Text = "Load";
			this._btnLoadAudit.UseVisualStyleBackColor = true;
			// 
			// _gridAudit
			// 
			this._gridAudit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridAudit.Location = new System.Drawing.Point(3, 49);
			this._gridAudit.Name = "_gridAudit";
			this._gridAudit.Size = new System.Drawing.Size(151, 3);
			this._gridAudit.TabIndex = 1;
			// 
			// _bottomPanel
			// 
			this._bottomPanel.AutoSize = true;
			this._bottomPanel.ColumnCount = 2;
			this._bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._bottomPanel.Controls.Add(this._lblStatus, 0, 0);
			this._bottomPanel.Controls.Add(this._btnClose, 1, 0);
			this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._bottomPanel.Location = new System.Drawing.Point(0, 482);
			this._bottomPanel.Name = "_bottomPanel";
			this._bottomPanel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
			this._bottomPanel.RowCount = 1;
			this._bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._bottomPanel.Size = new System.Drawing.Size(857, 38);
			this._bottomPanel.TabIndex = 1;
			// 
			// _lblStatus
			// 
			this._lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblStatus.AutoSize = true;
			this._lblStatus.Location = new System.Drawing.Point(10, 15);
			this._lblStatus.Margin = new System.Windows.Forms.Padding(0, 5, 10, 0);
			this._lblStatus.Name = "_lblStatus";
			this._lblStatus.Size = new System.Drawing.Size(0, 13);
			this._lblStatus.TabIndex = 0;
			// 
			// _btnClose
			// 
			this._btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._btnClose.AutoSize = true;
			this._btnClose.Location = new System.Drawing.Point(770, 7);
			this._btnClose.Margin = new System.Windows.Forms.Padding(0);
			this._btnClose.MinimumSize = new System.Drawing.Size(77, 24);
			this._btnClose.Name = "_btnClose";
			this._btnClose.Size = new System.Drawing.Size(77, 24);
			this._btnClose.TabIndex = 1;
			this._btnClose.Text = "Close";
			this._btnClose.UseVisualStyleBackColor = true;
			// 
			// UserAdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(857, 520);
			this.Controls.Add(this._tabs);
			this.Controls.Add(this._bottomPanel);
			this.Controls.Add(this._topPanel);
			this.MinimumSize = new System.Drawing.Size(688, 439);
			this.Name = "UserAdminForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Users & Roles";
			this._topPanel.ResumeLayout(false);
			this._topPanel.PerformLayout();
			this._tabs.ResumeLayout(false);
			this._tabUsers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._gridUsers)).EndInit();
			this._tabAudit.ResumeLayout(false);
			this._tlpAudit.ResumeLayout(false);
			this._tlpAudit.PerformLayout();
			this._auditTop.ResumeLayout(false);
			this._auditTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridAudit)).EndInit();
			this._bottomPanel.ResumeLayout(false);
			this._bottomPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _topPanel;
		private System.Windows.Forms.Button _btnAdd;
		private System.Windows.Forms.Button _btnEdit;
		private System.Windows.Forms.Button _btnRefresh;
		private System.Windows.Forms.TabControl _tabs;
		private System.Windows.Forms.TabPage _tabUsers;
		private System.Windows.Forms.DataGridView _gridUsers;
		private System.Windows.Forms.TabPage _tabAudit;
		private System.Windows.Forms.TableLayoutPanel _tlpAudit;
		private System.Windows.Forms.DataGridView _gridAudit;
		private System.Windows.Forms.TableLayoutPanel _auditTop;
		private System.Windows.Forms.Label _lblAuditFrom;
		private System.Windows.Forms.DateTimePicker _dtpAuditFrom;
		private System.Windows.Forms.Label _lblAuditTo;
		private System.Windows.Forms.DateTimePicker _dtpAuditTo;
		private System.Windows.Forms.Button _btnLoadAudit;
		private System.Windows.Forms.TableLayoutPanel _bottomPanel;
		private System.Windows.Forms.Label _lblStatus;
		private System.Windows.Forms.Button _btnClose;
	}
}