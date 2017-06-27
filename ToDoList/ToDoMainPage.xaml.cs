using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace ToDoList
{
	public partial class ToDoMainPage : ContentPage
	{
		public ToDoMainPage()
		{
			InitializeComponent();

			Title = "ToDos";

			var nuevoItemButton = new ToolbarItem()
			{
				Text = "+"
			};
			nuevoItemButton.Clicked += NuevoItemButton_Clicked;
			ToolbarItems.Add(nuevoItemButton);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.RutaBD))
			{
                conn.CreateTable<ToDoItem>();

				List<ToDoItem> items = conn.Table<ToDoItem>().Where(i => i.Completada == false).OrderBy(i => i.Fecha).ToList();
				todoListView.ItemsSource = items;
			}
		}

		void OnCompleted(object sender, System.EventArgs e)
		{
			using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.RutaBD))
			{
                conn.CreateTable<ToDoItem>();

				var itemACompletar = (sender as MenuItem).CommandParameter as ToDoItem;
				itemACompletar.Completada = true;
				conn.Update(itemACompletar);

				List<ToDoItem> items = conn.Table<ToDoItem>().Where(i => i.Completada == false).OrderBy(i => i.Fecha).ToList();
				todoListView.ItemsSource = items;
			}
		}

		async void NuevoItemButton_Clicked(object sender, EventArgs e)
		{
			await this.Navigation.PushAsync(new NuevoItemPage());
		}
	}
}
