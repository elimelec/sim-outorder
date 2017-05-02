using System;

namespace Simoutorder
{
	public class Cromozom
	{
		public GeneticAlgorithmOptions Options { get; set; }

		public double Fitness { get; set; }

		public int Index { get; set; }

		public int GenerationNumber { get; set; }

		public Configuration Configuration { get; set; }

		public Cromozom ()
		{
			Configuration = new Configuration ();
		}

		public Cromozom DeepCopy ()
		{
			Cromozom iCopy = (Cromozom)this.MemberwiseClone ();
			return iCopy;
		}

		public void CrossOver (Cromozom other)
		{
			CrossOver (ref Configuration.CoreCkFreq, ref other.Configuration.CoreCkFreq);
			CrossOver (ref Configuration.BusCkFreq, ref other.Configuration.BusCkFreq);
			CrossOver (ref Configuration.lg2CacheSize, ref other.Configuration.lg2CacheSize);
			CrossOver (ref Configuration.lg2Sets, ref other.Configuration.lg2Sets);
			CrossOver (ref Configuration.lg2LineSize, ref other.Configuration.lg2LineSize);
			CrossOver (ref Configuration.MissPenalty, ref other.Configuration.MissPenalty);
			CrossOver (ref Configuration.WBPenalty, ref other.Configuration.WBPenalty);
			CrossOver (ref Configuration.lg2StrSize, ref other.Configuration.lg2StrSize);
			CrossOver (ref Configuration.lg2StrSets, ref other.Configuration.lg2StrSets);
			CrossOver (ref Configuration.lg2StrLineSize, ref other.Configuration.lg2StrLineSize);
			CrossOver (ref Configuration.StrMissPenalty, ref other.Configuration.StrMissPenalty);
			CrossOver (ref Configuration.StrWBPenalty, ref other.Configuration.StrWBPenalty);
			CrossOver (ref Configuration.lg2ICacheSize, ref other.Configuration.lg2ICacheSize);
			CrossOver (ref Configuration.lg2ICacheSets, ref other.Configuration.lg2ICacheSets);
			CrossOver (ref Configuration.lg2ICacheLineSize, ref other.Configuration.lg2ICacheLineSize);
			CrossOver (ref Configuration.ICachePenalty, ref other.Configuration.ICachePenalty);
			CrossOver (ref Configuration.NumCaches, ref other.Configuration.NumCaches);
			CrossOver (ref Configuration.BranchStall, ref other.Configuration.BranchStall);
			CrossOver (ref Configuration.StreamEnable, ref other.Configuration.StreamEnable);
			CrossOver (ref Configuration.PrefetchEnable, ref other.Configuration.PrefetchEnable);
			CrossOver (ref Configuration.LockEnable, ref other.Configuration.LockEnable);
			CrossOver (ref Configuration.ProfGranularity, ref other.Configuration.ProfGranularity);
		}

		private void CrossOver<T> (ref T first, ref T second)
		{
			var temp = first;
			first = second;
			second = temp;
		}

		public void CrossOver (Action action)
		{
			if (ShouldCrossOver ()) {
				action ();
			}
		}

		public bool ShouldCrossOver ()
		{
			return new Random ().NextDouble () >= Options.CrossOverPercentage;
		}

		public void Mutate ()
		{
			Mutate (ref Configuration.CoreCkFreq, CromozomValues.CoreCkFreqValues);
			Mutate (ref Configuration.BusCkFreq, CromozomValues.BusCkFreq);
			Mutate (ref Configuration.lg2CacheSize, CromozomValues.lg2CacheSize);
			Mutate (ref Configuration.lg2Sets, CromozomValues.lg2Sets);
			Mutate (ref Configuration.lg2LineSize, CromozomValues.lg2LineSize);
			Mutate (ref Configuration.MissPenalty, CromozomValues.MissPenalty);
			Mutate (ref Configuration.WBPenalty, CromozomValues.WBPenalty);
			Mutate (ref Configuration.lg2StrSize, CromozomValues.lg2StrSize);
			Mutate (ref Configuration.lg2StrSets, CromozomValues.lg2StrSets);
			Mutate (ref Configuration.lg2StrLineSize, CromozomValues.lg2StrLineSize);
			Mutate (ref Configuration.StrMissPenalty, CromozomValues.StrMissPenalty);
			Mutate (ref Configuration.StrWBPenalty, CromozomValues.StrWBPenalty);
			Mutate (ref Configuration.lg2ICacheSize, CromozomValues.lg2ICacheSize);
			Mutate (ref Configuration.lg2ICacheSets, CromozomValues.lg2ICacheSets);
			Mutate (ref Configuration.lg2ICacheLineSize, CromozomValues.lg2ICacheLineSize);
			Mutate (ref Configuration.ICachePenalty, CromozomValues.ICachePenalty);
			Mutate (ref Configuration.NumCaches, CromozomValues.NumCaches);
			Mutate (ref Configuration.BranchStall, CromozomValues.BranchStall);
			Mutate (ref Configuration.StreamEnable, CromozomValues.StreamEnable);
			Mutate (ref Configuration.PrefetchEnable, CromozomValues.PrefetchEnable);
			Mutate (ref Configuration.LockEnable, CromozomValues.LockEnable);
			Mutate (ref Configuration.ProfGranularity, CromozomValues.ProfGranularity);
		}

		private void Mutate <T> (ref T property, T[] values)
		{
			property = values.PickRandom ();
		}

		private void Mutate <T> (ref T property, T value)
		{
			property = value;
		}

		private void Mutate (Action action)
		{
			if (ShouldMutate ()) {
				action ();
			}
		}

		private bool ShouldMutate ()
		{
			return new Random ().NextDouble () >= Options.MutationPercentage;
		}
	}
}

