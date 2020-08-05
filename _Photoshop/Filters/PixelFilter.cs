namespace MyPhotoshop
{
	public abstract class PixelFilter<TParameters>: ParametrizedFilter<TParameters>
		where TParameters: class, IParameters, new()
	{
		protected override Photo Process(Photo original, TParameters parameters)
		{
			var result = new Photo(original.Width, original.Height);
			
			for (var x = 0; x < result.Width; x++)
				for (var y = 0; y < result.Height; y++)
					result[x, y] = ProcessFilter(original[x, y], parameters);

			return result;
		}
	}
}