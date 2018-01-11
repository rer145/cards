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
			bool isGameOver = false;
			
			List<Card> cardsInPlay = new List<Card>();
			List<Player> playersInPlay = new List<Player>();

			int rounds = 0;
			
			while (!isGameOver)
			{
				if (rounds > 10)
				{
					isGameOver = true;
				}
				else
				{
					cardsInPlay.Clear();
					playersInPlay.Clear();

					//pull in cards for all available players
					foreach (Player player in this.Players)
					{
						//only if the player has cards left
						if (player.Hand.Count > 0)
						{
							//currentCards.Add(i, this.Players[i].Hand.Next());
							cardsInPlay.Add(player.Hand.Next());
							playersInPlay.Add(player);
						}
					}

					if (cardsInPlay.Count > 1)
					{
						WarRoundResult result = new WarRoundResult(playersInPlay, cardsInPlay);
						if (result.IsWar)
						{
							Console.WriteLine("WAR");
						}
						else
						{
							//give winning player all the cards in play
							foreach (Card card in cardsInPlay)
							{
								this.Players.Where(x => x.Id == result.WinningPlayer.Id).FirstOrDefault().Hand.Add(card);
							}
						}
					}
					else
					{
						isGameOver = true;
					}
					rounds++;
				}
			}

			Console.WriteLine("Game is completed. Winner is your mom");
		}
	}

	public class WarRoundResult
	{
		public bool IsWar { get; set; }
		public List<Card> Cards { get; set; }
		public List<Player> Players { get; set; }
		public Player WinningPlayer { get; set; }
		public Card WinningCard { get; set; }
		public List<Player> WarPlayers { get; set; }
		public List<Card> WarCards { get; set; }

		public WarRoundResult(List<Player> players, List<Card> cards)
		{
			this.Players = players;
			this.Cards = cards;

			this.IsWar = false;
			this.WinningCard = null;
			this.WinningPlayer = null;
			this.WarCards = new List<Card>();
			this.WarPlayers = new List<Player>();

			this.GetResult();
		}

		public void GetResult()
		{
			this.Cards.Sort();

			Card highCard = this.Cards.Next();
			Card tempCard = this.Cards.Next();
			while (highCard.Value == tempCard.Value)
			{
				this.WarCards.Add(tempCard);
			}

			if (this.WarCards.Count > 0)
			{
				this.WarCards.Add(highCard);
				this.IsWar = true;
			}
			else
			{
				this.IsWar = false;
				this.WinningCard = highCard;
				foreach (Player player in this.Players)
				{
					if (player.Hand.Contains(highCard))
					{
						this.WinningPlayer = player;
					}
				}
			}

			if (this.IsWar)
			{
				//get players involved in war
				foreach (Player player in this.Players)
				{
					foreach (Card card in this.WarCards)
					{
						if (player.Hand.Contains(card))
						{
							this.WarPlayers.Add(player);
						}
					}
				}
			}
		}
	}
}
