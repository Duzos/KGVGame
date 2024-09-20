using FirstProject.games.impl.Blackjack.Cards;
using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.games.impl.Blackjack
{
    public class DealerAI
    {
        private readonly Random random;

        public DealerAI()
        {
            random = new Random();
        }

        public BlackJack.Choice CalculateChoice(Hand hand)
        {
            int total = hand.Total();

            float chance = ((1f - (total / 21)) * 100f) - 10;
            int i = random.Next(101);

            if (chance > i)
            {
                return BlackJack.Choice.HIT;
            }

            return BlackJack.Choice.STAND;
        }
    }
}
