using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int Width;
		public readonly int Height;
		
		private readonly Pixel[,] _data;

		public Photo(int w, int h)
		{
			Width = w;
			Height = h;
			_data = new Pixel[w, h];
		}

		public Pixel this[int x, int y]
		{
			get => _data[x, y];
			set => _data[x, y] = value;
		}
	}
}