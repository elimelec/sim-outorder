
// This file has been generated by the GUI designer. Do not modify.
namespace Simoutorder
{
	public partial class BpredForm
	{
		private global::Gtk.Fixed fixed2;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label12;
		
		private global::Gtk.Label label13;
		
		private global::Gtk.Label label14;
		
		private global::Gtk.Label label15;
		
		private global::Gtk.Entry Bpred2levL1SizeTextBox;
		
		private global::Gtk.Entry Bpred2levHistorySizeTextBox;
		
		private global::Gtk.Entry Bpred2levL2SizeTextBox;
		
		private global::Gtk.CheckButton Bpred2levXorCheckBox;
		
		private global::Gtk.Label label16;
		
		private global::Gtk.Label label18;
		
		private global::Gtk.Label label17;
		
		private global::Gtk.Entry BpredBtbSetsTextBox;
		
		private global::Gtk.Entry BpredBtbAssociativityTextBox;
		
		private global::Gtk.Label label19;
		
		private global::Gtk.Entry BpredBimodTextBox;
		
		private global::Gtk.Button SaveButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Simoutorder.BpredForm
			this.Name = "Simoutorder.BpredForm";
			this.Title = global::Mono.Unix.Catalog.GetString ("Bpred Parameters");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child Simoutorder.BpredForm.Gtk.Container+ContainerChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("Parametrii simulatorului de predictie:");
			this.fixed2.Add (this.label10);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label10]));
			w1.X = 6;
			w1.Y = 5;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Parametrii Bpred:2lev");
			this.fixed2.Add (this.label11);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label11]));
			w2.X = 7;
			w2.Y = 49;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("L1 size");
			this.fixed2.Add (this.label12);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label12]));
			w3.X = 27;
			w3.Y = 79;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label13 = new global::Gtk.Label ();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("L2 size");
			this.fixed2.Add (this.label13);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label13]));
			w4.X = 27;
			w4.Y = 109;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("History size");
			this.fixed2.Add (this.label14);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label14]));
			w5.X = 27;
			w5.Y = 141;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label15 = new global::Gtk.Label ();
			this.label15.Name = "label15";
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString ("XOR");
			this.fixed2.Add (this.label15);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label15]));
			w6.X = 28;
			w6.Y = 174;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.Bpred2levL1SizeTextBox = new global::Gtk.Entry ();
			this.Bpred2levL1SizeTextBox.CanFocus = true;
			this.Bpred2levL1SizeTextBox.Name = "Bpred2levL1SizeTextBox";
			this.Bpred2levL1SizeTextBox.Text = global::Mono.Unix.Catalog.GetString ("1");
			this.Bpred2levL1SizeTextBox.IsEditable = true;
			this.fixed2.Add (this.Bpred2levL1SizeTextBox);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.Bpred2levL1SizeTextBox]));
			w7.X = 127;
			w7.Y = 73;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.Bpred2levHistorySizeTextBox = new global::Gtk.Entry ();
			this.Bpred2levHistorySizeTextBox.CanFocus = true;
			this.Bpred2levHistorySizeTextBox.Name = "Bpred2levHistorySizeTextBox";
			this.Bpred2levHistorySizeTextBox.Text = global::Mono.Unix.Catalog.GetString ("8");
			this.Bpred2levHistorySizeTextBox.IsEditable = true;
			this.fixed2.Add (this.Bpred2levHistorySizeTextBox);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.Bpred2levHistorySizeTextBox]));
			w8.X = 127;
			w8.Y = 135;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.Bpred2levL2SizeTextBox = new global::Gtk.Entry ();
			this.Bpred2levL2SizeTextBox.CanFocus = true;
			this.Bpred2levL2SizeTextBox.Name = "Bpred2levL2SizeTextBox";
			this.Bpred2levL2SizeTextBox.Text = global::Mono.Unix.Catalog.GetString ("1024");
			this.Bpred2levL2SizeTextBox.IsEditable = true;
			this.fixed2.Add (this.Bpred2levL2SizeTextBox);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.Bpred2levL2SizeTextBox]));
			w9.X = 127;
			w9.Y = 104;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.Bpred2levXorCheckBox = new global::Gtk.CheckButton ();
			this.Bpred2levXorCheckBox.CanFocus = true;
			this.Bpred2levXorCheckBox.Name = "Bpred2levXorCheckBox";
			this.Bpred2levXorCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Activate");
			this.Bpred2levXorCheckBox.DrawIndicator = true;
			this.Bpred2levXorCheckBox.UseUnderline = true;
			this.fixed2.Add (this.Bpred2levXorCheckBox);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.Bpred2levXorCheckBox]));
			w10.X = 127;
			w10.Y = 169;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label16 = new global::Gtk.Label ();
			this.label16.Name = "label16";
			this.label16.LabelProp = global::Mono.Unix.Catalog.GetString ("Parametrii Bred:btb");
			this.fixed2.Add (this.label16);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label16]));
			w11.X = 7;
			w11.Y = 207;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label18 = new global::Gtk.Label ();
			this.label18.Name = "label18";
			this.label18.LabelProp = global::Mono.Unix.Catalog.GetString ("Associativity");
			this.fixed2.Add (this.label18);
			global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label18]));
			w12.X = 28;
			w12.Y = 269;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label17 = new global::Gtk.Label ();
			this.label17.Name = "label17";
			this.label17.LabelProp = global::Mono.Unix.Catalog.GetString ("Sets");
			this.fixed2.Add (this.label17);
			global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label17]));
			w13.X = 28;
			w13.Y = 237;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.BpredBtbSetsTextBox = new global::Gtk.Entry ();
			this.BpredBtbSetsTextBox.CanFocus = true;
			this.BpredBtbSetsTextBox.Name = "BpredBtbSetsTextBox";
			this.BpredBtbSetsTextBox.Text = global::Mono.Unix.Catalog.GetString ("512");
			this.BpredBtbSetsTextBox.IsEditable = true;
			this.fixed2.Add (this.BpredBtbSetsTextBox);
			global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.BpredBtbSetsTextBox]));
			w14.X = 126;
			w14.Y = 231;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.BpredBtbAssociativityTextBox = new global::Gtk.Entry ();
			this.BpredBtbAssociativityTextBox.CanFocus = true;
			this.BpredBtbAssociativityTextBox.Name = "BpredBtbAssociativityTextBox";
			this.BpredBtbAssociativityTextBox.Text = global::Mono.Unix.Catalog.GetString ("4");
			this.BpredBtbAssociativityTextBox.IsEditable = true;
			this.fixed2.Add (this.BpredBtbAssociativityTextBox);
			global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.BpredBtbAssociativityTextBox]));
			w15.X = 126;
			w15.Y = 262;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.label19 = new global::Gtk.Label ();
			this.label19.Name = "label19";
			this.label19.LabelProp = global::Mono.Unix.Catalog.GetString ("Bpred:bimod");
			this.fixed2.Add (this.label19);
			global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.label19]));
			w16.X = 10;
			w16.Y = 310;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.BpredBimodTextBox = new global::Gtk.Entry ();
			this.BpredBimodTextBox.CanFocus = true;
			this.BpredBimodTextBox.Name = "BpredBimodTextBox";
			this.BpredBimodTextBox.Text = global::Mono.Unix.Catalog.GetString ("2048");
			this.BpredBimodTextBox.IsEditable = true;
			this.fixed2.Add (this.BpredBimodTextBox);
			global::Gtk.Fixed.FixedChild w17 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.BpredBimodTextBox]));
			w17.X = 126;
			w17.Y = 304;
			// Container child fixed2.Gtk.Fixed+FixedChild
			this.SaveButton = new global::Gtk.Button ();
			this.SaveButton.CanFocus = true;
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.UseUnderline = true;
			this.SaveButton.Label = global::Mono.Unix.Catalog.GetString ("Salveaza");
			this.fixed2.Add (this.SaveButton);
			global::Gtk.Fixed.FixedChild w18 = ((global::Gtk.Fixed.FixedChild)(this.fixed2 [this.SaveButton]));
			w18.X = 217;
			w18.Y = 372;
			this.Add (this.fixed2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 300;
			this.DefaultHeight = 411;
			this.Show ();
			this.SaveButton.Clicked += new global::System.EventHandler (this.OnSaveButtonClicked);
		}
	}
}
