namespace MyPhotoshop
{
	public class GrayscaleFilter: PixelFilter
	{
		public override ParameterInfo[] GetParameters() =>  new ParameterInfo[]{};

		public override string ToString() => "Черно/Белый";

		public override Pixel ProcessFilter(Pixel original, double[] parameters)
		{
			var lightness = original.R + original.B + original.G;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
		}
	}
}