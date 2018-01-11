using System;
using System.Collections.Generic;

using Framework;

namespace Games
{
	public interface IGame
	{
		List<Player> Players { get; set; }
		IDeck Deck { get; set; }

		void Deal();
		void Play();
	}
}
