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

		public bool EqualWith(Configuration other)
		{
			
			bool equal = true;

			equal = equal && other.OptimizationLevel == OptimizationLevel;
			equal = equal && other.Memory == Memory;
			equal = equal && other.CoreCkFreq == CoreCkFreq;
			equal = equal && other.BusCkFreq == BusCkFreq;
			equal = equal && other.lg2CacheSize == lg2CacheSize;
			equal = equal && other.lg2Sets == lg2Sets;
			equal = equal && other.lg2LineSize == lg2LineSize;
			equal = equal && other.MissPenalty == MissPenalty;
			equal = equal && other.WBPenalty == WBPenalty;
			equal = equal && other.lg2StrSize == lg2StrSize;
			equal = equal && other.lg2StrSets == lg2StrSets;
			equal = equal && other.lg2StrLineSize == lg2StrLineSize;
			equal = equal && other.StrMissPenalty == StrMissPenalty;
			equal = equal && other.StrWBPenalty == StrWBPenalty;
			equal = equal && other.lg2ICacheSize == lg2ICacheSize;
			equal = equal && other.lg2ICacheSets == lg2ICacheSets;
			equal = equal && other.lg2ICacheLineSize == lg2ICacheLineSize;
			equal = equal && other.ICachePenalty == ICachePenalty;
			equal = equal && other.NumCaches == NumCaches;
			equal = equal && other.BranchStall == BranchStall;
			equal = equal && other.StreamEnable == StreamEnable;
			equal = equal && other.PrefetchEnable == PrefetchEnable;
			equal = equal && other.LockEnable == LockEnable;
			equal = equal && other.ProfGranularity == ProfGranularity;

			return equal;
		}

		public Configuration DeepCopy()
		{
			return MemberwiseClone () as Configuration;
		}

		public override int GetHashCode ()
		{
			string equal = "";
			equal = equal + "," +  OptimizationLevel;
			equal = equal + "," +  Memory;
			equal = equal + "," +  CoreCkFreq;
			equal = equal + "," +  BusCkFreq;
			equal = equal + "," +  lg2CacheSize;
			equal = equal + "," +  lg2Sets;
			equal = equal + "," +  lg2LineSize;
			equal = equal + "," +  MissPenalty;
			equal = equal + "," +  WBPenalty;
			equal = equal + "," +  lg2StrSize;
			equal = equal + "," +  lg2StrSets;
			equal = equal + "," +  lg2StrLineSize;
			equal = equal + "," +  StrMissPenalty;
			equal = equal + "," +  StrWBPenalty;
			equal = equal + "," +  lg2ICacheSize;
			equal = equal + "," +  lg2ICacheSets;
			equal = equal + "," +  lg2ICacheLineSize;
			equal = equal + "," +  ICachePenalty;
			equal = equal + "," +  NumCaches;
			equal = equal + "," +  BranchStall;
			equal = equal + "," +  StreamEnable;
			equal = equal + "," +  PrefetchEnable;
			equal = equal + "," +  LockEnable;
			equal = equal + "," +  ProfGranularity;
			return equal.GetHashCode ();
		}
	}
}

