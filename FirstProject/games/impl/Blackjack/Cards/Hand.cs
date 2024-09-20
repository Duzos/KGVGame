using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.games.impl.Blackjack.Cards
{
    public class Hand : List<Card>
    {
        public int Total()
        {
            int total = 0;

            foreach (Card i in this)
            {
                total += i;
            }

            return total;
        }

        public bool IsBust()
        {
            return Total() > 21;
        }
    }
}
