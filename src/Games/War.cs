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

		public Dictionary<int, List<Card>> PlayerCardsDown { get; set; }

		public Dictionary<int, List<Card>> PlayerCardsHeld { get; set; }

		public int Players { get; set; }

		public IDeck Deck { get; set; }

		public void Deal()
		{
			while (this.Deck.Cards.Count > 0)
			{
				for (int j = 0; j < this.Players; j++)
				{
					this.PlayerCardsHeld[j].Add(this.Deck.Cards[0]);
					this.Deck.Cards.RemoveAt(0);
				}
			}
		}
	}
}
