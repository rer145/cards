using System;
using System.Collections.Generic;

namespace Framework
{
    public interface IDeck
    {
        List<Card> Cards { get; set; }

		void Shuffle();
    }
}
