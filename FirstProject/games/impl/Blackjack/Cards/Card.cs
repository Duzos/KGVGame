using FirstProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Games
{
    public class Card : Identifiable
    {
        private readonly int value;
        private readonly string name; 

        public Card(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        public Card(int value) : this(value, value.ToString())
        {
            
        }

        public static implicit operator int (Card i)
        {
            return i.value;
        }

        public string id()
        {
            return name;
        }

        public override string ToString()
        {
            if (name != value.ToString())
            {
                return $"{name} ({value})";
            }

            return name;
        }

        public class Registry : Registry<Card>
        {
            protected override void Defaults()
            {

                Register(new Card(1, "ace"));
                Register(new Card(2));
                Register(new Card(3));
                Register(new Card(4));
                Register(new Card(5));
                Register(new Card(6));
                Register(new Card(7));
                Register(new Card(8));
                Register(new Card(9));
                Register(new Card(10, "joker"));
                Register(new Card(10, "queen"));
                Register(new Card(10, "king"));
            }

            // instance
            private static Registry INSTANCE;

            public static Registry Instance()
            {
                if (INSTANCE == null) INSTANCE = new Registry();

                return INSTANCE;
            }
        }
    }
}
