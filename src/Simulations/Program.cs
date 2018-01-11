using System;
using System.Collections.Generic;

using Framework;
using Games;


namespace Simulations
{
	class Program
	{
		static void Main(string[] args)
		{
			War war = new War(2);

			war.Deck.Shuffle();
			war.Deal();

			for (int i = 0; i < war.Players.Count; i++)
			{
				Console.WriteLine("Player " + i + " Cards:");
				war.Players[i].Hand.ShowCards();
				Console.WriteLine("-----------------");
			}

			war.Play();



			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}
