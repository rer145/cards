using System;
using System.Collections.Generic;
using System.Threading;

namespace Framework
{
	public static class Extensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = ThreadSafeRandom.RandomThread.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		public static T Next<T>(this IList<T> list)
		{
			if (list.Count > 0)
			{
				T card = list[0];
				list.RemoveAt(0);
				return card;
			}
			else
			{
				return default(T);    //deck is empty
			}
		}

		public static T Peek<T>(this IList<T> list)
		{
			return list.Count > 0 ? list[0] : default(T);
		}

		public static void ShowCards(this IList<Card> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i].ToString());
			}
		}
	}

	public static class ThreadSafeRandom
	{
		[ThreadStatic]
		private static Random Local;

		public static Random RandomThread
		{
			get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
		}
	}
}
