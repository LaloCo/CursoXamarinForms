using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace ToDoList
{
	public partial class NuevoItemPage : ContentPage
	{
		public NuevoItemPage()
		{
			InitializeComponent();

			Title = "Nuevo ToDo";
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			ToDoItem nuevoItem = new ToDoItem()
			{
				Nombre = nombreEntry.Text,
				Fecha = fechaDatePicker.Date,
				Hora = horaTimePicker.Time,
				Completada = false
			};

			using (SQLiteConnection conn = new SQLiteConnection(App.RutaBD))
			{
				conn.CreateTable<ToDoItem>();
				var resultado = conn.Insert(nuevoItem); // resultado contiene el número de filas agregadas a la tabla
				if (resultado > 0)
					DisplayAlert("Resultado de la operación", "El nuevo item se guardó correctamente.", "Ok");
				else
                    DisplayAlert("Resultado de la operación", "Ocurrió un error, por favor intente de nuevo.", "Ok");
			}
		}
	}
}