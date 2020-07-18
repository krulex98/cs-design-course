using System;
using System.Drawing;

namespace MyPhotoshop
{
	public static class Convertors
	{
		public static Photo Bitmap2Photo(Bitmap bmp)
		{
			var photo = new Photo();
			photo.width = bmp.Width;
			photo.height = bmp.Height;
			photo.data = new Pixel[bmp.Width, bmp.Height];
			for (var x = 0; x < bmp.Width; x++)
				for (var y = 0; y < bmp.Height; y++)
				{
					var pixel = bmp.GetPixel(x, y);
					photo.data[x, y] = new Pixel
					{
						R = (double) pixel.R / 255,
						G = (double) pixel.G / 255,
						B = (double) pixel.B / 255
					};
				}

			return photo;
		}

		static int ToChannel(double val) => (int) (val * 255);

		public static Bitmap Photo2Bitmap(Photo photo)
		{
			var bmp = new Bitmap(photo.width, photo.height);
			for (int x = 0; x < bmp.Width; x++)
				for (int y = 0; y < bmp.Height; y++)
					bmp.SetPixel(x, y, Color.FromArgb(
						ToChannel(photo.data[x, y].R),
						ToChannel(photo.data[x, y].G),
						ToChannel(photo.data[x, y].B)));

			return bmp;
		}
	}
}