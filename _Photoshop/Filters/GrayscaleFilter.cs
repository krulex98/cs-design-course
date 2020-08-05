namespace MyPhotoshop
{
	public class GrayscaleFilter: PixelFilter<GrayScaleParameters>
	{
		public override string ToString() => "Черно/Белый";

		public override Pixel ProcessFilter(Pixel original, GrayScaleParameters parameters)
		{
			var lightness = original.R + original.B + original.G;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
		}
	}
}