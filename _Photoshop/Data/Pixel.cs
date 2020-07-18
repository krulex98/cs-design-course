﻿using System;

namespace MyPhotoshop
{
	public struct Pixel
	{
		private double _r;
		public double R
		{
			get => _r;
			set { Check(value); _r = value; }
		}
		
		private double _g;
		public double G 
		{
			get => _g;
			set { Check(value); _g = value; }
		}
		
		private double _b;
		public double B
		{
			get => _b;
			set { Check(value); _b = value; }
		}
		
		public Pixel(double r, double g, double b)
		{
			_r = _g = _b = 0;
			
			R = r;
			G = g;
			B = b;
		}

		private static void Check(double val)
		{
			if (val < 0 || val > 1)
				throw new ArgumentException($"Wrong channel value {val} (the value must be between 0 and 1");
		}
	}
}