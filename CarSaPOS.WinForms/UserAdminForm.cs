using System;
using System.Linq;
using System.Windows.Forms;
using CarSaPOS.Data;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class UserAdminForm : Form
	{
		private readonly UserAdminService _service = new UserAdminService();

		public UserAdminForm()
		{
			InitializeComponent();

			ConfigureGrid(_gridUsers);
			ConfigureGrid(_gridAudit);

			Load += OnLoad;
			_btnAdd.Click += (s, e) => AddUser();
			_btnEdit.Click += (s, e) => EditSelected();
			_btnRefresh.Click += (s, e) => LoadUsers();
			_gridUsers.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditSelected(); };
			_btnLoadAudit.Click += (s, e) => LoadAudit();
			_btnClose.Click += (s, e) => Close();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (DesignMode) return;

			_dtpAuditFrom.Value = DateTime.Today.AddDays(-29);
			_dtpAuditTo.Value = DateTime.Today;
			LoadUsers();
			LoadAudit();
		}

		private void LoadUsers()
		{
			try
			{
				var users = _service.GetUsers();
				_gridUsers.DataSource = users;
				HideColumn(_gridUsers, "Id", "RoleId");
				SetFormat(_gridUsers, "yyyy-MM-dd HH:mm", "LastLoginAt", "CreatedAt");
				SetStatus(users.Count + " user(s).");
			}
			catch (Exception ex)
			{
				ShowError(ex);
			}
		}

		private void LoadAudit()
		{
			try
			{
				var from = _dtpAuditFrom.Value.Date;
				var to = _dtpAuditTo.Value.Date;
				_gridAudit.DataSource = _service.GetAuditHistory(from, to, null);
				HideColumn(_gridAudit, "AuditId");
				SetFormat(_gridAudit, "yyyy-MM-dd HH:mm", "OccurredAt");
			}
			catch (Exception ex)
			{
				ShowError(ex);
			}
		}

		private void AddUser()
		{
			using (var editor = new UserEditorForm(null))
			{
				if (editor.ShowDialog(this) == DialogResult.OK)
				{
					LoadUsers();
					LoadAudit();
					SetStatus("User created.");
				}
			}
		}

		private void EditSelected()
		{
			var row = _gridUsers.CurrentRow == null ? null : _gridUsers.CurrentRow.DataBoundItem as UserListRow;
			if (row == null)
			{
				SetStatus("Select a user first.");
				return;
			}

			using (var editor = new UserEditorForm(row))
			{
				if (editor.ShowDialog(this) == DialogResult.OK)
				{
					LoadUsers();
					LoadAudit();
					SetStatus("User saved.");
				}
			}
		}

		private void SetStatus(string text)
		{
			_lblStatus.Text = text;
		}

		private void ShowError(Exception ex)
		{
			MessageBox.Show(ErrorMessages.For(ex), "Users && Roles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private static void HideColumn(DataGridView grid, params string[] names)
		{
			foreach (var name in names)
			{
				var column = grid.Columns[name];
				if (column != null) column.Visible = false;
			}
		}

		private static void SetFormat(DataGridView grid, string format, params string[] names)
		{
			foreach (var name in names)
			{
				var column = grid.Columns[name];
				if (column != null) column.DefaultCellStyle.Format = format;
			}
		}
	}
}