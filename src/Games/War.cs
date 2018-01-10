using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Framework;


namespace Games
{
	public class War : IGame
	{
		public Dictionary<int, List<Card>> PlayerCardsDown { get; set; }
		public Dictionary<int, List<Card>> PlayerCardsHeld { get; set; }
		public int Players { get; set; }
		public IDeck Deck { get; set; }

		public War(int players)
		{
			this.Players = players;
			this.Deck = new AceHighDeck();
			this.PlayerCardsHeld = new Dictionary<int, List<Card>>();
			this.PlayerCardsDown = new Dictionary<int, List<Card>>();

			for (int i = 0; i < players; i++)
			{
				this.PlayerCardsHeld.Add(i, new List<Card>());
				this.PlayerCardsDown.Add(i, new List<Card>());
			}
		}
		
		public void Deal()
		{
			while (this.Deck.Cards.Count > 0)
			{
				for (int j = 0; j < this.Players; j++)
				{
					this.PlayerCardsHeld[j].Add(this.Deck.Cards.Next());
					//this.PlayerCardsHeld[j].Add(this.Deck.Cards[0]);
					//this.Deck.Cards.RemoveAt(0);
				}
			}
		}

		public void Play()
		{
			bool done = false;

			int winner = -1;
			Dictionary<int, Card> currentCards = new Dictionary<int, Card>();

			while (!done)
			{
				currentCards.Clear();

				for (int i = 0; i < this.Players; i++)
				{
					//only if the player has cards left
					if (this.PlayerCardsHeld[i].Count > 0)
					{
						currentCards.Add(i, this.PlayerCardsHeld[i].Next());
					}
				}

				int roundWinner = -1;
				Card highCard = new Card();
				foreach (int j in currentCards.Keys)
				{
					Console.WriteLine("Player {0}: {1}", j, currentCards[j]);
					if (currentCards[j].CompareTo(highCard) > 0)
					{
						highCard = currentCards[j];
						roundWinner = j;
					}
				}

				Console.WriteLine("Winning Card: {0}", highCard.ToString());
				Console.WriteLine("Winner: {0}", roundWinner);

				done = true;
			}

			Console.WriteLine("Game is completed. Winner is player " + winner);
		}
	}
}
