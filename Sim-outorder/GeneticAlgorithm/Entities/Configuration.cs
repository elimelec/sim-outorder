using System;

namespace Simoutorder
{
	public partial class Configuration
	{
		public string OptimizationLevel;
		public string Memory;
		public int CoreCkFreq;
		public int BusCkFreq;
		public int lg2CacheSize;
		public int lg2Sets;
		public int lg2LineSize;
		public int MissPenalty;
		public int WBPenalty;
		public int lg2StrSize;
		public int lg2StrSets;
		public int lg2StrLineSize;
		public int StrMissPenalty;
		public int StrWBPenalty;
		public int lg2ICacheSize;
		public int lg2ICacheSets;
		public int lg2ICacheLineSize;
		public int ICachePenalty;
		public int NumCaches;
		public int BranchStall;
		public bool StreamEnable;
		public bool PrefetchEnable;
		public bool LockEnable;
		public string ProfGranularity;
	}
}

