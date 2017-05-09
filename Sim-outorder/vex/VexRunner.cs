using System;
using Simoutorder;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Vex
{
	public class VexRunner
	{
		public Configuration Configuration { get; set; }

		public VexStats Stats { get; set; }

		public VexRunner (Configuration configuration)
		{
			Configuration = configuration;
		}

		public void Run ()
		{
			WithTempFile (input => {
				Configuration.WriteToVexFile (input);

				var memory = Configuration.Memory;
				var benchmark = "susan";
				var optimizationLevel = Configuration.OptimizationLevel;

				var vexcfgFile = input;
				var memoryFile = $@"vex/memories/{memory}";
				var benchmarkPreFile = $@"vex/benchmarks/{benchmark}";

				var exportCmd = $@"export VEXCFG=""{vexcfgFile}""";
				var compileCmd = $@"vex/bin/cc -c -mas_t -fmm=""{memoryFile}"" {optimizationLevel} {benchmarkPreFile}.c";
				var compileBasicMathCmd = $@"{compileCmd} vex/benchmarks/rad2deg.c vex/benchmarks/cubic.c vex/benchmarks/isqrt.c";
				var linkCmd = $@"vex/bin/cc -o {benchmark} {benchmark}.o -lm";
				var linkBasicMathCmd = $@"{linkCmd} rad2deg.o cubic.o isqrt.o -lm";
				var runCmd = $@"./{benchmark}";

				String command = "";
				if (benchmark == "susan") {
					command = $@"-c '{exportCmd} && {compileCmd} && {linkCmd} && {runCmd}'";
				}
				if (benchmark == "basicmath_small" || benchmark == "basicmath_large") {
					command = $@"-c '{exportCmd} && {compileBasicMathCmd} && {linkBasicMathCmd} && {runCmd}'";
				}

				var procStartInfo = new ProcessStartInfo("/bin/bash", command);
				procStartInfo.UseShellExecute = false;
				procStartInfo.CreateNoWindow = true;
				procStartInfo.RedirectStandardOutput = true;

				var proc = Process.Start (procStartInfo);
				proc.WaitForExit ();

				var outputFile = "ta.log.000";
				var lines = File.ReadLines(outputFile).ToList();
				File.Delete(outputFile);

				Stats = new VexStats(lines);
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

