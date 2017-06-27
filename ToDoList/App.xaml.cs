using Xamarin.Forms;

namespace ToDoList
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new ToDoListPage());
		}

		public static string RutaBD = string.Empty;
		public App(string rutaBD)
		{
			InitializeComponent();

			RutaBD = rutaBD;

			MainPage = new NavigationPage(new ToDoListPage());
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
