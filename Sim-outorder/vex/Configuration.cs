using System;
using System.IO;
using System.Collections.Generic;

namespace Simoutorder
{
	public partial class Configuration
	{
		public void WriteToVexFile (string file)
		{
			var lines = new List<string> ();
			lines.Add ("CoreCkFreq " + CoreCkFreq);
			lines.Add ("BusCkFreq " + BusCkFreq);
			lines.Add ("lg2CacheSize " + lg2CacheSize);
			lines.Add ("lg2Sets " + lg2Sets);
			lines.Add ("lg2LineSize " + lg2LineSize);
			lines.Add ("MissPenalty " + MissPenalty);
			lines.Add ("WBPenalty " + WBPenalty);
			lines.Add ("lg2StrSize " + lg2StrSize);
			lines.Add ("lg2StrSets " + lg2StrSets);
			lines.Add ("lg2StrLineSize " + lg2StrLineSize);
			lines.Add ("StrMissPenalty " + StrMissPenalty);
			lines.Add ("StrWBPenalty " + StrWBPenalty);
			lines.Add ("lg2ICacheSize " + lg2ICacheSize);
			lines.Add ("lg2ICacheSets " + lg2ICacheSets);
			lines.Add ("lg2ICacheLineSize " + lg2ICacheLineSize);
			lines.Add ("ICachePenalty " + ICachePenalty);
			lines.Add ("NumCaches " + NumCaches);
			lines.Add ("BranchStall " + BranchStall);
			lines.Add ("StreamEnable " + StreamEnable);
			lines.Add ("PrefetchEnable " + PrefetchEnable);
			lines.Add ("LockEnable " + LockEnable);
			lines.Add ("ProfGranularity " + ProfGranularity);

			using (var writer = new StreamWriter(file))
			{
				foreach(var line in lines)
				{
					writer.WriteLine(line);
				}
				writer.Flush();
			}
		}
	}
}
