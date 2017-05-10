using System;

using Cacti;
using Vex;

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

namespace Simoutorder
{
	public class ConfigurationProblem : Problem
	{
		public ConfigurationProblem()
		{
			NumberOfVariables = ConfigurationSolutionType.NumberOfVariables;
			NumberOfObjectives = 2;
			NumberOfConstraints = 0;
			ProblemName = this.GetType().Name;
			SolutionType = new ConfigurationSolutionType (this);
		}

		public override void Evaluate(Solution solution)
		{
			var solutionType = solution.Type as ConfigurationSolutionType;
			var variables = solution.Variable;
			var configuration = solutionType.GetConfiguration (variables);

			var vex = new VexRunner (configuration);
			vex.Run ();
			var vexStats = vex.Stats;

			var cacti = new CactiRunner (configuration);
			cacti.Run ();
			var cactiStats = cacti.Stats;

			solution.Objective [0] = vexStats.GetCPI ();
			solution.Objective [1] = cactiStats.GetArea ();
		}
	}
}

