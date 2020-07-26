namespace MyPhotoshop
{
	public class GrayscaleFilter: PixelFilter
	{
		public GrayscaleFilter() : base(new GrayScaleParameters()) { }
		
		public override string ToString() => "Черно/Белый";

		public override Pixel ProcessFilter(Pixel original, IParameters parameters)
		{
			var lightness = original.R + original.B + original.G;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
		}
	}
}