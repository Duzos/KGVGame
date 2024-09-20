using FirstProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class RockPaperScissors : Game 
    {
        private readonly Random random;
        private Choices chosen;


        public RockPaperScissors() : base("rps")
        {
            this.random = new Random();
            this.RerollChosen();
        }

        protected override void OnRestart()
        {
            this.RerollChosen();
        }

        protected override bool Run()
        {
            Console.WriteLine("Pick an option!");
            Choices player = ChoicesExtension.ParseChoice(Util.ReadString((input) =>
            {
                return ChoicesExtension.ParseChoice(input) != Choices.INVALID;
            }));

            Result result = player.ResultFor(this.chosen);

            Console.WriteLine("It was a " + result.ToString());
            Console.WriteLine();

            return true;
        }

        private void RerollChosen()
        {
            int i = this.random.Next(3) + 1;
            this.chosen = (Choices)i;
        }
        public enum Choices
        {
            INVALID,
            ROCK,
            PAPER,
            SCISSORS
        }
        public enum Result
        {
            WIN,
            DRAW,
            LOSE
        }
    }
}
