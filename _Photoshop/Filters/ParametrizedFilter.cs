namespace MyPhotoshop
{
	public abstract class ParametrizedFilter<TParameters>: IFilter
		where TParameters: class, IParameters, new()
	{
		public ParameterInfo[] GetParameters()
		{
			return new TParameters().GetDescription();
		}

		protected abstract Photo Process(Photo photo, TParameters parameters);

		public Photo Process(Photo photo, double[] parameters)
		{
			var tParams = new TParameters();
			tParams.Parse(parameters);
			return Process(photo, tParams);
		}

		public abstract Pixel ProcessFilter(Pixel original, TParameters parameters);
	}
}