namespace MyPhotoshop
{
	public interface IParameters
	{
		ParameterInfo[] GetDescription();
		void Parse(double[] parameters);
	}
}