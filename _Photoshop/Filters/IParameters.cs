namespace MyPhotoshop
{
	public interface IParameters
	{
		double Coefficient { get; }
		ParameterInfo[] GetDescription();
		void Parse(double[] parameters);
	}
}