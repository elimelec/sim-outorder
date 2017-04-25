using System;

namespace Simoutorder
{
	public class Configuration
	{
		public string OptimizationLevel { get; set; }

		public string Memory { get; set; }

		public double Fitness { get; set; }

		public int Index { get; set; }

		public int CoreCkFreq { get; set; }

		public int BusCkFreq { get; set; }

		public int lg2CacheSize { get; set; }

		public int lg2Sets { get; set; }

		public int lg2LineSize { get; set; }

		public int MissPenalty { get; set; }

		public int WBPenalty { get; set; }

		public int lg2StrSize { get; set; }

		public int lg2StrSets { get; set; }

		public int lg2StrLineSize { get; set; }

		public int StrMissPenalty { get; set; }

		public int StrWBPenalty { get; set; }

		public int lg2ICacheSize { get; set; }

		public int lg2ICacheSets { get; set; }

		public int lg2ICacheLineSize { get; set; }

		public int ICachePenalty { get; set; }

		public int NumCaches { get; set; }

		public int BranchStall { get; set; }

		public bool StreamEnable { get; set; }

		public bool PrefetchEnable { get; set; }

		public bool LockEnable { get; set; }

		public string ProfGranularity { get; set; }
	}
}

