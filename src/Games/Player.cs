using System;

using Framework;
using System.Collections.Generic;

namespace Games
{
	public class Player
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Card> Hand { get; set; }
		public List<Card> Played { get; set; }

		public Player()
		{
			this.Id = new Random().Next();
			this.Name = "Player " + this.Id.ToString();
			this.Hand = new List<Card>();
			this.Played = new List<Card>();
		}
	}
}
