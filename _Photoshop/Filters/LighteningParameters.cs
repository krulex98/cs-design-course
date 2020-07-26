namespace MyPhotoshop
{
	public class LighteningParameters: IParameters
	{
		public double Coefficient { get; private set; }

		public ParameterInfo[] GetDescription()
		{
			return new[]
			{
				new ParameterInfo {Name = "Коэффициент", MaxValue = 10, MinValue = 0, Increment = 0.1, DefaultValue = 1}
			};
		}

		public void Parse(double[] parameters)
		{
			Coefficient = parameters[0];
		}
	}
}