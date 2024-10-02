using Games;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Games.TicTacToe;

namespace FirstProject.games.form.impl
{
    public class TTTButton : Button
    {
        private readonly GuiTicTacToe parent;
        public readonly int index;
        public Player value;

        public TTTButton(GuiTicTacToe p, int i) : base()
        {
            parent = p;
            index = i;

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

            Text = (v == Player.EMPTY) ? "" : v.ToString();
            BackColor = v.GetDrawColor();
        }
    }
}
