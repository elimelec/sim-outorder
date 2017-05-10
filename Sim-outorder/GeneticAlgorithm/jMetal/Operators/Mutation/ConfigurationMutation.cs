using JMetalCSharp.Core;
using JMetalCSharp.Encoding.SolutionType;
using JMetalCSharp.Utils;
using JMetalCSharp.Utils.Wrapper;
using System;
using System.Collections.Generic;
using Simoutorder;
using JMetalCSharp.Encoding.Variable;

namespace JMetalCSharp.Operators.Mutation
{
	public class ConfigurationMutation : Mutation
	{
		public const string MutationPercentageKey = "MutationPercentage";
		public double MutationPercentage;

		public ConfigurationMutation (Dictionary<string, object> parameters) : base (parameters)
		{
			JMetalCSharp.Utils.Utils.GetDoubleValueFromParameter (parameters, MutationPercentageKey, ref MutationPercentage);
		}

		public override object Execute(object obj)
		{
			var solution = obj as Solution;
			var variable = solution.Variable [0] as ConfigurationVariable;
			var config = variable.Value;

			Mutate (ref config.CoreCkFreq, CromozomValues.CoreCkFreqValues);
			Mutate (ref config.BusCkFreq, CromozomValues.BusCkFreq);
			Mutate (ref config.lg2CacheSize, CromozomValues.lg2CacheSize);
			Mutate (ref config.lg2Sets, CromozomValues.lg2Sets);
			Mutate (ref config.lg2LineSize, CromozomValues.lg2LineSize);
			Mutate (ref config.MissPenalty, CromozomValues.MissPenalty);
			Mutate (ref config.WBPenalty, CromozomValues.WBPenalty);
			Mutate (ref config.lg2StrSize, CromozomValues.lg2StrSize);
			Mutate (ref config.lg2StrSets, CromozomValues.lg2StrSets);
			Mutate (ref config.lg2StrLineSize, CromozomValues.lg2StrLineSize);
			Mutate (ref config.StrMissPenalty, CromozomValues.StrMissPenalty);
			Mutate (ref config.StrWBPenalty, CromozomValues.StrWBPenalty);
			Mutate (ref config.lg2ICacheSize, CromozomValues.lg2ICacheSize);
			Mutate (ref config.lg2ICacheSets, CromozomValues.lg2ICacheSets);
			Mutate (ref config.lg2ICacheLineSize, CromozomValues.lg2ICacheLineSize);
			Mutate (ref config.ICachePenalty, CromozomValues.ICachePenalty);
			Mutate (ref config.NumCaches, CromozomValues.NumCaches);
			Mutate (ref config.BranchStall, CromozomValues.BranchStall);
			Mutate (ref config.StreamEnable, CromozomValues.StreamEnable);
			Mutate (ref config.PrefetchEnable, CromozomValues.PrefetchEnable);
			Mutate (ref config.LockEnable, CromozomValues.LockEnable);
			Mutate (ref config.ProfGranularity, CromozomValues.ProfGranularity);

			return obj;
		}

		private void Mutate <T> (ref T property, T[] values)
		{
			if (ShouldMutate ()) {
				property = values.PickRandom ();
			}
		}

		private void Mutate <T> (ref T property, T value)
		{
			if (ShouldMutate ()) {
				property = value;
			}
		}

		private bool ShouldMutate ()
		{
			return JMetalRandom.NextDouble () >= MutationPercentage;
		}
	}
}

