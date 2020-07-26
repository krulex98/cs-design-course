namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
		public override ParameterInfo[] GetParameters()
		{
			return new[]
			{
				new ParameterInfo {Name = "Коэффициент", MaxValue = 10, MinValue = 0, Increment = 0.1, DefaultValue = 1}
			};
		}

		public override string ToString() => "Осветление/затемнение";

		public override Pixel ProcessFilter(Pixel original, double[] parameters)
		{
			return original * parameters[0];
		}
	}
}