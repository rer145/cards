using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Framework
{
    public abstract class Deck : IDeck
    {
        public List<Card> Cards { get; set; }

		public Deck()
		{
			this.Cards = new List<Card>();
		}

		public void Shuffle()
		{
			this.Cards.Shuffle();
		}

		public Card Next()
		{
			return this.Cards.Next();
		}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();

			for (int i = 0; i < this.Cards.Count; i++)
			{
				output.AppendFormat("[{0}]: {1}    ", i.ToString(), this.Cards[i].ToString());
			}

			return output.ToString();
		}
	}
}
