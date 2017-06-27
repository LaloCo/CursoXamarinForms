using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace ToDoList.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			string nombreArchivo = "todo_db.sqlite";
			string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
			string rutaArchivo = Path.Combine(carpeta, nombreArchivo);

			LoadApplication(new App(rutaArchivo));

			return base.FinishedLaunching(app, options);
		}
	}
}
