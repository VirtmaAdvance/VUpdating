using System.Collections;

namespace VUpdating.Systems.Extensions.Iteration
{
	internal static class IterationExt
	{

		public static void ForEach<T>(this T[] array, Action<T> predicate)
		{
			foreach (var sel in array)
				predicate.Invoke(sel);
		}

	}
}
