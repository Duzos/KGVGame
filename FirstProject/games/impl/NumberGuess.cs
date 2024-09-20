using FirstProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class NumberGuess : Game
    {
        private readonly Random random;
        private int target;

        public NumberGuess() : base("number_guess")
        {
            this.random = new Random();
            this.RerollTarget();
        }

        protected override bool Run()
        {
            Console.WriteLine("Make a guess! ( 0-10 )");
            int guess = Util.ReadInteger();

            if (guess != target)
            {
                Console.WriteLine("Nope.");

                bool higher = target < guess;
                string message = "Your guess is " + ((higher) ? "higher" : "lower") + " than the target";
                Console.WriteLine(message);

                return false;
            }

            Console.WriteLine("You WIN! The number was " + target);

            return true;
        }

        private void RerollTarget(int min, int max)
        {
            this.target = random.Next(min, max + 1);
        }
        private void RerollTarget()
        {
            RerollTarget(0, 10);
        }

        protected override void OnRestart()
        {
            this.RerollTarget();
        }
    }

}
