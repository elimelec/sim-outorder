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
			cromozomsPopulation = algorithm.GeneratePopulation (geneticAlgorithmOptions.NumberOfCromozoms);
			int benchmarkCounter = 1;

			while (currentGeneration < geneticAlgorithmOptions.NumberOfGenerations) 
			{
				IOFunctions.ClearFiles ("vex-3.43/bin/","ta.log*");
				ClearPastFitness ();
				benchmarkCounter = 1;
				foreach (var benchmark in geneticAlgorithmOptions.Benchmarks) 
				{
					for (int i = 0; i < cromozomsPopulation.Count; i++) 
					{
						ExecutaComandaSimulator(i, benchmark, cromozomsPopulation[i].Memory, cromozomsPopulation[i].OptimizationLevel);
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
					IOFunctions.ClearFiles ("vex-3.43/share/apps/h264dec/test/Configurations/","*cfg");
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
			String command = "";
			if (benchmark == "susan") {
				command = "-c 'cd vex-3.43/bin && export VEXCFG=\"" + projectPath + "/vex-3.43/share/apps/h264dec/test/Configurations/vex_" + configurationNumber + ".cfg\" && ./cc -c -mas_t -fmm=\"" + projectPath + "/vex-3.43/share/apps/h264dec/test/Memories/" + memory + "\" " + optimizationLevel + " " + benchmark + ".c && ./cc -o " + benchmark + " " + benchmark + ".o -lm && ./" + benchmark + "'";
			}
			if (benchmark == "basicmath_small" || benchmark == "basicmath_large") {
				command = "-c 'cd vex-3.43/bin && export VEXCFG=\"" + projectPath + "/vex-3.43/share/apps/h264dec/test/Configurations/vex_" + configurationNumber + ".cfg\" && ./cc -c -mas_t -fmm=\"" + projectPath + "/vex-3.43/share/apps/h264dec/test/Memories/" + memory + "\" " + optimizationLevel + " " + benchmark + ".c rad2deg.c cubic.c isqrt.c && ./cc -o " + benchmark + " " + benchmark + ".o rad2deg.o cubic.o isqrt.o -lm && ./" + benchmark + "'";
			}

			ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", command);
			procStartInfo.UseShellExecute = false;
			procStartInfo.CreateNoWindow = true;

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
			Dictionary<string,double> results = SearchInFile.GetSimulatorValuesByText (IOFunctions.GetLinesFromFile (@"vex-3.43/bin/ta.log." + logNumber), itemeDeCautat);
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
					ApplyMutation (cromozom);
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
					ApplyMutation (cromozom);
				}
			}
		}

		private void ApplyCrossover (Cromozom firstCromozom, Cromozom secondCromozom) 
		{
			Cromozom resultFirstCromozom = firstCromozom.DeepCopy();
			Cromozom resultSecondCromozom = secondCromozom.DeepCopy();

			PropertyInfo[] properties = typeof(Cromozom).GetProperties();
			foreach (PropertyInfo property in properties)
			{
				if (rand.NextDouble () >= geneticAlgorithmOptions.CrossOverPercentage) 
				{
					if(property.Name != "Index" && property.Name != "Fitness" && property.Name != "GenerationNumber")
					{
						property.SetValue(resultFirstCromozom, property.GetValue(secondCromozom));
						property.SetValue(resultSecondCromozom, property.GetValue(firstCromozom));
					}
				}
			}
			resultFirstCromozom.GenerationNumber = currentGeneration + 1;
			resultSecondCromozom.GenerationNumber = currentGeneration + 1;
			newCromozomsPopulation.Add (resultFirstCromozom);
			newCromozomsPopulation.Add (resultSecondCromozom);
		}

		private void ApplyMutation (Cromozom cromozom)
		{
			PropertyInfo[] properties = typeof(Cromozom).GetProperties();
			foreach (PropertyInfo property in properties)
			{
				if (rand.NextDouble () >= geneticAlgorithmOptions.MutationPercentage) 
				{
					if(property.Name == "CoreCkFreqValues") 
					{
						property.SetValue(cromozom, CromozomValues.CoreCkFreqValues.PickRandom());
					}
					if(property.Name == "BusCkFreq") 
					{
						property.SetValue(cromozom, CromozomValues.BusCkFreq.PickRandom());
					}
					if(property.Name == "lg2CacheSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2CacheSize.PickRandom());
					}
					if(property.Name == "lg2Sets") 
					{
						property.SetValue(cromozom, CromozomValues.lg2Sets.PickRandom());
					}
					if(property.Name == "lg2LineSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2LineSize.PickRandom());
					}
					if(property.Name == "MissPenalty") 
					{
						property.SetValue(cromozom, CromozomValues.MissPenalty.PickRandom());
					}
					if(property.Name == "WBPenalty") 
					{
						property.SetValue(cromozom, CromozomValues.WBPenalty.PickRandom());
					}
					if(property.Name == "lg2StrSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2StrSize.PickRandom());
					}
					if(property.Name == "lg2StrSets") 
					{
						property.SetValue(cromozom, CromozomValues.lg2StrSets.PickRandom());
					}
					if(property.Name == "lg2StrLineSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2StrLineSize.PickRandom());
					}
					if(property.Name == "StrMissPenalty") 
					{
						property.SetValue(cromozom, CromozomValues.StrMissPenalty.PickRandom());
					}
					if(property.Name == "StrWBPenalty") 
					{
						property.SetValue(cromozom, CromozomValues.StrWBPenalty.PickRandom());
					}
					if(property.Name == "lg2ICacheSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2ICacheSize.PickRandom());
					}
					if(property.Name == "lg2ICacheSets") 
					{
						property.SetValue(cromozom, CromozomValues.lg2ICacheSets.PickRandom());
					}
					if(property.Name == "lg2ICacheLineSize") 
					{
						property.SetValue(cromozom, CromozomValues.lg2ICacheLineSize.PickRandom());
					}
					if(property.Name == "ICachePenalty") 
					{
						property.SetValue(cromozom, CromozomValues.ICachePenalty.PickRandom());
					}
					if(property.Name == "NumCaches") 
					{
						property.SetValue(cromozom, CromozomValues.NumCaches.PickRandom());
					}
					if(property.Name == "BranchStall") 
					{
						property.SetValue(cromozom, CromozomValues.BranchStall.PickRandom());
					}
				}
			}
		}
	}
}

