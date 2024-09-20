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

namespace FirstProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // todo - allow reselection post-play

            Game chosen = Util.QueryForGame();

            chosen.StartLoop();

            Console.ReadLine();
        }
    }
}
