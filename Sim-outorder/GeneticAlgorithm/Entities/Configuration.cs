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

		public static Configuration NewRadom()
		{
			var configuration = new Configuration ();

			configuration.CoreCkFreq = CromozomValues.CoreCkFreqValues.PickRandom();
			configuration.BusCkFreq = CromozomValues.BusCkFreq.PickRandom();
			configuration.lg2CacheSize = CromozomValues.lg2CacheSize.PickRandom();
			configuration.lg2Sets = CromozomValues.lg2Sets.PickRandom();
			configuration.lg2LineSize = CromozomValues.lg2LineSize.PickRandom();
			configuration.MissPenalty = CromozomValues.MissPenalty.PickRandom();
			configuration.WBPenalty = CromozomValues.WBPenalty.PickRandom();
			configuration.lg2StrSize = CromozomValues.lg2StrSize.PickRandom();
			configuration.lg2StrSets = CromozomValues.lg2StrSets.PickRandom();
			configuration.lg2StrLineSize = CromozomValues.lg2StrLineSize.PickRandom();
			configuration.StrMissPenalty = CromozomValues.StrMissPenalty.PickRandom();
			configuration.StrWBPenalty = CromozomValues.StrWBPenalty.PickRandom();
			configuration.lg2ICacheSize = CromozomValues.lg2ICacheSize.PickRandom();
			configuration.lg2ICacheSets = CromozomValues.lg2ICacheSets.PickRandom();
			configuration.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize.PickRandom();
			configuration.ICachePenalty = CromozomValues.ICachePenalty.PickRandom();
			configuration.NumCaches = CromozomValues.NumCaches.PickRandom();
			configuration.BranchStall = CromozomValues.BranchStall.PickRandom();
			configuration.StreamEnable = CromozomValues.StreamEnable;
			configuration.PrefetchEnable = CromozomValues.PrefetchEnable;
			configuration.LockEnable = CromozomValues.LockEnable;
			configuration.ProfGranularity = CromozomValues.ProfGranularity;
			configuration.OptimizationLevel = CromozomValues.OptimizationLevel.PickRandom();
			configuration.Memory = CromozomValues.Memory.PickRandom();

			return configuration;
		}

		public Configuration DeepCopy()
		{
			return MemberwiseClone () as Configuration;
		}
	}
}

