using System;
using System.Collections.Generic;
using ToDoForms.Clases;
using Xamarin.Forms;
using System.Linq;

namespace ToDoForms
{
    public partial class ListaTareas : ContentPage
    {
        public ListaTareas()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                List<Tarea> listaTareas;
                listaTareas = conexion.Table<Tarea>().ToList();

                listaTareasListView.ItemsSource = listaTareas;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                var tareaAcompletar = (sender as MenuItem).CommandParameter as Tarea;
                tareaAcompletar.Completada = true;

                conexion.Update(tareaAcompletar);
            }
        }
    }
}
