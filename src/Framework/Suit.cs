using System;

namespace Framework
{
    public class Suit
    {
		public string LongText { get; set; }
		public string ShortText { get; set; }
		public string Color { get; set; }

		public override string ToString()
		{
			return this.ShortText;
		}
	}
}
