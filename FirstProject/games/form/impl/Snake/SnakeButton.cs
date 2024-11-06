using System;
using System.Windows.Forms;

namespace Games
{
    public class SnakeButton : Button
    {
        public readonly int Col;
        public readonly int Row;

        public SnakeButton(int c, int r) : base()
        {
            Col = c;
            Row = r;
        }
    }
}
