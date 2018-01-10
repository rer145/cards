using System;
using System.Collections.Generic;

using Framework;

namespace Games
{
	public interface IGame
	{
		int Players { get; set; }
		Dictionary<int, List<Card>> PlayerCardsHeld { get; set; }
		Dictionary<int, List<Card>> PlayerCardsDown { get; set; }
		IDeck Deck { get; set; }

		void Deal();
	}
}
