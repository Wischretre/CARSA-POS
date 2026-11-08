using System.Windows.Forms;

namespace CarSaPOS.WinForms
{
	partial class UserEditorForm
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
			this._tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this._tlpFields = new System.Windows.Forms.TableLayoutPanel();
			this._tlpBottom = new System.Windows.Forms.TableLayoutPanel();
			this._lblUsername = new System.Windows.Forms.Label();
			this._txtUsername = new System.Windows.Forms.TextBox();
			this._lblFullName = new System.Windows.Forms.Label();
			this._txtFullName = new System.Windows.Forms.TextBox();
			this._lblRole = new System.Windows.Forms.Label();
			this._cboRole = new System.Windows.Forms.ComboBox();
			this._chkActive = new System.Windows.Forms.CheckBox();
			this._chkResetPassword = new System.Windows.Forms.CheckBox();
			this._lblPassword = new System.Windows.Forms.Label();
			this._txtPassword = new System.Windows.Forms.TextBox();
			this._lblHint = new System.Windows.Forms.Label();
			this._btnSave = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._tlpMain.SuspendLayout();
			this._tlpFields.SuspendLayout();
			this._tlpBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tlpMain: row 0 = fields (fills), row 1 = Save and Cancel (auto)
			// 
			this._tlpMain.ColumnCount = 1;
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpMain.RowCount = 2;
			this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpMain.Controls.Add(this._tlpFields, 0, 0);
			this._tlpMain.Controls.Add(this._tlpBottom, 0, 1);
			this._tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpMain.Name = "_tlpMain";
			this._tlpMain.Padding = new System.Windows.Forms.Padding(12);
			// 
			// _tlpFields: label column (auto) and input column (fills), seven field rows plus a filler row
			// 
			this._tlpFields.ColumnCount = 2;
			this._tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpFields.RowCount = 8;
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpFields.Controls.Add(this._lblUsername, 0, 0);
			this._tlpFields.Controls.Add(this._txtUsername, 1, 0);
			this._tlpFields.Controls.Add(this._lblFullName, 0, 1);
			this._tlpFields.Controls.Add(this._txtFullName, 1, 1);
			this._tlpFields.Controls.Add(this._lblRole, 0, 2);
			this._tlpFields.Controls.Add(this._cboRole, 1, 2);
			this._tlpFields.Controls.Add(this._chkActive, 1, 3);
			this._tlpFields.Controls.Add(this._chkResetPassword, 1, 4);
			this._tlpFields.Controls.Add(this._lblPassword, 0, 5);
			this._tlpFields.Controls.Add(this._txtPassword, 1, 5);
			this._tlpFields.Controls.Add(this._lblHint, 1, 6);
			this._tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpFields.Name = "_tlpFields";
			// 
			// _tlpBottom: empty filler (fills), Save and Cancel on the right
			// 
			this._tlpBottom.ColumnCount = 3;
			this._tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpBottom.RowCount = 1;
			this._tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this._tlpBottom.Controls.Add(this._btnSave, 1, 0);
			this._tlpBottom.Controls.Add(this._btnCancel, 2, 0);
			this._tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpBottom.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this._tlpBottom.Name = "_tlpBottom";
			// 
			// _lblUsername
			// 
			this._lblUsername.AutoSize = true;
			this._lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblUsername.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this._lblUsername.Name = "_lblUsername";
			this._lblUsername.Text = "Username:";
			// 
			// _txtUsername
			// 
			this._txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txtUsername.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this._txtUsername.Name = "_txtUsername";
			// 
			// _lblFullName
			// 
			this._lblFullName.AutoSize = true;
			this._lblFullName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblFullName.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this._lblFullName.Name = "_lblFullName";
			this._lblFullName.Text = "Full name:";
			// 
			// _txtFullName
			// 
			this._txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txtFullName.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this._txtFullName.Name = "_txtFullName";
			// 
			// _lblRole
			// 
			this._lblRole.AutoSize = true;
			this._lblRole.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblRole.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this._lblRole.Name = "_lblRole";
			this._lblRole.Text = "Role:";
			// 
			// _cboRole
			// 
			this._cboRole.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboRole.FormattingEnabled = true;
			this._cboRole.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this._cboRole.Name = "_cboRole";
			// 
			// _chkActive
			// 
			this._chkActive.AutoSize = true;
			this._chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._chkActive.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this._chkActive.Name = "_chkActive";
			this._chkActive.Text = "Active";
			this._chkActive.UseVisualStyleBackColor = true;
			// 
			// _chkResetPassword
			// 
			this._chkResetPassword.AutoSize = true;
			this._chkResetPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._chkResetPassword.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this._chkResetPassword.Name = "_chkResetPassword";
			this._chkResetPassword.Text = "Set a new password";
			this._chkResetPassword.UseVisualStyleBackColor = true;
			// 
			// _lblPassword
			// 
			this._lblPassword.AutoSize = true;
			this._lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblPassword.Margin = new System.Windows.Forms.Padding(0, 6, 8, 6);
			this._lblPassword.Name = "_lblPassword";
			this._lblPassword.Text = "Password:";
			// 
			// _txtPassword
			// 
			this._txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txtPassword.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this._txtPassword.Name = "_txtPassword";
			this._txtPassword.PasswordChar = '*';
			// 
			// _lblHint
			// 
			this._lblHint.AutoSize = true;
			this._lblHint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._lblHint.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this._lblHint.Name = "_lblHint";
			this._lblHint.Text = "At least 8 plain characters.";
			// 
			// _btnSave
			// 
			this._btnSave.AutoSize = true;
			this._btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._btnSave.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this._btnSave.MinimumSize = new System.Drawing.Size(70, 30);
			this._btnSave.Name = "_btnSave";
			this._btnSave.Text = "Save";
			this._btnSave.UseVisualStyleBackColor = true;
			// 
			// _btnCancel
			// 
			this._btnCancel.AutoSize = true;
			this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this._btnCancel.MinimumSize = new System.Drawing.Size(70, 30);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// UserEditorForm
			// 
			this.AcceptButton = this._btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(460, 340);
			this.Controls.Add(this._tlpMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 340);
			this.Name = "UserEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User";
			this._tlpMain.ResumeLayout(false);
			this._tlpMain.PerformLayout();
			this._tlpFields.ResumeLayout(false);
			this._tlpFields.PerformLayout();
			this._tlpBottom.ResumeLayout(false);
			this._tlpBottom.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _tlpMain;
		private System.Windows.Forms.TableLayoutPanel _tlpFields;
		private System.Windows.Forms.TableLayoutPanel _tlpBottom;
		private System.Windows.Forms.Label _lblUsername;
		private System.Windows.Forms.TextBox _txtUsername;
		private System.Windows.Forms.Label _lblFullName;
		private System.Windows.Forms.TextBox _txtFullName;
		private System.Windows.Forms.Label _lblRole;
		private System.Windows.Forms.ComboBox _cboRole;
		private System.Windows.Forms.CheckBox _chkActive;
		private System.Windows.Forms.CheckBox _chkResetPassword;
		private System.Windows.Forms.Label _lblPassword;
		private System.Windows.Forms.TextBox _txtPassword;
		private System.Windows.Forms.Label _lblHint;
		private System.Windows.Forms.Button _btnSave;
		private System.Windows.Forms.Button _btnCancel;
	}
}