using System;

namespace Simoutorder
{
	public partial class AboutForm : Gtk.Window
	{
		public AboutForm () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			IncarcaTitlu ();
		}

		private void IncarcaTitlu() {
			image85.File = "soo.PNG";
		}
	}
}

