using System;
using System.Collections.Generic;

namespace Simoutorder
{
	public class GeneticAlgorithmOptions
	{
		public int NumberOfCromozoms {
			get;
			set;
		}

		public int NumberOfGenerations {
			get;
			set;
		}

		public int ElitesPercentage {
			get;
			set;
		}

		public double CrossOverPercentage {
			get;
			set;
		}

		public double MutationOccurance {
			get;
			set;
		}

		public double MutationPercentage {
			get;
			set;
		}

		public List<string> Benchmarks {
			get;
			set;
		}

		public string SelectionMode {
			get;
			set;
		}
	}
}

