using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Games.TicTacToe;

namespace Games
{
    public static class TTTPlayerExtension
    {
        public static void SetColor(this Player player)
        {
            Console.ForegroundColor = GetColor(player);
        }
        public static ConsoleColor GetColor(this Player player)
        {
            switch (player)
            {
                case Player.X: return ConsoleColor.Red;
                case Player.O: return ConsoleColor.Blue;
                default: return ConsoleColor.White;
            }
        }
    }
}
