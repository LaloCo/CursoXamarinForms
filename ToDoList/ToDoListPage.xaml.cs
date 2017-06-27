using Xamarin.Forms;

namespace ToDoList
{
	public partial class ToDoListPage : ContentPage
	{
		public ToDoListPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (string.IsNullOrEmpty(usuarioEntry.Text) || string.IsNullOrEmpty(contraseñaEntry.Text))
			{
				resultadoLabel.Text = "Debes escribir tu usuario y contraseña";
			}
			else
			{
				resultadoLabel.Text = "Inicio de sesión exitoso";
				//TODO: navegar a página principal
				var task = this.Navigation.PushAsync(new ToDoMainPage());
                await task;
			}
		}
	}
}
