namespace MyPhotoshop
{
	public abstract class ParametrizedFilter: IFilter
	{
		private readonly IParameters _parameters;

		public ParametrizedFilter(IParameters parameters)
		{
			_parameters = parameters;
		}

		public ParameterInfo[] GetParameters()
		{
			return _parameters.GetDescription();
		}

		protected abstract Photo Process(Photo photo, IParameters parameters);

		public Photo Process(Photo photo, double[] parameters)
		{
			_parameters.Parse(parameters);
			return Process(photo, _parameters);
		}

		public abstract Pixel ProcessFilter(Pixel original, IParameters parameters);
	}
}