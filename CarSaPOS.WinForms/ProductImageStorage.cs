using System;
using System.Drawing;
using System.IO;

namespace CarSaPOS.WinForms
{
	// Validates a chosen image, copies it to the application media folder,
	// and returns the relative path to store in Products.ImagePath.
	public static class ProductImageStorage
	{
		public const long MaxFileBytes = 2 * 1024 * 1024;
		public const int MaxWidth = 2000;
		public const int MaxHeight = 2000;

		private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };

		public static string MediaRoot
		{
			get
			{
				return Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
					"CarSaPOS", "Media");
			}
		}

		// Returns a relative path such as "products\<guid>.jpg".
		public static string Import(string sourcePath)
		{
			if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
				throw new ArgumentException("Choose an image file.");

			string extension = Path.GetExtension(sourcePath).ToLowerInvariant();
			if (Array.IndexOf(AllowedExtensions, extension) < 0)
				throw new ArgumentException("Only .jpg, .jpeg, and .png images are allowed.");

			var info = new FileInfo(sourcePath);
			if (info.Length == 0 || info.Length > MaxFileBytes)
				throw new ArgumentException("The image must be 2 MB or smaller.");

			if (!HasImageSignature(sourcePath, extension))
				throw new ArgumentException("The file is not a valid JPEG or PNG image.");

			try
			{
				using (var image = Image.FromFile(sourcePath))
				{
					if (image.Width > MaxWidth || image.Height > MaxHeight)
						throw new ArgumentException("The image must be 2000 x 2000 pixels or smaller.");
				}
			}
			catch (OutOfMemoryException)
			{
				throw new ArgumentException("The file is not a valid image.");
			}

			string folder = Path.Combine(MediaRoot, "products");
			Directory.CreateDirectory(folder);

			// Server-side name only. The original file name is never used.
			string fileName = Guid.NewGuid().ToString("N") + (extension == ".png" ? ".png" : ".jpg");
			File.Copy(sourcePath, Path.Combine(folder, fileName), false);

			return Path.Combine("products", fileName);
		}

		// Converts a stored relative path into a full path. Returns null when there is no image.
		public static string FullPath(string relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath))
				return null;
			return Path.Combine(MediaRoot, relativePath);
		}

		// Checks the file's first bytes, so a renamed .exe cannot pass as .jpg or .png.
		private static bool HasImageSignature(string path, string extension)
		{
			byte[] header = new byte[8];
			using (var stream = File.OpenRead(path))
			{
				if (stream.Read(header, 0, header.Length) < 3)
					return false;
			}

			if (extension == ".png")
			{
				return header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47;
			}

			return header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
		}
	}
}