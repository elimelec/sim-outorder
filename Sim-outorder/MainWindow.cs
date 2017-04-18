using System;
using Gtk;
using Simoutorder;
using System.Diagnostics;
using System.Collections.Generic;
using Gdk;

public partial class MainWindow: Gtk.Window
{
	string selectionMode = "Elitist";

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		elitistRadioButton.Active = true;
		MasterModel.AmIntratPeFormaDeParametrii = false;
		MasterModel.AmIntratPeFormaDeParametriiBpred = false;
		MasterModel.AmIntratPeFormaDeParametriiCache = false;
		image6.File = "soo.PNG";
		this.Focus = button1;
		IOFunctions.ClearFiles ("vex-3.43/bin/", "ta.log*");
		IOFunctions.ClearFiles ("vex-3.43/share/apps/h264dec/test/Configurations/", "*cfg");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnDialogQuestionActionActivated (object sender, EventArgs e)
	{
		/*HelpForm helpForm = new HelpForm ();
		helpForm.Modal = true;
		helpForm.Show ();
		helpForm.Dispose ();*/
		//
		// System.Diagnostics.Process.Start ("Sim-OutorderHelp.chm");
	}

	protected void OnAboutMenuItemActivated (object sender, EventArgs e)
	{
		AboutForm aboutForm = new AboutForm ();
		aboutForm.Modal = true;
		aboutForm.Show ();
		aboutForm.Dispose ();
	}

	protected void OnParametersMenuItemActivated (object sender, EventArgs e)
	{
	}

	protected void OnCacheParametersMenuItemActivated (object sender, EventArgs e)
	{
	}

	protected void OnBpredParametersMenuItemActivated (object sender, EventArgs e)
	{
	}

	protected void OnExitMenuItemActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	private int InputValidation (string input, int defaultValue)
	{
		int number;
		if (!int.TryParse (input, out number)) {
			number = defaultValue;
		}
		return number;
	}

	private List<string> ActiveBenchmarks ()
	{
		List<string> benchmarks = new List<string> ();
		if (susanCheckBox.Active) {
			benchmarks.Add ("susan");
		}
		if (basicmathSmallCheckBox.Active) {
			benchmarks.Add ("basicmath_small");
		}
		if (basicmathLargeCheckBox.Active) {
			benchmarks.Add ("basicmath_large");
		}
		return benchmarks;
	}

	private GeneticAlgorithmOptions CreateAlgorithmOptions ()
	{
		GeneticAlgorithmOptions geneticAlgorithmOptions = new GeneticAlgorithmOptions ();
		geneticAlgorithmOptions.NumberOfCromozoms = InputValidation (numberOfCromozoms.Text, 10);
		geneticAlgorithmOptions.NumberOfGenerations = InputValidation (numberOfGenerations.Text, 5);
		geneticAlgorithmOptions.ElitesPercentage = InputValidation (elitesPercentageTextBox.Text, 50);
		geneticAlgorithmOptions.CrossOverPercentage = 1 - (InputValidation (crossoverPercentageTextBox.Text, 50) / 100.00);
		geneticAlgorithmOptions.MutationPercentage = 1 - (InputValidation (mutationPercentageTextBox.Text, 30) / 100.00);
		geneticAlgorithmOptions.MutationOccurance = 1 - (InputValidation (mutationOccuranceTextBox.Text, 10) / 100.00);
		geneticAlgorithmOptions.Benchmarks = ActiveBenchmarks ();
		geneticAlgorithmOptions.SelectionMode = selectionMode;

		if (geneticAlgorithmOptions.SelectionMode == "Roulette Wheel") {
			MessageDialog infoDialog = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Roulette Wheel Selection not implemented yet, please change to another selection.");
			infoDialog.SetPosition (WindowPosition.Center);
			infoDialog.Run ();
			infoDialog.Destroy ();
			return null;
		}

		if (geneticAlgorithmOptions.SelectionMode == "Tournament") {
			if (geneticAlgorithmOptions.NumberOfCromozoms < 5) {
				MessageDialog errorDialog = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "In case of 'Tournament Selection' the number of cromozoms must be at least 5!");
				errorDialog.SetPosition (WindowPosition.Center);
				errorDialog.Run ();
				errorDialog.Destroy ();
				return null;
			}
		}

		return geneticAlgorithmOptions;
	}

	protected void TestComandaTerminal (object sender, EventArgs e)
	{
		resultsText.Buffer.Clear ();

		var geneticAlgorithmOptions = CreateAlgorithmOptions ();
		if (geneticAlgorithmOptions == null) {
			return;
		}

		Stopwatch stopWatch = new Stopwatch ();
		stopWatch.Start ();

		GeneticAlgorithm algorithm = new GeneticAlgorithm ();
		List<Cromozom> results = algorithm.Start (geneticAlgorithmOptions);
		foreach (var cromozom in results) {
			resultsText.Buffer.Text += "vex_" + cromozom.Index + ".cfg - Generation: " + cromozom.GenerationNumber + " - IPC: " + cromozom.Fitness + "\n";
		}

		stopWatch.Stop ();
		TimeSpan duration = stopWatch.Elapsed;

		MessageDialog md = new MessageDialog (this, 
			                   DialogFlags.DestroyWithParent, MessageType.Info, 
			                   ButtonsType.Ok, "Done!\nDuration: " + duration);
		md.SetPosition (WindowPosition.Center);
		md.Run ();
		md.Destroy ();
	}

	protected void OnRadiobutton1Toggled (object sender, EventArgs e)
	{ 
		selectionMode = (sender as RadioButton).Label;
	}
}
