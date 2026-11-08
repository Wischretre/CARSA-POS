using System;
using System.Windows.Forms;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class LoginForm : Form
	{
		private readonly AuthService auth = new AuthService();

		public LoginForm()
		{
			InitializeComponent();
			btnLogin.Click += LoginClicked;
		}

		private void LoginClicked(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text;

			if (username.Length == 0 || password.Length == 0)
			{
				lblStatus.Text = "Enter your username and password.";
				return;
			}

			try
			{
				User user = auth.Login(username, password);
				if (user == null)
				{
					// Same message for wrong password, unknown user, or inactive account.
					lblStatus.Text = "Invalid credentials or inactive user.";
					txtPassword.Clear();
					return;
				}

				lblStatus.Text = string.Empty;
				Hide();
				using (var main = new MainForm())
				{
					main.ShowDialog(this);
				}
				auth.Logout();
				txtPassword.Clear();
				txtUsername.Clear();
				Show();
				txtUsername.Focus();
			}
			catch (Exception)
			{
				// Hides connection strings and SQL details from the user.
				lblStatus.Text = "Unable to connect. Contact the administrator.";
			}
		}
	}
}