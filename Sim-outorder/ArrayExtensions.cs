using System;
using System.Linq;
using System.Collections.Generic;

namespace Simoutorder
{
	public static class ArrayExtensions
	{
		public static T PickRandom<T>(this T[] source)
		{
			return source.PickRandom(1)[0];
		}

		public static T[] PickRandom<T>(this T[] source, int count)
		{
			return source.ToList().Shuffle().Take(count).ToArray();
		}

		public static IEnumerable<T> Shuffle<T>(this T[] source)
		{
			return source.OrderBy(x => Guid.NewGuid());
		}
	}
}

