namespace MyPhotoshop
{
	public class GrayScaleParameters : IParameters
	{
		public double Coefficient { get; private set; }
		
		public ParameterInfo[] GetDescription()
		{
			return new ParameterInfo[]{};
		}

		public void Parse(double[] parameters)
		{
			Coefficient = 0;
		}
	}
}