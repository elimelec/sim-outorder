using JMetalCSharp.Core;
using JMetalCSharp.Utils;
using JMetalCSharp.Utils.Comparators;
using System.Collections.Generic;
using System;
using System.Linq;

namespace JMetalCSharp.Operators.Selection
{
	public class ConfigurationSelection : Selection
	{
		public ConfigurationSelection (Dictionary<string, object> parameters) : base(parameters)
		{
		}

		/// <summary>
		/// This method executes the operator represented by the current object.
		/// </summary>
		/// <param name="obj">A Solution object.</param>
		public override object Execute(object obj)
		{
			var solutionSet = obj as SolutionSet;
			var solutions = solutionSet.SolutionsList;

			var bestPerformance = solutions.OrderBy (s => s.Objective [0]).Last ();
			var bestArea = solutions.OrderBy (s => s.Objective [1]).First ();

			if (JMetalRandom.NextDouble () > 0.5) {
				return bestPerformance;
			} else {
				return bestArea;
			}
		}
	}
}

