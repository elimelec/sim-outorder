using System;
using Simoutorder;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Cacti
{
	public class Cacti
	{
		public Configuration Configuration { get; set; }

		public CactiStats Stats { get; set; }

		public Cacti (Configuration configuration)
		{
			Configuration = configuration;
		}

		public IEnumerable<string> ReadLines (Func<StreamReader> streamProvider)
		{
			using (var reader = streamProvider ()) {
				string line;
				while ((line = reader.ReadLine ()) != null) {
					yield return line;
				}
			}
		}

		public void Run ()
		{
			WithTempFile (input => {
				Configuration.WriteToCactiFile (input);

				var procStartInfo = new ProcessStartInfo ("cacti/cacti", $"-infile {input}");
				procStartInfo.UseShellExecute = false;
				procStartInfo.CreateNoWindow = true;
				procStartInfo.RedirectStandardOutput = true;

				var proc = Process.Start (procStartInfo);
				proc.WaitForExit ();

				var lines = ReadLines (() => proc.StandardOutput).ToList ();
				Stats = new CactiStats(lines);
			});
		}

		private void WithTempFile (Action<string> action)
		{
			var file = Path.GetTempFileName ();
			action (file);
			File.Delete (file);
		}
	}
}
