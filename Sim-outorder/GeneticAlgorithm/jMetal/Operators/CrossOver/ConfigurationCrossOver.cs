using JMetalCSharp.Core;
using JMetalCSharp.Encoding.SolutionType;
using JMetalCSharp.Utils;
using JMetalCSharp.Utils.Wrapper;
using System;
using System.Collections.Generic;
using Simoutorder;
using JMetalCSharp.Encoding.Variable;

namespace JMetalCSharp.Operators.Crossover
{
	public class ConfigurationCrossOver : Crossover
	{
		public const string CrossOverPercentageKey = "CrossOverPercentage";
		public double CrossOverPercentage;

		public ConfigurationCrossOver (Dictionary<string, object> parameters) : base(parameters)
		{
			JMetalCSharp.Utils.Utils.GetDoubleValueFromParameter (parameters, CrossOverPercentageKey, ref CrossOverPercentage);
		}

		public override object Execute (object obj)
		{
			var solutions = obj as Solution[];

			var solution1 = solutions [0];
			var solution2 = solutions [1];

			var var1 = solution1.Variable [0] as ConfigurationVariable;
			var var2 = solution2.Variable [0] as ConfigurationVariable;

			var config1 = var1.Value;
			var config2 = var2.Value;

			CrossOver (ref config1.CoreCkFreq, ref config2.CoreCkFreq);
			CrossOver (ref config1.BusCkFreq, ref config2.BusCkFreq);
			CrossOver (ref config1.lg2CacheSize, ref config2.lg2CacheSize);
			CrossOver (ref config1.lg2Sets, ref config2.lg2Sets);
			CrossOver (ref config1.lg2LineSize, ref config2.lg2LineSize);
			CrossOver (ref config1.MissPenalty, ref config2.MissPenalty);
			CrossOver (ref config1.WBPenalty, ref config2.WBPenalty);
			CrossOver (ref config1.lg2StrSize, ref config2.lg2StrSize);
			CrossOver (ref config1.lg2StrSets, ref config2.lg2StrSets);
			CrossOver (ref config1.lg2StrLineSize, ref config2.lg2StrLineSize);
			CrossOver (ref config1.StrMissPenalty, ref config2.StrMissPenalty);
			CrossOver (ref config1.StrWBPenalty, ref config2.StrWBPenalty);
			CrossOver (ref config1.lg2ICacheSize, ref config2.lg2ICacheSize);
			CrossOver (ref config1.lg2ICacheSets, ref config2.lg2ICacheSets);
			CrossOver (ref config1.lg2ICacheLineSize, ref config2.lg2ICacheLineSize);
			CrossOver (ref config1.ICachePenalty, ref config2.ICachePenalty);
			CrossOver (ref config1.NumCaches, ref config2.NumCaches);
			CrossOver (ref config1.BranchStall, ref config2.BranchStall);
			CrossOver (ref config1.StreamEnable, ref config2.StreamEnable);
			CrossOver (ref config1.PrefetchEnable, ref config2.PrefetchEnable);
			CrossOver (ref config1.LockEnable, ref config2.LockEnable);
			CrossOver (ref config1.ProfGranularity, ref config2.ProfGranularity);

			return obj;
		}

		private void CrossOver<T> (ref T first, ref T second)
		{
			if (ShouldCrossOver ()) {
				var temp = first;
				first = second;
				second = temp;
			}
		}

		public bool ShouldCrossOver ()
		{
			return JMetalRandom.NextDouble() >= CrossOverPercentage;
		}
	}
}

