using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Geometry
{
	public class Body
	{
		public double GetVolume()
		{
			if (this is Ball)
				return 4.0 * Math.PI * Math.Pow(((Ball) this).Radius, 3) / 3;
			if (this is Cube)
				return Math.Pow(((Cube) this).Size, 3);
			if (this is Cylinder)
			{
				var c = this as Cylinder;
				return Math.PI * Math.Pow(c.Radius, 2) * c.Height;
			}

			throw new Exception();
		}
	}

	public class Ball : Body
	{
		public double Radius { get; set; }
	}

	public class Cube : Body
	{
		public double Size { get; set; }
	}

	public class Cylinder : Body
	{
		public double Height { get; set; }
		public double Radius { get; set; }
	}

	// Заготовка класса для задачи на Visitor
	public class SurfaceAreaVisitor
	{
		public double SurfaceArea { get; private set; }
	}

	public class DimensionsVisitor
	{
		public Dimensions Dimensions { get; private set; }
	}
}