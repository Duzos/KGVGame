using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Games.Connect;


namespace Games
{
    public static class CPlayerExtension
    {
        public static void SetColor(this Player player)
        {
            Console.ForegroundColor = GetConsoleColour(player);
        }
        public static ConsoleColor GetConsoleColour(this Player player)
        {
            switch (player)
            {
                case Player.RED: return ConsoleColor.Red;
                case Player.BLUE: return ConsoleColor.Blue;
                case Player.GREEN: return ConsoleColor.Green;
                case Player.YELLOW: return ConsoleColor.Yellow;
                case Player.MAGENTA: return ConsoleColor.Magenta;
                case Player.CYAN: return ConsoleColor.Cyan;
                default: return ConsoleColor.White;
            }
        }

        public static Color GetDrawColor(this Player player)
        {
            switch (player)
            {
                case Player.RED: return Color.PaleVioletRed;
                case Player.BLUE: return Color.CornflowerBlue;
                case Player.GREEN: return Color.LightSeaGreen;
                case Player.CYAN: return Color.LightCyan;
                case Player.YELLOW: return Color.LightGoldenrodYellow;
                case Player.MAGENTA: return Color.Magenta;
                default: return Color.White;
            }
        }
    }
}
