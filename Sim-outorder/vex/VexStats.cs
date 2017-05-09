using System;
using System.Collections.Generic;

namespace Vex
{
	public class VexStats
	{
		public List<string> Lines { get; set; }

		public VexStats (List<string> lines)
		{
			Lines = lines;
		}

		public double GetIPC()
		{
			var pattern = "Avg. IPC (with stalls): ";
			var ipcLine = Lines.Find(l => l.Contains(pattern));
			var ipcString = ipcLine.Replace (pattern, "");
			var ipc = double.Parse (ipcString);
			return ipc;
		}

		public double GetCPI()
		{
			var ipc = GetIPC ();
			var cpi = 1 / ipc;
			return cpi;
		}
	}
}

