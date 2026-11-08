using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class ProductEditorForm : Form
	{
		private readonly InventoryService inventory = new InventoryService();
		private readonly Product editing;
		private readonly ErrorProvider errors = new ErrorProvider();

		// The image the user picked. It is copied to the media folder only when Save is clicked.
		private string pickedImagePath;

		// Pass null to add a new product, or an existing product to edit it.
		public ProductEditorForm(Product product)
		{
			InitializeComponent();
			editing = product;

			Text = product == null ? "Add Product" : "Edit Product";
			Load += (s, e) => LoadForm();
			btnBrowse.Click += (s, e) => BrowseImage();
			btnSave.Click += (s, e) => SaveProduct();
			FormClosed += (s, e) => ClearPreview();
		}

		private void LoadForm()
		{
			try
			{
				cboCategory.DisplayMember = "Name";
				cboCategory.ValueMember = "Id";
				cboCategory.DataSource = inventory.GetCategories();

				if (editing != null)
				{
					txtSku.Text = editing.Sku ?? string.Empty;
					txtBarcode.Text = editing.Barcode ?? string.Empty;
					txtName.Text = editing.Name ?? string.Empty;
					cboCategory.SelectedValue = editing.CategoryId;
					txtCost.Text = editing.Cost.ToString("0.00", CultureInfo.InvariantCulture);
					txtPrice.Text = editing.Price.ToString("0.00", CultureInfo.InvariantCulture);
					txtStock.Text = editing.StockQty.ToString(CultureInfo.InvariantCulture);
					txtReorder.Text = editing.ReorderLevel.ToString(CultureInfo.InvariantCulture);
					chkActive.Checked = editing.IsActive;

					string existing = ProductImageStorage.FullPath(editing.ImagePath);
					if (existing != null && File.Exists(existing))
					{
						ShowPreview(existing);
					}
				}
			}
			catch (Exception ex)
			{
				lblStatus.Text = ErrorMessages.For(ex);
				btnSave.Enabled = false;
			}
		}

		private void BrowseImage()
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Title = "Choose product image";
				dialog.Filter = "Images (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
				dialog.CheckFileExists = true;

				if (dialog.ShowDialog(this) != DialogResult.OK)
					return;

				try
				{
					ShowPreview(dialog.FileName);
					pickedImagePath = dialog.FileName;
					lblStatus.Text = string.Empty;
				}
				catch (Exception)
				{
					lblStatus.Text = "That file could not be opened as an image.";
				}
			}
		}

		// Loads a copy of the image, so the file is not locked on disk.
		private void ShowPreview(string path)
		{
			Bitmap copy;
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			using (var image = Image.FromStream(stream))
			{
				copy = new Bitmap(image);
			}

			ClearPreview();
			picPreview.Image = copy;
		}

		private void ClearPreview()
		{
			Image old = picPreview.Image;
			picPreview.Image = null;
			if (old != null)
			{
				old.Dispose();
			}
		}

		private void SaveProduct()
		{
			decimal cost;
			decimal price;
			int stock;
			int reorder;

			if (!ValidateInputs(out cost, out price, out stock, out reorder))
			{
				lblStatus.Text = "Please fix the highlighted fields.";
				return;
			}

			var product = new Product
			{
				Id = editing == null ? 0 : editing.Id,
				Sku = txtSku.Text.Trim(),
				Barcode = txtBarcode.Text.Trim(),
				Name = txtName.Text.Trim(),
				CategoryId = (int)cboCategory.SelectedValue,
				Cost = cost,
				Price = price,
				StockQty = stock,
				ReorderLevel = reorder,
				IsActive = chkActive.Checked,
				// Keeps the existing image unless a new one was picked.
				ImagePath = editing == null ? null : editing.ImagePath
			};

			try
			{
				// Copy the picked image to the media folder first. Validation rules are in ProductImageStorage.
				if (pickedImagePath != null)
				{
					product.ImagePath = ProductImageStorage.Import(pickedImagePath);
				}

				inventory.Save(product);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (IOException)
			{
				lblStatus.Text = "Could not copy the image. Check the media folder permissions.";
			}
			catch (Exception ex)
			{
				lblStatus.Text = ErrorMessages.For(ex);
			}
		}

		// Checks every field, marks the bad ones with a red icon and a message, and returns true only when all are valid.
		private bool ValidateInputs(out decimal cost, out decimal price, out int stock, out int reorder)
		{
			errors.Clear();
			bool ok = true;
			cost = 0m;
			price = 0m;
			stock = 0;
			reorder = 0;

			string sku = txtSku.Text.Trim();
			if (sku.Length == 0)
				ok = Invalid(txtSku, "SKU is required.");
			else if (sku.Length > 30)
				ok = Invalid(txtSku, "SKU must be 30 characters or fewer.");

			string name = txtName.Text.Trim();
			if (name.Length == 0)
				ok = Invalid(txtName, "Product name is required.");
			else if (name.Length > 150)
				ok = Invalid(txtName, "Product name must be 150 characters or fewer.");

			if (txtBarcode.Text.Trim().Length > 50)
				ok = Invalid(txtBarcode, "Barcode must be 50 characters or fewer.");

			if (cboCategory.SelectedValue == null)
				ok = Invalid(cboCategory, "Choose a category.");

			if (!decimal.TryParse(txtCost.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out cost))
				ok = Invalid(txtCost, "Enter a number, such as 12.50.");
			else if (cost < 0)
				ok = Invalid(txtCost, "Cost cannot be negative.");

			if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out price))
				ok = Invalid(txtPrice, "Enter a number, such as 12.50.");
			else if (price < 0)
				ok = Invalid(txtPrice, "Selling price cannot be negative.");

			if (!int.TryParse(txtStock.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out stock))
				ok = Invalid(txtStock, "Enter a whole number.");
			else if (stock < 0)
				ok = Invalid(txtStock, "Stock cannot be negative.");

			if (!int.TryParse(txtReorder.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out reorder))
				ok = Invalid(txtReorder, "Enter a whole number.");
			else if (reorder < 0)
				ok = Invalid(txtReorder, "Reorder level cannot be negative.");

			return ok;
		}

		// Marks one field with a message and returns false, so the caller can record the failure.
		private bool Invalid(Control control, string message)
		{
			errors.SetError(control, message);
			return false;
		}
	}
}