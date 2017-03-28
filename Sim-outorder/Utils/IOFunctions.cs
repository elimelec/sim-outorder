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

			System.IO.File.WriteAllLines("vex-3.43/share/apps/h264dec/test/Configurations/vex_" + configFileNumber + ".cfg", lines);
		}

		public static void CreateHistoryFile(Cromozom cromozom, int generationNumber) 
		{
			var lines = GetCromozomProperties (cromozom);
			lines.Add ("Memory " + cromozom.Memory);
			lines.Add ("Optimization Level " + cromozom.OptimizationLevel);
			lines.Add ("IPC " + cromozom.Fitness);

			System.IO.File.WriteAllLines("vex-3.43/share/apps/h264dec/test/History/cromozom_generation_" + generationNumber + ".txt", lines);
		}

		static List<string> GetCromozomProperties (Cromozom cromozom)
		{
			List<string> lines = new List<string> ();
			lines.Add ("CoreCkFreq " + cromozom.CoreCkFreq);
			lines.Add ("BusCkFreq " + cromozom.BusCkFreq);
			lines.Add ("lg2CacheSize " + cromozom.lg2CacheSize);
			lines.Add ("lg2Sets " + cromozom.lg2Sets);
			lines.Add ("lg2LineSize " + cromozom.lg2LineSize);
			lines.Add ("MissPenalty " + cromozom.MissPenalty);
			lines.Add ("WBPenalty " + cromozom.WBPenalty);
			lines.Add ("lg2StrSize " + cromozom.lg2StrSize);
			lines.Add ("lg2StrSets " + cromozom.lg2StrSets);
			lines.Add ("lg2StrLineSize " + cromozom.lg2StrLineSize);
			lines.Add ("StrMissPenalty " + cromozom.StrMissPenalty);
			lines.Add ("StrWBPenalty " + cromozom.StrWBPenalty);
			lines.Add ("lg2ICacheSize " + cromozom.lg2ICacheSize);
			lines.Add ("lg2ICacheSets " + cromozom.lg2ICacheSets);
			lines.Add ("lg2ICacheLineSize " + cromozom.lg2ICacheLineSize);
			lines.Add ("ICachePenalty " + cromozom.ICachePenalty);
			lines.Add ("NumCaches " + cromozom.NumCaches);
			lines.Add ("BranchStall " + cromozom.BranchStall);
			lines.Add ("StreamEnable " + cromozom.StreamEnable);
			lines.Add ("PrefetchEnable " + cromozom.PrefetchEnable);
			lines.Add ("LockEnable " + cromozom.LockEnable);
			lines.Add ("ProfGranularity " + cromozom.ProfGranularity);
			return lines;
		}
	}
}

