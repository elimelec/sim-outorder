using System;
using Gtk;

namespace Simoutorder
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			GLib.ExceptionManager.UnhandledException += HandleException;

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}

		public static void HandleException(GLib.UnhandledExceptionArgs args)
		{
			var exception = args.ExceptionObject as Exception;
			Console.WriteLine (exception.StackTrace);
			var message = exception.Message;
			MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, message);
			md.SetPosition (WindowPosition.Center);
			md.Run ();
			md.Destroy ();
		}
	}


}
