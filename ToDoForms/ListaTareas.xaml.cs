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

            var botonNuevo = new ToolbarItem()
            {
                Text = "+"
            };

            botonNuevo.Clicked += BotonNuevo_Clicked;
            ToolbarItems.Add(botonNuevo);
        }

        async void BotonNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoItem());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                List<Tarea> listaTareas;
                listaTareas = conexion.Table<Tarea>().Where(t => t.Completada == false).ToList();

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

                List<Tarea> listaTareasFiltrada;
                listaTareasFiltrada = conexion.Table<Tarea>().Where(t => t.Completada == false).ToList();
                listaTareasListView.ItemsSource = listaTareasFiltrada;
            }
        }
    }
}
