using FirstProject;
using FirstProject.games.form.impl;
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

            Register(new GuiTicTacToe());
            Register(new GuiConnect());
        }

        // instance
        private static GameRegister INSTANCE;

        public static GameRegister Instance()
        {
            if (INSTANCE == null) INSTANCE = new GameRegister();

            return INSTANCE;
        }
    }
}
