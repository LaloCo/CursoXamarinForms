using Xamarin.Forms;

namespace ToDoForms
{
    public partial class ToDoFormsPage : ContentPage
    {
        public ToDoFormsPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(usuarioEntry.Text) || string.IsNullOrEmpty(contraseñaEntry.Text))
            {
                resultadoLabel.Text = "Debe escribir usuario y contraseña";
            }
            else
            {
                resultadoLabel.Text = "Inicio de sesion exitoso";
                await Navigation.PushAsync(new ListaTareas());
            }
        }
    }
}
