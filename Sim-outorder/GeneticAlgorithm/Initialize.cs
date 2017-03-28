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
			cromozom.CoreCkFreq = CromozomValues.CoreCkFreqValues [random.Next (0, 100)];
			cromozom.BusCkFreq = CromozomValues.BusCkFreq [random.Next (0, 3)];
			cromozom.lg2CacheSize = CromozomValues.lg2CacheSize [random.Next (0, 3)];
			cromozom.lg2Sets = CromozomValues.lg2Sets [random.Next (0, 3)];
			cromozom.lg2LineSize = CromozomValues.lg2LineSize [random.Next (0, 3)];
			cromozom.MissPenalty = CromozomValues.MissPenalty [random.Next (0, 3)];
			cromozom.WBPenalty = CromozomValues.WBPenalty [random.Next (0, 3)];
			cromozom.lg2StrSize = CromozomValues.lg2StrSize [random.Next (0, 3)];
			cromozom.lg2StrSets = CromozomValues.lg2StrSets [random.Next (0, 3)];
			cromozom.lg2StrLineSize = CromozomValues.lg2StrLineSize [random.Next (0, 3)];
			cromozom.StrMissPenalty = CromozomValues.StrMissPenalty [random.Next (0, 3)];
			cromozom.StrWBPenalty = CromozomValues.StrWBPenalty [random.Next (0, 3)];
			cromozom.lg2ICacheSize = CromozomValues.lg2ICacheSize [random.Next (0, 3)];
			cromozom.lg2ICacheSets = CromozomValues.lg2ICacheSets [random.Next (0, 3)];
			cromozom.lg2ICacheLineSize = CromozomValues.lg2ICacheLineSize [random.Next (0, 3)];
			cromozom.ICachePenalty = CromozomValues.ICachePenalty [random.Next (0, 3)];
			cromozom.NumCaches = CromozomValues.NumCaches [random.Next (0, 3)];
			cromozom.BranchStall = CromozomValues.BranchStall [random.Next (0, 3)];
			cromozom.StreamEnable = CromozomValues.StreamEnable;
			cromozom.PrefetchEnable = CromozomValues.PrefetchEnable;
			cromozom.LockEnable = CromozomValues.LockEnable;
			cromozom.ProfGranularity = CromozomValues.ProfGranularity;
			cromozom.Fitness = CromozomValues.Fitness;
			cromozom.OptimizationLevel = CromozomValues.OptimizationLevel[random.Next (0, 5)];
			cromozom.Memory = CromozomValues.Memory[random.Next (0, 4)];
			cromozom.GenerationNumber = 0;
			return cromozom;
		}
	}
}

