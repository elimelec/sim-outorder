using System;
using Gtk;
using Simoutorder;
using System.Diagnostics;
using System.Collections.Generic;
using Gdk;

public partial class MainWindow: Gtk.Window
{
	AlgorithmSelectionMode selectionMode = AlgorithmSelectionMode.Elitist;

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

	private List<string> GetActiveBenchmarks ()
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
		var cromozoms = numberOfCromozoms.Text;
		var generations = numberOfGenerations.Text;
		var elites = elitesPercentageTextBox.Text;
		var crossOver = crossoverPercentageTextBox.Text;
		var mutationOccurance = mutationOccuranceTextBox.Text;
		var mutationPercentage = mutationPercentageTextBox.Text;
		var benchmarks = GetActiveBenchmarks ();
		var selectionMode = this.selectionMode;

		return new GeneticAlgorithmOptions (cromozoms, generations, elites, crossOver, mutationOccurance, mutationPercentage, benchmarks, selectionMode);
	}

	protected void TestComandaTerminal (object sender, EventArgs e)
	{
		resultsText.Buffer.Clear ();

		GeneticAlgorithmOptions options;

		try {
			options = CreateAlgorithmOptions ();
		} catch (Exception ex) {
			MessageDialog error = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, ex.Message);
			error.SetPosition (WindowPosition.Center);
			error.Run ();
			error.Destroy ();
			return;
		}

		Stopwatch stopWatch = new Stopwatch ();
		stopWatch.Start ();

		GeneticAlgorithm algorithm = new GeneticAlgorithm ();
		List<Cromozom> results = algorithm.Start (options);
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
		var label = (sender as RadioButton).Label;
		switch (label) {
		case "Elitist":
			selectionMode = AlgorithmSelectionMode.Elitist;
			break;
		case "Tournament":
			selectionMode = AlgorithmSelectionMode.Tournament;
			break;
		case "Roulette Wheel":
			selectionMode = AlgorithmSelectionMode.RouletteWheel;
			break;
		default:
			throw new Exception ("Invalid selection: " + selectionMode);
		}
	}
}
