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
		public List<Player> Players { get; set; }
		public IDeck Deck { get; set; }

		public War(int players)
		{
			this.Players = new List<Player>(players);
			this.Deck = new AceHighDeck();

			for (int i = 0; i < players; i++)
			{
				this.Players.Add(new Player());
			}
		}
		
		public void Deal()
		{
			while (this.Deck.Cards.Count > 0)
			{
				for (int j = 0; j < this.Players.Count; j++)
				{
					this.Players[j].Hand.Add(this.Deck.Cards.Next());
				}
			}
		}

		public void Play()
		{
			bool done = false;

			int winner = -1;
			Dictionary<int, Card> currentCards = new Dictionary<int, Card>();
			int roundWinner = -1;
			Card highCard = new Card();

			while (!done)
			{
				currentCards.Clear();
				
				//pull in cards for all available players
				for (int i = 0; i < this.Players.Count; i++)
				{
					//only if the player has cards left
					if (this.Players[i].Hand.Count > 0)
					{
						currentCards.Add(i, this.Players[i].Hand.Next());
					}
				}

				if (currentCards.Count > 0)
				{
					//roundWinner = currentCards.First().Key;
					//highCard = currentCards.First().Value;
					roundWinner = -1;
					highCard = new Card();

					//compare each card to find round winner
					//check for ties
					foreach (int j in currentCards.Keys)
					{
						Console.WriteLine("Player {0}: {1}", j, currentCards[j]);
						if (currentCards[j].CompareTo(highCard) > 0)
						{
							highCard = currentCards[j];
							roundWinner = j;
						}
						else if (currentCards[j].CompareTo(highCard) == 0)
						{
							//do nothing for now
							roundWinner = -1;
							//call Next for each player
							//call Next for each player again and compare those cards
							//continue until not equal
						}
					}

					//add cards to winner's hand
					if (roundWinner >= 0)
					{
						foreach (int j in currentCards.Keys)
						{
							this.Players[roundWinner].Hand.Add(currentCards[j]);
						}
					}
					else
					{
						foreach (int j in currentCards.Keys)
						{
							this.Players[j].Hand.Add(currentCards[j]);
						}
					}

					Console.WriteLine("Winning Card: {0}", highCard.ToString());
					Console.WriteLine("Winner: {0}", roundWinner);
					Console.WriteLine("Card Counts: ");
					for (int i = 0; i < this.Players.Count; i++)
					{
						Console.WriteLine("  Player {0}: {1}", i, this.Players[i].Hand.Count);

						if (this.Players[i].Hand.Count < 23)
						{
							done = true;
							break;
						}
					}
				}
				else
				{
					done = true;
				}



				//done = true;
			}

			Console.WriteLine("Game is completed. Winner is player " + winner);
		}
	}
}
