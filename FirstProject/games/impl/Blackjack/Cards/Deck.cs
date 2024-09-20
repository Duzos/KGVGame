using Games;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.games.impl.Blackjack.Cards
{
    public class Deck : List<Card>
    {
        private Random random;

        public void Fill()
        {
            Clear();

            foreach(Card i in Card.Registry.Instance().lookup.Values) {
                Add(i);
                Add(i);
                Add(i);
                Add(i);
            }
        }

        public Card Random(bool pop)
        {
            if (random == null) random = new Random();

            int index = random.Next(this.Count + 1);

            if (index > Count)
            {
                Console.WriteLine($"Index {index} is out of bounds for {Count}");
                return Random(pop);
            }

            Card card = this[index]; // todo - every once in a while this crashes

            if (pop)
            {
                this.RemoveAt(index);
            }

            return card;
        }
    }
}
