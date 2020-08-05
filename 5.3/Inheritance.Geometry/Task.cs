using System;

namespace Inheritance.Geometry
{
	public abstract class Body
	{
		public abstract double GetVolume();

		public abstract void Accept(IVisitor visitor);
	}

	public class Ball : Body
	{
		public double Radius { get; set; }

		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override double GetVolume()
		{
			return 4.0 * Math.PI * Math.Pow(Radius, 3) / 3;
		}
	}

	public class Cube : Body
	{
		public double Size { get; set; }
		
		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
		
		public override double GetVolume()
		{
			return Math.Pow(Size, 3);
		}
	}

	public class Cylinder : Body
	{
		public double Height { get; set; }
		public double Radius { get; set; }
		
		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
		
		public override double GetVolume()
		{
			return Math.PI * Math.Pow(Radius, 2) * Height;
		}
	}

	public interface IVisitor
	{
		void Visit(Ball ball);
		void Visit(Cube cube);
		void Visit(Cylinder cylinder);
	}
	
	public class SurfaceAreaVisitor: IVisitor
	{
		public double SurfaceArea { get; private set; }

		public void Visit(Ball ball)
		{
			SurfaceArea = 4 * Math.PI * ball.Radius * ball.Radius;
		}

		public void Visit(Cube cube)
		{
			SurfaceArea = 6 * cube.Size * cube.Size;
		}

		public void Visit(Cylinder cylinder)
		{
			SurfaceArea = 2 * Math.PI * cylinder.Radius * (cylinder.Radius + cylinder.Height);
		}
	}

	public class DimensionsVisitor: IVisitor
	{
		public Dimensions Dimensions { get; private set; }

		public void Visit(Ball ball)
		{
			var doubleR = ball.Radius * 2;
			Dimensions = new Dimensions(doubleR, doubleR);
		}

		public void Visit(Cube cube)
		{
			Dimensions = new Dimensions(cube.Size, cube.Size);
		}

		public void Visit(Cylinder cylinder)
		{
			Dimensions = new Dimensions(cylinder.Radius * 2, cylinder.Height);
		}
	}
}