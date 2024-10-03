using FirstProject;
using System;

namespace Games
{
    public class Connect : Game
    {
        private CGrid grid;
        private int players;

        public Connect() : base("connect")
        {
            players = 2;
        }

        protected override void OnRestart()
        {
            Console.WriteLine("How many players (2 -> 6)");
            players = Util.ReadInteger((input) =>
            {
                return input > 1 || input < 6;
            });

            grid = new CGrid(players);
        }

        protected override bool Run()
        {

            int count = 1;
            foreach (Player plr in Enum.GetValues(typeof(Player))) {
                if (plr == Player.EMPTY) continue;
                if (count > players) break;
                count++;

                Turn(plr);

                if (CheckForWin()) return true;
            }

            return false;
        }

        private int QueryPosition()
        {
            return Util.ReadInteger((input) =>
            {
                return grid.Add(input, Player.EMPTY, true).Key;
            });
        }
        private void Turn(Player player)
        {
            Console.Write("(");
            player.SetColor();
            Console.Write(player);

            Console.ResetColor();
            Console.Write(") Type a column");
            Console.WriteLine();

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
            BLUE,
            GREEN,
            YELLOW,
            MAGENTA,
            CYAN
        }
    }
}