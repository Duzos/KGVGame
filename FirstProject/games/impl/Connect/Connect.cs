using FirstProject;
using FirstProject.games.impl.TTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class Connect : Game
    {
        private readonly CGrid grid;
        private readonly Player first;
        private readonly Player second;

        public Connect() : base("connect")
        {
            grid = new CGrid();

            first = Player.RED;
            second = Player.BLUE;
        }

        protected override void OnRestart()
        {
            grid.Clear();
        }

        protected override bool Run()
        {
            Turn(first);

            if (CheckForWin()) return true;

            Turn(second);

            if (CheckForWin()) return true;

            return false;
        }

        private int QueryPosition()
        {
            return Util.ReadInteger((input) =>
            {
                return grid.Add(input, Player.EMPTY, true);
            });
        }
        private void Turn(Player player)
        {
            Console.WriteLine();
            grid.Print();
            Console.WriteLine();

            Console.WriteLine("({0}) Type a column", player);
            int pos = QueryPosition();
            grid.Add(pos, player, false);
        }
        private bool CheckForWin()
        {
            Console.WriteLine();
            grid.Print();
            Console.WriteLine();

            if (grid.IsFull())
            {
                Console.WriteLine("Draw");
                return true;
            }

            Player winner = grid.GetWinner();
            if (winner == Player.EMPTY) return false;

            winner.SetColor();
            Console.Write(winner);

            Console.ResetColor();
            Console.Write(" WINS!");

            Console.WriteLine();

            return true;
        }

        public enum Player
        {
            EMPTY,
            RED,
            BLUE
        }
    }
}