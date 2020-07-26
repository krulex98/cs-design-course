
namespace MyPhotoshop
{
	public interface IFilter
	{
		ParameterInfo[] GetParameters();
		
		Photo Process(Photo original, double[] parameters);

		Pixel ProcessFilter(Pixel original, double[] parameters);
	}
}