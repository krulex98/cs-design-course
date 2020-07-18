namespace MyPhotoshop
{
	public class Pixel
	{
		public double R;
		public double G;
		public double B;

		public Pixel(double r = 0, double g = 0, double b = 0)
		{
			R = r;
			G = g;
			B = b;
		}

		public static Pixel operator *(Pixel p, double val)
		{
			p.R *= val;
			p.B *= val;
			p.G *= val;
			return p;
		}
	}
}