using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class AceLowDeck : Deck
    {
        public AceLowDeck()
		{
			List<Suit> suits = new List<Suit>();
			suits.Add(new Framework.Suit { Color = "Red", LongText = "Hearts", ShortText = "H" });
			suits.Add(new Framework.Suit { Color = "Red", LongText = "Diamonds", ShortText = "D" });
			suits.Add(new Framework.Suit { Color = "Black", LongText = "Clubs", ShortText = "C" });
			suits.Add(new Framework.Suit { Color = "Black", LongText = "Spades", ShortText = "S" });

			this.Cards = new List<Card>();
			for (int i = 1; i < 14; i++)
			{
				for (int j = 0; j < suits.Count; j++)
				{
					if (i == 1)
					{
						this.Cards.Add(new Framework.Card { Value = i, LongText = "Ace", ShortText = "A", Suit = suits[j] });
					}
					else if (i == 11)
					{
						this.Cards.Add(new Framework.Card { Value = i, LongText = "Jack", ShortText = "J", Suit = suits[j] });
					}
					else if (i == 12)
					{
						this.Cards.Add(new Framework.Card { Value = i, LongText = "Queen", ShortText = "Q", Suit = suits[j] });
					}
					else if (i == 13)
					{
						this.Cards.Add(new Framework.Card { Value = i, LongText = "King", ShortText = "K", Suit = suits[j] });
					}
					else
					{
						this.Cards.Add(new Framework.Card { Value = i, LongText = i.ToString(), ShortText = i.ToString(), Suit = suits[j] });
					}
				}
			}
		}
    }
}
