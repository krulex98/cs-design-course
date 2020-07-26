namespace MyPhotoshop
{
	public abstract class PixelFilter: ParametrizedFilter
	{
		protected PixelFilter(IParameters parameters) : base(parameters)
		{
		}
		
		protected override Photo Process(Photo original, IParameters parameters)
		{
			var result = new Photo(original.Width, original.Height);
			
			for (var x = 0; x < result.Width; x++)
				for (var y = 0; y < result.Height; y++)
					result[x, y] = ProcessFilter(original[x, y], parameters);

			return result;
		}
	}
}