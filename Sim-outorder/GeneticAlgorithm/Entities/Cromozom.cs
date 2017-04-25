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
			MutateIf (() => { Configuration.CoreCkFreq = CromozomValues.CoreCkFreqValues.PickRandom();});
			MutateIf (() => { Configuration.BusCkFreq = CromozomValues.BusCkFreq.PickRandom();});
			MutateIf (() => { Configuration.lg2CacheSize = CromozomValues.lg2CacheSize.PickRandom();});
			MutateIf (() => { Configuration.lg2Sets = CromozomValues.lg2Sets.PickRandom();});
			MutateIf (() => { Configuration.lg2LineSize = CromozomValues.lg2LineSize.PickRandom();});
			MutateIf (() => { Configuration.MissPenalty = CromozomValues.MissPenalty.PickRandom();});
			MutateIf (() => { Configuration.WBPenalty = CromozomValues.WBPenalty.PickRandom();});
			MutateIf (() => { Configuration.lg2StrSize = CromozomValues.lg2StrSize.PickRandom();});
			MutateIf (() => { Configuration.lg2StrSets = CromozomValues.lg2StrSets.PickRandom();});
			MutateIf (() => { Configuration.lg2StrLineSize = CromozomValues.lg2StrLineSize.PickRandom();});
			MutateIf (() => { Configuration.StrMissPenalty = CromozomValues.StrMissPenalty.PickRandom();});
			MutateIf (() => { Configuration.StrWBPenalty = CromozomValues.StrWBPenalty.PickRandom();});
			MutateIf (() => { Configuration.lg2ICacheSize = CromozomValues.lg2ICacheSize.PickRandom();});
			MutateIf (() => { Configuration.lg2ICacheSets = CromozomValues.lg2ICacheSets.PickRandom();});
			MutateIf (() => { Configuration.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize.PickRandom();});
			MutateIf (() => { Configuration.ICachePenalty = CromozomValues.ICachePenalty.PickRandom();});
			MutateIf (() => { Configuration.NumCaches = CromozomValues.NumCaches.PickRandom();});
			MutateIf (() => { Configuration.BranchStall = CromozomValues.BranchStall.PickRandom();});
			MutateIf (() => { Configuration.StreamEnable = CromozomValues.StreamEnable;});
			MutateIf (() => { Configuration.PrefetchEnable = CromozomValues.PrefetchEnable;});
			MutateIf (() => { Configuration.LockEnable = CromozomValues.LockEnable;});
			MutateIf (() => { Configuration.ProfGranularity = CromozomValues.ProfGranularity;});
		}

		private void MutateIf(Action action)
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

