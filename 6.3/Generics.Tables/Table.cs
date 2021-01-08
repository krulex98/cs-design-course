using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Tables
{
	public class Table<TRow, TColumn, TCell>
	{
		private readonly IndexedTable<TRow, TColumn, TCell> _table;
		
		public Table()
		{
			_table = new IndexedTable<TRow, TColumn, TCell>();
		}
		
		public IndexedTable<TRow, TColumn, TCell> Open
		{
			get => _table;
		}

		public IndexedTable<TRow, TColumn, TCell> Existed
		{
			get => new IndexedTable<TRow, TColumn, TCell>(_table, true);
		}

		public void AddRow(TRow row) => _table.AddRow(row);
		public void AddColumn(TColumn column) => _table.AddColumn(column);

		public IEnumerable<TRow> Rows => _table.Rows;
		public IEnumerable<TColumn> Columns => _table.Columns;
	}

	public class IndexedTable<TRow, TColumn, TCell> 
	{
		public List<TRow> Rows { get; }
		public List<TColumn> Columns { get; }

		private List<List<TCell>> _table;
		
		public bool WithArgumentCheck { get; set; }

		public IndexedTable()
		{
			Rows = new List<TRow>();
			Columns = new List<TColumn>();
			_table = new List<List<TCell>>();
		}

		public IndexedTable(IndexedTable<TRow, TColumn, TCell> table, bool withArgumentCheck)
		{
			Rows = new List<TRow>(table.Rows);
			Columns = new List<TColumn>(table.Columns);
			_table = new List<List<TCell>>(table._table);

			WithArgumentCheck = withArgumentCheck;
		}

		public TCell this[TRow row, TColumn column]
		{
			get
			{
				var indexRow = Rows.FindIndex(r => r.Equals(row));
				var indexCol = Columns.FindIndex(c => c.Equals(column));

				if (indexRow < 0 || indexCol < 0)
				{
					if (WithArgumentCheck)
						throw new ArgumentException();
					
					return default;
				}

				return _table[indexRow][indexCol];
			}
			set
			{
				var rowExists = Rows.Contains(row);
				var colExists = Columns.Contains(column);

				if (!rowExists || !colExists)
				{
					if (WithArgumentCheck)
					{
						throw new ArgumentException();
					}
					
					if (!rowExists)
						AddRow(row);
						
					if (!colExists)
						AddColumn(column);
				}

				var indexRow = Rows.FindIndex(r => r.Equals(row));
				var indexCol = Columns.FindIndex(c => c.Equals(column));
				
				if (indexRow < 0 || indexCol < 0)
					throw new ArgumentException();

				_table[indexRow][indexCol] = value;
			}
		}

		public void AddRow(TRow row)
		{
			if (!Rows.Contains(row))
			{
				Rows.Add(row);

				var cols = Columns.Select(col => (TCell) default).ToList();
				_table.Add(cols);
			}
		}

		public void AddColumn(TColumn col)
		{
			if (!Columns.Contains(col))
			{
				Columns.Add(col);

				foreach (var row in _table)
					row.Add(default);
			}
		}
	}
}