using System;
using Simoutorder;

using JMetalCSharp.Core;
using JMetalCSharp.Operators.Crossover;
using JMetalCSharp.Operators.Mutation;
using JMetalCSharp.Operators.Selection;
using JMetalCSharp.Problems;
using JMetalCSharp.QualityIndicator;
using JMetalCSharp.Utils;
using JMetalCSharp.Metaheuristics.NSGAII;
using JMetalCSharp.Encoding.SolutionType;
using JMetalCSharp.Utils.Wrapper;
using JMetalCSharp.Encoding.Variable;

namespace JMetalCSharp.Encoding.SolutionType
{
	public class ConfigurationSolutionType : Core.SolutionType
	{
		/// <summary>
		/// Based on the number of variables in Configuration class
		/// </summary>
		public const int NumberOfVariables = 1;

		public ConfigurationSolutionType (Problem problem) : base(problem)
		{ }

		public override Core.Variable[] CreateVariables ()
		{
			var configuration = Configuration.NewRadom ();
			var variable = new ConfigurationVariable (configuration);
			var variables = new Core.Variable[NumberOfVariables] { variable };
			return variables;
		}

		public Configuration GetConfiguration(Core.Variable[] variables)
		{
			var variable = variables [0] as ConfigurationVariable;
			var configuration = variable.Value;
			return configuration;
		}
	}
}
