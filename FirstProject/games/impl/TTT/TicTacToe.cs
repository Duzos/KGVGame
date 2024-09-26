using FirstProject;
using FirstProject.games.impl.TTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class TicTacToe : Game
    {
        private readonly TTTGrid grid;
        private readonly Player first;
        private readonly Player second;

        public TicTacToe() : base("ttt")
        {
            grid = new TTTGrid();

            first = Player.X;
            second = Player.O;
        }

        protected override void OnRestart()
        {
            grid.Fill();
            return;
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
                return grid.IsEmpty(input);
            });
        }
        private void Turn(Player player)
        {
            Console.WriteLine();
            grid.Print();
            Console.WriteLine();

            Console.WriteLine("({0}) Type a number from the grid", player);
            int pos = QueryPosition();
            grid[pos] = player;
        }
        private bool CheckForWin()
        {
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
            X,
            O,
            EMPTY
        }
    }

}
