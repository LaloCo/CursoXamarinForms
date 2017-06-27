using System;
using System.Collections.Generic;
using ToDoForms.Clases;
using Xamarin.Forms;

namespace ToDoForms
{
    public partial class NuevoItem : ContentPage
    {
        public NuevoItem()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Tarea nuevaTarea = new Tarea()
            {
                Nombre = nombreEntry.Text,
                Fecha = fechaLimiteDatePicker.Date,
                Hora = horaLimiteTimePicker.Time,
                Completada = false
            };

            using(SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                conexion.CreateTable<Tarea>();

                var resultado = conexion.Insert(nuevaTarea);

                if (resultado > 0)
                    DisplayAlert("Exito", "El elemento se guardo", "Ok");
                else
                    DisplayAlert("Error", "Intenta de nuevo", "Ok");
            }
        }
    }
}
