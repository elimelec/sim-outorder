using System;

namespace Simoutorder
{
	public static class CromozomValues
	{
		public static int[] CoreCkFreqValues = new int[100];
		public static int[] BusCkFreq = new int[3]{500,500,500};
		public static int[] lg2CacheSize = new int[3]{15,20,25}; 		// (CacheSize = 256k)
		public static int[] lg2Sets = new int[3]{0,1,2}; 		 		// (Sets = 4)
		public static int[] lg2LineSize = new int[3]{6,7,8};   			// (LineSize = 32)
		public static int[] MissPenalty = new int[3]{36,36,36};
		public static int[] WBPenalty = new int[3]{33,33,33};
		public static int[] lg2StrSize = new int[3]{9,9,9}; 	 		// (StrSize = 512)
		public static int[] lg2StrSets = new int[3]{4,4,4};				// (StrSets = 16)
		public static int[] lg2StrLineSize = new int[3]{5,5,5};       	// (StrLineSize = 32)
		public static int[] StrMissPenalty = new int[3]{36,36,36};
		public static int[] StrWBPenalty = new int[3]{33,33,33};
		public static int[] lg2ICacheSize = new int[3]{15,20,25};		// (ICacheSize = 32k)
		public static int[] lg2ICacheSets = new int[3]{0,1,2};        	// (ICacheSets = 1)
		public static int[] lg2ICacheLineSize = new int[3]{6,7,8};  	// (ICacheLineSize = 64)
		public static int[] ICachePenalty = new int[3]{45,45,45};
		public static int[] NumCaches = new int[3]{1,1,1};
		public static int[] BranchStall = new int[3]{1,1,1};
		public static bool StreamEnable = false;
		public static bool PrefetchEnable = true;
		public static bool LockEnable = false;
		public static string ProfGranularity = "AUTO";
		public static double Fitness = 0;
		public static string[] OptimizationLevel = new string[5]{"-O1","-O2","-O3","-O4","-O5"};
		public static string[] Memory = new string[4]{"vex2.mm","vex4.mm","vex8.mm","vex16.mm"};

		static CromozomValues ()
		{
			GenerateCoreFreqValues ();
		}

		private static void GenerateCoreFreqValues()
		{
			int ct = 1;
			for (int i = 0; i < 100; i++) {
				CoreCkFreqValues [i] = ct + 300;
				ct += 2;
			}
		}
	}
}

