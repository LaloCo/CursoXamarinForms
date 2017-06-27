using System;
using SQLite;

namespace ToDoList
{
	[Table("ToDoItems")]
	public class ToDoItem
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id
		{
			get;
			set;
		}

		[MaxLength(150)]
		public string Nombre
		{
			get;
			set;
		}

		public DateTime Fecha
		{
			get;
			set;
		}

		public TimeSpan Hora
		{
			get;
			set;
		}

		public bool Completada
		{
			get;
			set;
		}

		[Ignore]
		public object FechaCompleta
		{
			get
			{
				return $"{Fecha:m} {Hora:t}";
			}
		}
	}
}
