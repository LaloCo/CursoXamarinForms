using Xamarin.Forms;

namespace ToDoForms
{
    public partial class App : Application
    {
        public static string RutaBD;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToDoFormsPage());
        }

        public App(string rutaBD)
        {
			InitializeComponent();

            RutaBD = rutaBD;

			MainPage = new NavigationPage(new ToDoFormsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
