using System;

namespace Incapsulation.RationalNumbers
{
	public class Rational
	{
		public int Numerator { get; }
		public int Denominator { get; }
		
		public bool IsNan => Denominator == 0;

		private static int GCD(int a, int b)
		{
			return b == 0 ? a : GCD(b, a % b);
		}

		public Rational(int numerator, int denominator = 1)
		{
			var gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
			var sign = Math.Sign(numerator) * Math.Sign(denominator);

			Numerator = gcd == 0 ? numerator : sign * Math.Abs(numerator / gcd);
			Denominator = gcd == 0 ? gcd : Math.Abs(denominator / gcd);
		}

		public static Rational operator *(Rational r, int num)
		{
			return new Rational(r.Numerator * num, r.Denominator * Math.Abs(num));
		}

		public static Rational operator +(Rational r1, Rational r2)
		{
			var numerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
			var denominator = r1.Denominator * r2.Denominator;
			return new Rational(numerator, denominator);
		}

		public static Rational operator -(Rational r1, Rational r2)
		{
			return r1 + r2 * -1;
		}

		public static Rational operator *(Rational r1, Rational r2)
		{
			return new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
		}
		
		public static Rational operator /(Rational r1, Rational r2)
		{
			return new Rational(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
		}

		public static implicit operator double(Rational r) => r.Numerator / (double) r.Denominator;
		
		public static implicit operator Rational(int num) => new Rational(num);
		
		public static implicit operator int(Rational r) => r.Numerator % r.Denominator == 0 
				? r.Numerator / r.Denominator : throw new InvalidCastException();
	}
}