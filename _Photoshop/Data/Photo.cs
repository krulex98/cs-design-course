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
			
			for(var x = 0; x < w; x++)
				for (var y = 0; y < h; y++)
					_data[x, y] = new Pixel();
		}
		
		public Pixel this[int x, int y] => _data[x, y];
	}
}