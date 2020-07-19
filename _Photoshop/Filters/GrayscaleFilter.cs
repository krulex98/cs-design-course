namespace MyPhotoshop
{
	public class GrayscaleFilter: IFilter
	{
		public ParameterInfo[] GetParameters() =>  new ParameterInfo[]{};

		public override string ToString() => "Черно/Белый";

		public Photo Process(Photo original, double[] parameters)
		{
			var result = new Photo(original.Width, original.Height);
			
			for (var x = 0; x < result.Width; x++)
				for (var y = 0; y < result.Height; y++)
				{
					var lightness = original[x, y].R + original[x, y].B + original[x, y].G;
					lightness /= 3;
					result[x, y] = new Pixel(lightness, lightness, lightness);
				} 

			return result;
		}
	}
}