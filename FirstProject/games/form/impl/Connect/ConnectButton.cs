using Games;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Games.Connect;

namespace FirstProject.games.form.impl
{
    public class ConnectButton : Button
    {
        private readonly GuiConnect parent;
        public readonly int column;
        public readonly int row;
        public Player value;

        public ConnectButton(GuiConnect p, int c, int r) : base()
        {
            parent = p;

            column = c;
            row = r;

            UpdateContent(Player.EMPTY);

            Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            parent.OnClick(this);
        }

        public void UpdateContent(Player v)
        {
            value = v;

            Text = (v == Player.EMPTY) ? "" : "O";
            BackColor = v.GetDrawColor();
        }
    }
}
