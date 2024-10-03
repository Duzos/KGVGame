using Games;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows.Forms;

namespace FirstProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play GUI games?");
            bool gui = Util.ReadBoolean();

            if (gui) { 
                Application.Run(new GameSelect());
                return;
            }

            Game chosen = Util.QueryForGame();

            chosen.StartLoop();

            Console.ReadLine();
        }
    }
}
