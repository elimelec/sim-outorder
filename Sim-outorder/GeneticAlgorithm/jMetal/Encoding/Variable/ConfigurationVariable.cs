using System;
using Simoutorder;

namespace JMetalCSharp.Encoding.Variable
{
	public class ConfigurationVariable : Variable<Configuration>
	{
		public ConfigurationVariable (Configuration value) : base (value)
		{
		}

		public override Core.Variable DeepCopy ()
		{
			var copy = Value.DeepCopy ();
			return new ConfigurationVariable (copy);
		}
	}
}

