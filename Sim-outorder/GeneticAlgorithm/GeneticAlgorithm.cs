using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Simoutorder
{
	public class GeneticAlgorithm
	{
		Process proc;
		List<Cromozom> cromozomsPopulation;
		List<Cromozom> newCromozomsPopulation;
		int elitistPercent;
		static Random rand = new Random();
		int currentGeneration;
		GeneticAlgorithmOptions geneticAlgorithmOptions;
		string projectPath = Environment.CurrentDirectory.ToString();

		public List<Cromozom> Start(GeneticAlgorithmOptions geneticAlgorithmOptions) 
		{
			this.geneticAlgorithmOptions = geneticAlgorithmOptions;
			newCromozomsPopulation = new List<Cromozom> ();
			elitistPercent = geneticAlgorithmOptions.ElitesPercentage;
			currentGeneration = 0;
			Initialize algorithm = new Initialize ();
			cromozomsPopulation = algorithm.GeneratePopulation (geneticAlgorithmOptions);
			int benchmarkCounter = 1;

			while (currentGeneration < geneticAlgorithmOptions.NumberOfGenerations) 
			{
				IOFunctions.ClearFiles ("./","ta.log*");
				ClearPastFitness ();
				benchmarkCounter = 1;
				foreach (var benchmark in geneticAlgorithmOptions.Benchmarks) 
				{
					for (int i = 0; i < cromozomsPopulation.Count; i++) 
					{
						ExecutaComandaSimulator(i, benchmark, cromozomsPopulation[i].Configuration.Memory, cromozomsPopulation[i].Configuration.OptimizationLevel);
						proc.WaitForExit ();
						CalculateFitness (i, benchmarkCounter);
					}
					benchmarkCounter++;
				}

				Cromozom[] cromozomPopulationCopy = new Cromozom [cromozomsPopulation.Count];
				cromozomsPopulation.CopyTo (cromozomPopulationCopy);
				AppendHistory(cromozomPopulationCopy.ToList(), currentGeneration);

				if (IsNotLastIteration(geneticAlgorithmOptions.NumberOfGenerations)) 
				{
					if (geneticAlgorithmOptions.SelectionMode == AlgorithmSelectionMode.Elitist) {
						CreateNewGenerationWithElitistSelection ();
					}
					if (geneticAlgorithmOptions.SelectionMode == AlgorithmSelectionMode.Tournament) {
						CreateNewGenerationWithTournamentSelection ();
					}

					cromozomsPopulation = newCromozomsPopulation;
					IOFunctions.ClearFiles ("vex/configurations/","*cfg");
					for (int i = 0; i < cromozomsPopulation.Count; i++) {
						IOFunctions.CreateConfigFile (cromozomsPopulation [i], i.ToString());
					}
				}

				currentGeneration++;
			}
			return cromozomsPopulation;
		}

		private void AppendHistory(List<Cromozom> cromozomList, int generation){
			cromozomList = cromozomList.OrderByDescending (s => s.Fitness).ToList();
			Cromozom bestCromozom = cromozomList [0];

			IOFunctions.CreateHistoryFile(bestCromozom, generation);
		}

		private void ClearPastFitness()
		{
			foreach (var cromozom in cromozomsPopulation) {
				cromozom.Fitness = 0;
			}
		}

		private bool IsNotLastIteration(int numberOfGenerations) 
		{
			return currentGeneration != numberOfGenerations - 1 ? true : false;
		}

		private void ExecutaComandaSimulator(int configurationNumber, string benchmark, string memory, string optimizationLevel)
		{
			var vexcfgFile = $@"vex/configurations/vex_{configurationNumber}.cfg";
			var memoryFile = $@"vex/memories/{memory}";
			var benchmarkPreFile = $@"vex/benchmarks/{benchmark}";

			var exportCmd = $@"export VEXCFG=""{vexcfgFile}""";
			var compileCmd = $@"vex/bin/cc -c -mas_t -fmm=""{memoryFile}"" {optimizationLevel} {benchmarkPreFile}.c";
			var compileBasicMathCmd = $@"{compileCmd} vex/benchmarks/rad2deg.c vex/benchmarks/cubic.c vex/benchmarks/isqrt.c";
			var linkCmd = $@"vex/bin/cc -o {benchmark} {benchmark}.o -lm";
			var linkBasicMathCmd = $@"{linkCmd} rad2deg.o cubic.o isqrt.o -lm";
			var runCmd = $@"./{benchmark}";

			String command = "";
			if (benchmark == "susan") {
				command = $@"-c '{exportCmd} && {compileCmd} && {linkCmd} && {runCmd}'";
			}
			if (benchmark == "basicmath_small" || benchmark == "basicmath_large") {
				command = $@"-c '{exportCmd} && {compileBasicMathCmd} && {linkBasicMathCmd} && {runCmd}'";
			}

			ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", command);
			procStartInfo.UseShellExecute = false;
			procStartInfo.CreateNoWindow = true;
			procStartInfo.RedirectStandardOutput = true;

			proc = new Process();
			proc.StartInfo = procStartInfo;
			proc.Start();
		}

		private void CalculateFitness(int i, int benchmarkCounter)
		{
			string logNumber = (i + (benchmarkCounter-1)*cromozomsPopulation.Count).ToString();
			string[] itemeDeCautat = new string[]{"Avg. IPC (with stalls):"};
			if (logNumber.Length == 2) 
			{
				logNumber = ("0" + logNumber);
			}
			if (logNumber.Length == 1) 
			{
				logNumber = ("00" + logNumber);
			}
			Dictionary<string,double> results = SearchInFile.GetSimulatorValuesByText (IOFunctions.GetLinesFromFile (@"ta.log." + logNumber), itemeDeCautat);
			foreach (String item in itemeDeCautat) 
			{
				double adunare = (cromozomsPopulation [i].Fitness + results [item]);
				double inmultire = benchmarkCounter * 1.0;
				double impartire = adunare / inmultire;
				cromozomsPopulation [i].Fitness = impartire; // Media Aritmetica
			}
		}

		private void CreateNewGenerationWithElitistSelection()
		{
			SelectElitistCromozoms ();
			SelectOtherCromozomsUsingCrossoverAndMutation ();
		}

		private void CreateNewGenerationWithTournamentSelection() 
		{
			Cromozom tempFirstCromozom;
			Cromozom tempSecondCromozom;

			newCromozomsPopulation = new List<Cromozom> ();

			List<Cromozom> listaNoua = new List<Cromozom> ();
			for (int i = 0; i < 5; i++) {
				listaNoua.Add (cromozomsPopulation[rand.Next(0, cromozomsPopulation.Count)]);
			}
			listaNoua = listaNoua.OrderByDescending (s => s.Fitness).ToList();
			ApplyCrossover (listaNoua[0], listaNoua[1]);

			foreach (var cromozom in newCromozomsPopulation) 
			{
				if (rand.NextDouble () >= geneticAlgorithmOptions.MutationOccurance) 
				{
					cromozom.Mutate ();
				}
			}
			tempFirstCromozom = newCromozomsPopulation [0];
			tempSecondCromozom = newCromozomsPopulation [1];

			Cromozom[] temporaryCromozomArray = new Cromozom[cromozomsPopulation.Count];
			cromozomsPopulation.CopyTo (temporaryCromozomArray);
			newCromozomsPopulation = temporaryCromozomArray.ToList ();
			newCromozomsPopulation.Add (tempFirstCromozom);
			newCromozomsPopulation.Add (tempSecondCromozom);

			newCromozomsPopulation = newCromozomsPopulation.OrderBy (s => s.Fitness).ToList();
			newCromozomsPopulation.RemoveRange (0, 2);
		}

		private void SelectElitistCromozoms() 
		{
			int elitistPopulationNumber = cromozomsPopulation.Count * elitistPercent / 100;
			cromozomsPopulation = cromozomsPopulation.OrderByDescending (s => s.Fitness).ToList();
			newCromozomsPopulation = cromozomsPopulation.Take (elitistPopulationNumber).ToList();
		}

		private void SelectOtherCromozomsUsingCrossoverAndMutation() 
		{
			while (newCromozomsPopulation.Count < cromozomsPopulation.Count) 
			{
				ApplyCrossover (cromozomsPopulation[rand.Next (0, cromozomsPopulation.Count)], cromozomsPopulation[rand.Next (0, cromozomsPopulation.Count)]);
				if (newCromozomsPopulation.Count > cromozomsPopulation.Count) {
					newCromozomsPopulation.RemoveAt (newCromozomsPopulation.Count-1);
				}
			}

			foreach (var cromozom in newCromozomsPopulation) 
			{
				if (rand.NextDouble () >= geneticAlgorithmOptions.MutationOccurance) 
				{
					cromozom.Mutate ();
				}
			}
		}

		private void ApplyCrossover (Cromozom firstCromozom, Cromozom secondCromozom) 
		{
			Cromozom resultFirstCromozom = firstCromozom.DeepCopy();
			Cromozom resultSecondCromozom = secondCromozom.DeepCopy();

			resultFirstCromozom.CrossOver (resultSecondCromozom);

			resultFirstCromozom.GenerationNumber = currentGeneration + 1;
			resultSecondCromozom.GenerationNumber = currentGeneration + 1;

			newCromozomsPopulation.Add (resultFirstCromozom);
			newCromozomsPopulation.Add (resultSecondCromozom);
		}
	}
}

