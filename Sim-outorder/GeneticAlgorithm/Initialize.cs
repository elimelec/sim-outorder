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
			cromozom.Options = options;
			cromozom.Configuration = Configuration.NewRadom ();
			cromozom.Fitness = CromozomValues.Fitness;
			cromozom.GenerationNumber = 0;
			return cromozom;
		}
	}
}

