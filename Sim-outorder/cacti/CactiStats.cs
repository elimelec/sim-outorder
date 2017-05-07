using System;
using System.Collections.Generic;

namespace Cacti
{
	public class CactiStats
	{
		public List<string> Lines { get; set; }

		public CactiStats (List<string> lines)
		{
			Lines = lines;
		}

		public double GetArea()
		{
			var pattern = "  Data array: Area (mm2): ";
			var areaLine = Lines.Find(l => l.Contains(pattern));
			var areaString = areaLine.Replace (pattern, "");
			var area = double.Parse (areaString);
			return area;
		}
	}
}

