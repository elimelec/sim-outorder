using System;
using System.Collections.Generic;

namespace Simoutorder
{
	public class Initialize
	{
		public List<Cromozom> GeneratePopulation(GeneticAlgorithmOptions options) 
		{
			List<Cromozom> PopulationList = new List<Cromozom> ();
			int ct = 0;
			while (ct < options.NumberOfCromozoms) {
				Cromozom cromozom = GenerateCromozom(options);
				cromozom.Index = ct;
				IOFunctions.CreateConfigFile(cromozom,ct.ToString());
				PopulationList.Add (cromozom);
				ct++;
			}
			return PopulationList;
		}

		protected Cromozom GenerateCromozom(GeneticAlgorithmOptions options) 
		{
			Cromozom cromozom = new Cromozom ();
			cromozom.MutationPercentage = options.MutationPercentage;
			cromozom.Configuration.CoreCkFreq = CromozomValues.CoreCkFreqValues.PickRandom();
			cromozom.Configuration.BusCkFreq = CromozomValues.BusCkFreq.PickRandom();
			cromozom.Configuration.lg2CacheSize = CromozomValues.lg2CacheSize.PickRandom();
			cromozom.Configuration.lg2Sets = CromozomValues.lg2Sets.PickRandom();
			cromozom.Configuration.lg2LineSize = CromozomValues.lg2LineSize.PickRandom();
			cromozom.Configuration.MissPenalty = CromozomValues.MissPenalty.PickRandom();
			cromozom.Configuration.WBPenalty = CromozomValues.WBPenalty.PickRandom();
			cromozom.Configuration.lg2StrSize = CromozomValues.lg2StrSize.PickRandom();
			cromozom.Configuration.lg2StrSets = CromozomValues.lg2StrSets.PickRandom();
			cromozom.Configuration.lg2StrLineSize = CromozomValues.lg2StrLineSize.PickRandom();
			cromozom.Configuration.StrMissPenalty = CromozomValues.StrMissPenalty.PickRandom();
			cromozom.Configuration.StrWBPenalty = CromozomValues.StrWBPenalty.PickRandom();
			cromozom.Configuration.lg2ICacheSize = CromozomValues.lg2ICacheSize.PickRandom();
			cromozom.Configuration.lg2ICacheSets = CromozomValues.lg2ICacheSets.PickRandom();
			cromozom.Configuration.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize.PickRandom();
			cromozom.Configuration.ICachePenalty = CromozomValues.ICachePenalty.PickRandom();
			cromozom.Configuration.NumCaches = CromozomValues.NumCaches.PickRandom();
			cromozom.Configuration.BranchStall = CromozomValues.BranchStall.PickRandom();
			cromozom.Configuration.StreamEnable = CromozomValues.StreamEnable;
			cromozom.Configuration.PrefetchEnable = CromozomValues.PrefetchEnable;
			cromozom.Configuration.LockEnable = CromozomValues.LockEnable;
			cromozom.Configuration.ProfGranularity = CromozomValues.ProfGranularity;
			cromozom.Fitness = CromozomValues.Fitness;
			cromozom.OptimizationLevel = CromozomValues.OptimizationLevel.PickRandom();
			cromozom.Memory = CromozomValues.Memory.PickRandom();
			cromozom.GenerationNumber = 0;
			return cromozom;
		}
	}
}

