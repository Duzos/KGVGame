using FirstProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class GameRegister : Registry<Game>
    {
        protected override void Defaults()
        {
            Register(new NumberGuess());
            Register(new RockPaperScissors());
            Register(new BlackJack());
            Register(new TicTacToe());
            Register(new Connect());
        }

        // instance
        private static GameRegister INSTANCE;

        public static GameRegister instance()
        {
            if (INSTANCE == null) INSTANCE = new GameRegister();

            return INSTANCE;
        }
    }
}
