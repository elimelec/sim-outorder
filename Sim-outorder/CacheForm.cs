using System;
using Gtk;

namespace Simoutorder
{
	public partial class CacheForm : Gtk.Window
	{
		public CacheForm () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			MessageDialog md = new MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Info, 
				ButtonsType.Ok, "Datele au fost salvate!");
			md.SetPosition (WindowPosition.Center);
			md.Run();
			md.Destroy();
			MasterModel.AmIntratPeFormaDeParametriiCache = true;
		}
	}
}

