using System;
using System.Windows.Forms;
using CarSaPOS.Data;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	// Used for both adding a user (existing is null) and editing one.
	public partial class UserEditorForm : Form
	{
		private readonly UserAdminService _service = new UserAdminService();
		private readonly UserListRow _existing;

		public UserEditorForm(UserListRow existing)
		{
			InitializeComponent();
			_existing = existing;

			Load += OnLoad;
			_chkResetPassword.CheckedChanged += (s, e) => UpdatePasswordState();
			_btnSave.Click += (s, e) => Save();
		}

		private bool IsNew
		{
			get { return _existing == null; }
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (DesignMode) return;

			try
			{
				_cboRole.DataSource = _service.GetRoles();
				_cboRole.DisplayMember = "RoleName";
				_cboRole.ValueMember = "RoleId";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMessages.For(ex), "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				DialogResult = DialogResult.Cancel;
				Close();
				return;
			}

			if (IsNew)
			{
				Text = "Add User";
				_txtUsername.ReadOnly = false;
				_chkActive.Checked = true;
				_chkResetPassword.Visible = false;
				_chkResetPassword.Checked = true;
				_cboRole.SelectedValue = (int)UserRole.Cashier;
			}
			else
			{
				Text = "Edit User";
				_txtUsername.Text = _existing.Username;
				_txtUsername.ReadOnly = true;
				_txtFullName.Text = _existing.FullName;
				_cboRole.SelectedValue = _existing.RoleId;
				_chkActive.Checked = _existing.IsActive;
				_chkResetPassword.Checked = false;
			}

			UpdatePasswordState();
		}

		// The password box is used when adding a user, or when "Set a new password" is ticked.
		private void UpdatePasswordState()
		{
			bool passwordWanted = IsNew || _chkResetPassword.Checked;
			_txtPassword.Enabled = passwordWanted;
			if (!passwordWanted) _txtPassword.Clear();
		}

		private void Save()
		{
			try
			{
				UserRole role = SelectedRole();

				if (IsNew)
				{
					_service.CreateUser(_txtUsername.Text, _txtFullName.Text, role, _txtPassword.Text, _chkActive.Checked);
				}
				else
				{
					_service.UpdateUser(_existing.Id, _txtFullName.Text, role, _chkActive.Checked);
					if (_chkResetPassword.Checked)
					{
						_service.ResetPassword(_existing.Id, _txtPassword.Text);
					}
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMessages.For(ex), "User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private UserRole SelectedRole()
		{
			if (_cboRole.SelectedValue == null)
				throw new ArgumentException("Choose a role.");
			return (UserRole)(int)_cboRole.SelectedValue;
		}
	}
}