using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Tables
{
	public class Table<TRow, TColumn, TCell>
	{
		private readonly List<TRow> _rows = new List<TRow>();
		private readonly List<TColumn> _columns = new List<TColumn>();
		private readonly List<List<TCell>> _matrix = new List<List<TCell>>();

		public List<TRow> Rows => _rows;
		public List<TColumn> Columns => _columns;

		public IndexedTable Open => new IndexedTable(this, false);

		public IndexedTable Existed => new IndexedTable(this, true);

		public void AddRow(TRow row)
		{
			if (!_rows.Contains(row))
			{
				_rows.Add(row);
				_matrix.Add(_columns.Select(col => (TCell) default).ToList());
			}
		}

		public void AddColumn(TColumn col)
		{
			if (!_columns.Contains(col))
			{
				_columns.Add(col);

				foreach (var row in _matrix)
					row.Add(default);
			}
		}

		public class IndexedTable
		{
			private readonly Table<TRow, TColumn, TCell> _table;
			private readonly bool _withArgumentCheck;

			public IndexedTable(Table<TRow, TColumn, TCell> table, bool withArgumentCheck)
			{
				_table = table;
				_withArgumentCheck = withArgumentCheck;
			}

			public TCell this[TRow row, TColumn column]
			{
				get
				{
					var indexRow = _table.Rows.FindIndex(r => r.Equals(row));
					var indexCol = _table.Columns.FindIndex(c => c.Equals(column));

					if (indexRow < 0 || indexCol < 0)
					{
						if (_withArgumentCheck)
							throw new ArgumentException();

						return default;
					}

					return _table._matrix[indexRow][indexCol];
				}
				set
				{
					var rowExists = _table.Rows.Contains(row);
					var colExists = _table.Columns.Contains(column);

					if (!rowExists || !colExists)
					{
						if (_withArgumentCheck)
						{
							throw new ArgumentException();
						}

						if (!rowExists)
							_table.AddRow(row);

						if (!colExists)
							_table.AddColumn(column);
					}

					var indexRow = _table.Rows.FindIndex(r => r.Equals(row));
					var indexCol = _table.Columns.FindIndex(c => c.Equals(column));

					if (indexRow < 0 || indexCol < 0)
						throw new ArgumentException();

					_table._matrix[indexRow][indexCol] = value;
				}
			}
		}
	}
}