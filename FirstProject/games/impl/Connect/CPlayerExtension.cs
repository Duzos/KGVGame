﻿using System;
using System.Collections.Generic;
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
            Console.ForegroundColor = GetColor(player);
        }
        public static ConsoleColor GetColor(this Player player)
        {
            switch (player)
            {
                case Player.RED: return ConsoleColor.Red;
                case Player.BLUE: return ConsoleColor.Blue;
                default: return ConsoleColor.White;
            }
        }
    }
}