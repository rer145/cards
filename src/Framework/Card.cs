using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Card
    {
        public int Value { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }

        public Suit Suit { get; set; }

		public override string ToString()
		{
			return this.ShortText.ToString() + this.Suit.ToString();
		}

		public int CompareTo(object obj)
		{
			Card card2 = (Card)obj;
			return this.Value.CompareTo(card2.Value);
		}
	}
}
