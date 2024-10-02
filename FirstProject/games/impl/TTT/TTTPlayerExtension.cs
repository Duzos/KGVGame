using System;
using System.Collections.Generic;
using System.Drawing;
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
            Console.ForegroundColor = GetConsoleColor(player);
        }
        public static ConsoleColor GetConsoleColor(this Player player)
        {
            switch (player)
            {
                case Player.X: return ConsoleColor.Red;
                case Player.O: return ConsoleColor.Blue;
                default: return ConsoleColor.White;
            }
        }
        public static Color GetDrawColor(this Player player)
        {
            switch (player)
            {
                case Player.X: return Color.PaleVioletRed;
                case Player.O: return Color.LightCyan;
                default: return Color.White;
            }
        }
    }
}
