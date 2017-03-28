using System;

namespace Simoutorder
{
	public partial class HelpForm : Gtk.Window
	{
		public HelpForm () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

