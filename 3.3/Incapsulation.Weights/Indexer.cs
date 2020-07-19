using System;

namespace Incapsulation.Weights
{
	public class Indexer
	{
		private readonly double[] _data;
		private readonly int _start;

		public int Length { get; }

		public double this[int index]
		{
			get
			{
				CheckIndex(index);
				return _data[index + _start];
			}
			set
			{
				CheckIndex(index);
				_data[index + _start] = value;
			}
		}

		private void CheckIndex(int index)
		{
			if (index < 0 || index >= Length)
				throw new IndexOutOfRangeException();
		}

		public Indexer(double[] data, int start, int length)
		{
			if (length < 0 || length > data.Length)
				throw new ArgumentException();
			
			if (start < 0 || start > data.Length || start + length > data.Length)
				throw new ArgumentException();

			_data = data;
			_start = start;
			Length = length;
		}
	}
}