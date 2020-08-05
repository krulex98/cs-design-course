namespace Inheritance.Geometry
{
	public static class BodyExtensions
	{
		public static Dimensions GetDimensions(this Body body)
		{
			var visitor = new DimensionsVisitor();
			
			dynamic dynamicBody = body;
			dynamicBody.Accept(visitor);
			return visitor.Dimensions;
		}

		public static double GetSurfaceArea(this Body body)
		{
			var visitor = new SurfaceAreaVisitor();
			
			dynamic dynamicBody = body;
			dynamicBody.Accept(visitor);
			return visitor.SurfaceArea;
		}
	}
}