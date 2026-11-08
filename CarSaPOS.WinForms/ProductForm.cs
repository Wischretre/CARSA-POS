using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CarSaPOS.Data;
using CarSaPOS.Domain;
using CarSaPOS.Services;

namespace CarSaPOS.WinForms
{
	public partial class ProductForm : Form
	{
		private const string ThumbnailColumnName = "colThumbnail";

		private readonly InventoryService inventory = new InventoryService();

		// Thumbnails are loaded once per image path, then reused.
		private readonly Dictionary<string, Image> thumbnails = new Dictionary<string, Image>();

		public ProductForm()
		{
			InitializeComponent();

			AddThumbnailColumn();

			Load += (s, e) => LoadProducts();
			FormClosed += (s, e) => ClearThumbnails();
			btnSearch.Click += (s, e) => LoadProducts();
			btnRefresh.Click += (s, e) => LoadProducts();
			txtSearch.KeyDown += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					e.SuppressKeyPress = true;
					LoadProducts();
				}
			};
			chkLowStock.CheckedChanged += (s, e) => LoadProducts();
			chkInactive.CheckedChanged += (s, e) => LoadProducts();
			btnAdd.Click += (s, e) => AddProduct();
			btnEdit.Click += (s, e) => EditProduct();
			grid.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditProduct(); };
			grid.RowPrePaint += GridRowPrePaint;
			grid.DataError += GridDataError;
			btnClose.Click += (s, e) => Close();
		}

		// Adds the image column as the first column. It shows a thumbnail for each product.
		private void AddThumbnailColumn()
		{
			var column = new DataGridViewImageColumn
			{
				Name = ThumbnailColumnName,
				HeaderText = "Image",
				ImageLayout = DataGridViewImageCellLayout.Zoom,
				ReadOnly = true,
				Width = 60
			};
			grid.RowTemplate.Height = 56;
			grid.Columns.Insert(0, column);
		}

		private void LoadProducts()
		{
			try
			{
				grid.DataSource = inventory.Search(txtSearch.Text, chkLowStock.Checked, chkInactive.Checked);

				HideColumn("Id");
				HideColumn("CategoryId");
				HideColumn("Cost");
				HideColumn("IsLowStock");
				HideColumn("ImagePath");

				FillThumbnails();

				lblStatus.Text = grid.Rows.Count + " product(s) found.";
			}
			catch (UnauthorizedAccessException ex)
			{
				lblStatus.Text = ex.Message;
			}
			catch (Exception)
			{
				lblStatus.Text = "Unable to load products. Contact the administrator.";
			}
		}

		private void HideColumn(string name)
		{
			if (grid.Columns.Contains(name))
			{
				grid.Columns[name].Visible = false;
			}
		}

		// Sets the thumbnail cell for each row after the data is loaded.
		private void FillThumbnails()
		{
			foreach (DataGridViewRow row in grid.Rows)
			{
				var item = row.DataBoundItem as ProductListItem;
				row.Cells[ThumbnailColumnName].Value = item == null ? null : GetThumbnail(item.ImagePath);
			}
		}

		private Image GetThumbnail(string relativePath)
		{
			string fullPath = ProductImageStorage.FullPath(relativePath);
			if (fullPath == null || !File.Exists(fullPath))
				return null;

			Image cached;
			if (thumbnails.TryGetValue(fullPath, out cached))
				return cached;

			try
			{
				// Loads a copy, so the file is not locked on disk.
				using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
				using (var image = Image.FromStream(stream))
				{
					Image copy = new Bitmap(image);
					thumbnails[fullPath] = copy;
					return copy;
				}
			}
			catch (Exception)
			{
				// A damaged or missing file shows an empty cell instead of failing the grid.
				return null;
			}
		}

		private void ClearThumbnails()
		{
			foreach (Image image in thumbnails.Values)
			{
				image.Dispose();
			}
			thumbnails.Clear();
		}

		// Stops the default error pop-up. Problem cells are skipped quietly.
		private void GridDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
		}

		// Highlights low-stock rows, as in the tutorial's sample screen.
		private void GridRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			var item = grid.Rows[e.RowIndex].DataBoundItem as ProductListItem;
			if (item != null && item.IsLowStock)
			{
				grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
				grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
			}
		}

		private void AddProduct()
		{
			using (var editor = new ProductEditorForm(null))
			{
				if (editor.ShowDialog(this) == DialogResult.OK)
				{
					LoadProducts();
				}
			}
		}

		private void EditProduct()
		{
			var item = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as ProductListItem;
			if (item == null)
			{
				lblStatus.Text = "Select a product first.";
				return;
			}

			try
			{
				Product product = inventory.GetById(item.Id);
				if (product == null)
				{
					lblStatus.Text = "That product no longer exists. Refresh the list.";
					return;
				}

				using (var editor = new ProductEditorForm(product))
				{
					if (editor.ShowDialog(this) == DialogResult.OK)
					{
						LoadProducts();
					}
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				lblStatus.Text = ex.Message;
			}
			catch (Exception)
			{
				lblStatus.Text = "Unable to open the product. Contact the administrator.";
			}
		}
	}
}