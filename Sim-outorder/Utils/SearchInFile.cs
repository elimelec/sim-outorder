using System;
using System.Collections.Generic;
using System.Text;


namespace Simoutorder
{
	public class SearchInFile
	{
		public static Dictionary<string,double> GetSimulatorValuesByText(string []lines,string []searchParameters)
		{
			Dictionary<string,double> resultDictionary = new Dictionary<string, double> ();
			double valoareGasita = 0;
			foreach (string line in lines) // aici cautam in fisier lines
			{
				foreach (string itemDeCautat in searchParameters) // aici cautam chestii like sim_IPC
				{
					if (line.Contains(itemDeCautat)) 
					{
						TryParseDouble (line, out valoareGasita);
						resultDictionary.Add (itemDeCautat, valoareGasita);
					}
				}
			}
			return resultDictionary;
		}

		private static bool TryParseDouble(string input, out double value){
			if (string.IsNullOrWhiteSpace (input)) {
				value = 0;
				return false;

			}
			const string Numbers = "0123456789.";
			var numberBuilder = new StringBuilder();
			foreach(char c in input) {
				if(Numbers.IndexOf(c) > -1)
					numberBuilder.Append(c);
			}
			numberBuilder = numberBuilder.Remove (0, 1);
			return double.TryParse(numberBuilder.ToString(), out value);
		}
	}


}

