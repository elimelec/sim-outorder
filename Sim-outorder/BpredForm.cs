using System;
using Gtk;

namespace Simoutorder
{
	public partial class BpredForm : Gtk.Window
	{
		public BpredForm () :
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
			MasterModel.AmIntratPeFormaDeParametriiBpred = true;
		}
	}
}

