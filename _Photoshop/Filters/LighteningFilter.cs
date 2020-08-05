namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LighteningParameters>
	{
		public override string ToString() => "Осветление/затемнение";

		public override Pixel ProcessFilter(Pixel original, LighteningParameters parameters)
		{
			return original * parameters.Coefficient;
		}
	}
}