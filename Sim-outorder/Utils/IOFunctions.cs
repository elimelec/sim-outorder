using System;
using System.IO;
using System.Collections.Generic;

namespace Simoutorder
{
	public class IOFunctions
	{
		public static string[] GetLinesFromFile(string pathFile)
		{
			string[] lines = File.ReadAllLines(pathFile);
			return lines;
		}

		public static void ClearFiles(string rootFolderPath, string filesToDelete) 
		{
			string[] fileList = Directory.GetFiles(rootFolderPath, filesToDelete);
			foreach(string file in fileList)
			{
				File.Delete(file);
			}
		}

		public static void CreateConfigFile(Cromozom cromozom, string configFileNumber) 
		{
			var lines = GetCromozomProperties (cromozom);

			System.IO.File.WriteAllLines("vex/configurations/vex_" + configFileNumber + ".cfg", lines);
		}

		public static void CreateHistoryFile(Cromozom cromozom, int generationNumber) 
		{
			var lines = GetCromozomProperties (cromozom);
			lines.Add ("Memory " + cromozom.Configuration.Memory);
			lines.Add ("Optimization Level " + cromozom.Configuration.OptimizationLevel);
			lines.Add ("IPC " + cromozom.Fitness);

			Directory.CreateDirectory ("vex/history");
			System.IO.File.WriteAllLines("vex/history/cromozom_generation_" + generationNumber + ".txt", lines);
		}

		static List<string> GetCromozomProperties (Cromozom cromozom)
		{
			List<string> lines = new List<string> ();
			lines.Add ("CoreCkFreq " + cromozom.Configuration.CoreCkFreq);
			lines.Add ("BusCkFreq " + cromozom.Configuration.BusCkFreq);
			lines.Add ("lg2CacheSize " + cromozom.Configuration.lg2CacheSize);
			lines.Add ("lg2Sets " + cromozom.Configuration.lg2Sets);
			lines.Add ("lg2LineSize " + cromozom.Configuration.lg2LineSize);
			lines.Add ("MissPenalty " + cromozom.Configuration.MissPenalty);
			lines.Add ("WBPenalty " + cromozom.Configuration.WBPenalty);
			lines.Add ("lg2StrSize " + cromozom.Configuration.lg2StrSize);
			lines.Add ("lg2StrSets " + cromozom.Configuration.lg2StrSets);
			lines.Add ("lg2StrLineSize " + cromozom.Configuration.lg2StrLineSize);
			lines.Add ("StrMissPenalty " + cromozom.Configuration.StrMissPenalty);
			lines.Add ("StrWBPenalty " + cromozom.Configuration.StrWBPenalty);
			lines.Add ("lg2ICacheSize " + cromozom.Configuration.lg2ICacheSize);
			lines.Add ("lg2ICacheSets " + cromozom.Configuration.lg2ICacheSets);
			lines.Add ("lg2ICacheLineSize " + cromozom.Configuration.lg2ICacheLineSize);
			lines.Add ("ICachePenalty " + cromozom.Configuration.ICachePenalty);
			lines.Add ("NumCaches " + cromozom.Configuration.NumCaches);
			lines.Add ("BranchStall " + cromozom.Configuration.BranchStall);
			lines.Add ("StreamEnable " + cromozom.Configuration.StreamEnable);
			lines.Add ("PrefetchEnable " + cromozom.Configuration.PrefetchEnable);
			lines.Add ("LockEnable " + cromozom.Configuration.LockEnable);
			lines.Add ("ProfGranularity " + cromozom.Configuration.ProfGranularity);
			return lines;
		}
	}
}

