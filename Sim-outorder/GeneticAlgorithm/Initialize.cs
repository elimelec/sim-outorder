using System;
using System.Collections.Generic;

namespace Simoutorder
{
	public class Initialize
	{
		static Random random = new Random ();
		public List<Cromozom> GeneratePopulation(int numberOfCromozoms) 
		{
			List<Cromozom> PopulationList = new List<Cromozom> ();
			int ct = 0;
			while (ct < numberOfCromozoms) {
				Cromozom cromozom = GenerateCromozom();
				cromozom.Index = ct;
				IOFunctions.CreateConfigFile(cromozom,ct.ToString());
				PopulationList.Add (cromozom);
				ct++;
			}
			return PopulationList;
		}

		protected Cromozom GenerateCromozom() 
		{
			Cromozom cromozom = new Cromozom ();
			cromozom.CoreCkFreq = CromozomValues.CoreCkFreqValues.PickRandom();
			cromozom.BusCkFreq = CromozomValues.BusCkFreq.PickRandom();
			cromozom.lg2CacheSize = CromozomValues.lg2CacheSize.PickRandom();
			cromozom.lg2Sets = CromozomValues.lg2Sets.PickRandom();
			cromozom.lg2LineSize = CromozomValues.lg2LineSize.PickRandom();
			cromozom.MissPenalty = CromozomValues.MissPenalty.PickRandom();
			cromozom.WBPenalty = CromozomValues.WBPenalty.PickRandom();
			cromozom.lg2StrSize = CromozomValues.lg2StrSize.PickRandom();
			cromozom.lg2StrSets = CromozomValues.lg2StrSets.PickRandom();
			cromozom.lg2StrLineSize = CromozomValues.lg2StrLineSize.PickRandom();
			cromozom.StrMissPenalty = CromozomValues.StrMissPenalty.PickRandom();
			cromozom.StrWBPenalty = CromozomValues.StrWBPenalty.PickRandom();
			cromozom.lg2ICacheSize = CromozomValues.lg2ICacheSize.PickRandom();
			cromozom.lg2ICacheSets = CromozomValues.lg2ICacheSets.PickRandom();
			cromozom.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize.PickRandom();
			cromozom.ICachePenalty = CromozomValues.ICachePenalty.PickRandom();
			cromozom.NumCaches = CromozomValues.NumCaches.PickRandom();
			cromozom.BranchStall = CromozomValues.BranchStall.PickRandom();
			cromozom.StreamEnable = CromozomValues.StreamEnable;
			cromozom.PrefetchEnable = CromozomValues.PrefetchEnable;
			cromozom.LockEnable = CromozomValues.LockEnable;
			cromozom.ProfGranularity = CromozomValues.ProfGranularity;
			cromozom.Fitness = CromozomValues.Fitness;
			cromozom.OptimizationLevel = CromozomValues.OptimizationLevel.PickRandom();
			cromozom.Memory = CromozomValues.Memory.PickRandom();
			cromozom.GenerationNumber = 0;
			return cromozom;
		}
	}
}

