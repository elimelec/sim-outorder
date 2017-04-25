using System;

namespace Simoutorder
{
	public class Cromozom
	{
		public double MutationPercentage { get; set; }

		public string OptimizationLevel { get; set; }

		public string Memory { get; set; }

		public double Fitness { get; set; }

		public int Index { get; set; }

		public int GenerationNumber { get; set; }

		public Configuration Configuration { get; set; }

		public Cromozom()
		{
			Configuration = new Configuration ();
		}

		public Cromozom DeepCopy ()
		{
			Cromozom iCopy = (Cromozom)this.MemberwiseClone ();
			return iCopy;
		}

		public void Mutate()
		{
			Mutate (() => { Configuration.CoreCkFreq = CromozomValues.CoreCkFreqValues.PickRandom();});
			Mutate (() => { Configuration.BusCkFreq = CromozomValues.BusCkFreq.PickRandom();});
			Mutate (() => { Configuration.lg2CacheSize = CromozomValues.lg2CacheSize.PickRandom();});
			Mutate (() => { Configuration.lg2Sets = CromozomValues.lg2Sets.PickRandom();});
			Mutate (() => { Configuration.lg2LineSize = CromozomValues.lg2LineSize.PickRandom();});
			Mutate (() => { Configuration.MissPenalty = CromozomValues.MissPenalty.PickRandom();});
			Mutate (() => { Configuration.WBPenalty = CromozomValues.WBPenalty.PickRandom();});
			Mutate (() => { Configuration.lg2StrSize = CromozomValues.lg2StrSize.PickRandom();});
			Mutate (() => { Configuration.lg2StrSets = CromozomValues.lg2StrSets.PickRandom();});
			Mutate (() => { Configuration.lg2StrLineSize = CromozomValues.lg2StrLineSize.PickRandom();});
			Mutate (() => { Configuration.StrMissPenalty = CromozomValues.StrMissPenalty.PickRandom();});
			Mutate (() => { Configuration.StrWBPenalty = CromozomValues.StrWBPenalty.PickRandom();});
			Mutate (() => { Configuration.lg2ICacheSize = CromozomValues.lg2ICacheSize.PickRandom();});
			Mutate (() => { Configuration.lg2ICacheSets = CromozomValues.lg2ICacheSets.PickRandom();});
			Mutate (() => { Configuration.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize.PickRandom();});
			Mutate (() => { Configuration.ICachePenalty = CromozomValues.ICachePenalty.PickRandom();});
			Mutate (() => { Configuration.NumCaches = CromozomValues.NumCaches.PickRandom();});
			Mutate (() => { Configuration.BranchStall = CromozomValues.BranchStall.PickRandom();});
			Mutate (() => { Configuration.StreamEnable = CromozomValues.StreamEnable;});
			Mutate (() => { Configuration.PrefetchEnable = CromozomValues.PrefetchEnable;});
			Mutate (() => { Configuration.LockEnable = CromozomValues.LockEnable;});
			Mutate (() => { Configuration.ProfGranularity = CromozomValues.ProfGranularity;});
		}

		private void Mutate(Action action)
		{
			if (ShouldMutate()) {
				action ();
			}
		}

		private bool ShouldMutate()
		{
			return new Random().NextDouble () >= MutationPercentage;
		}
	}
}

