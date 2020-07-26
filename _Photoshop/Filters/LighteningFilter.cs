namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
		public LighteningFilter() : base(new LighteningParameters()) { }

		public override string ToString() => "Осветление/затемнение";

		public override Pixel ProcessFilter(Pixel original, IParameters parameters)
		{
			return original * ((LighteningParameters) parameters).Coefficient;
		}
	}
}