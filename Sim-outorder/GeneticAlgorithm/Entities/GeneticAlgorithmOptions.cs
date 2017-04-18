using System;
using System.Collections.Generic;

namespace Simoutorder
{
	public class GeneticAlgorithmOptions
	{
		public int NumberOfCromozoms { get; set; }

		public int NumberOfGenerations { get; set; }

		public int ElitesPercentage { get; set; }

		public double CrossOverPercentage { get; set; }

		public double MutationOccurance { get; set; }

		public double MutationPercentage { get; set; }

		public List<string> Benchmarks { get; set; }

		public string SelectionMode { get; set; }

		public GeneticAlgorithmOptions (string cromozoms, string generations, string elites, string crossOver, string mutationOccurance, string mutationPercentage, List<string> benchmarks, string selectionMode)
		{
			// parse ints without check; it's by design
			NumberOfCromozoms = int.Parse(cromozoms);
			NumberOfGenerations = int.Parse (generations);
			ElitesPercentage = int.Parse(elites);
			CrossOverPercentage = 1 - (double.Parse (crossOver) / 100.0);
			MutationPercentage = 1 - (double.Parse (mutationPercentage) / 100.00);
			MutationOccurance = 1 - (double.Parse (mutationOccurance) / 100.00);
			Benchmarks = benchmarks;
			SelectionMode = selectionMode;

			if (SelectionMode == "Roulette Wheel") {
				throw new NotImplementedException ("Roulette Wheel Selection not implemented yet, please change to another selection.");
			}

			if (SelectionMode == "Tournament") {
				if (NumberOfCromozoms < 5) {
					throw new ArgumentException ("In case of 'Tournament Selection' the number of cromozoms must be at least 5!", cromozoms);
				}
			}
		}
	}
}

