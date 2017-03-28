using System;
using Gtk;

namespace Simoutorder
{
	public partial class ParameterForm : Gtk.Window
	{
		public ParameterForm () :
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
			MasterModel.AmIntratPeFormaDeParametrii = true;
		}

		private void SetValueInComboBox(ComboBox genericCombo,string valoareDeSetatInCombo)
		{
			TreeIter ti;
			genericCombo.Model.GetIterFirst (out ti);
			string chk;
			do {
				chk = genericCombo.Model.GetValue(ti, 0).ToString();
				if(chk == valoareDeSetatInCombo) 
				{
					genericCombo.SetActiveIter( ti );
					break;
				}
			} while( genericCombo.Model.IterNext(ref ti));
		}

	}
}

