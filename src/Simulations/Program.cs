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

			Console.WriteLine("Starting Deck...");
			Console.WriteLine(war.Deck.ToString());


			Console.WriteLine("Shuffled Deck...");
			war.Deck.Shuffle();
			Console.WriteLine(war.Deck.ToString());

			Console.WriteLine("Player Hands...");
			war.Deal();
			for (int i = 0; i < war.Players; i ++)
			{
				Console.WriteLine("Player " + i.ToString());
				Console.WriteLine(war.PlayerCardsHeld[i].Count);
				Console.WriteLine();
			}

			Console.WriteLine("Cards left: " + war.Deck.Cards.Count);

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}
