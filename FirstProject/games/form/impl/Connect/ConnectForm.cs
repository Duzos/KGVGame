using Games;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Games.Connect;

namespace FirstProject.games.form.impl
{
    public partial class ConnectForm : Form
    {
        private readonly GuiConnect game;
        private readonly ConnectButton[,] map;

        public ConnectForm(GuiConnect g)
        {
            InitializeComponent();

            game = g;
            map = new ConnectButton[g.grid.GetColumns(), g.grid.GetRows()];

            Shown += GenerateButtons;
            FormClosed += OnCloseForm;
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {

        }

        public ConnectButton GetButton(int c, int r)
        {
            return map[c, r];
        }

        private void GenerateButtons(object sender, EventArgs e)
        {
            for (int r = game.grid.GetRows() - 1; r > 0; r--)
            {
                for (int c = 0; c < game.grid.GetColumns(); c++)
                {
                    ConnectButton but = CreateButton(c, r, 1 - ((game.PlayerCount() - 1) / 6f));

                    map[c, r] = but;
                    Controls.Add(but);
                }
            }
        }

        private ConnectButton CreateButton(int c, int r, float scale)
        {
            int size = (int)(153.6f * scale);
            return new ConnectButton(game, c, r)
            {
                Size = new Size(size, size),
                Location = new Point(size * (c), size * (r)),
                Font = new Font("Microsoft Sans Serif", 120 * scale)
            };
        }

        public void OnTurn(Player player)
        {
            if (player == Player.EMPTY) return;

            mainlabel.Text = player.ToString() + " Turn";
        }
        public void OnWin(Player player, bool isDraw)
        {
            if (isDraw)
            {
                mainlabel.Text = "DRAW";
                return; 
            }

            mainlabel.Text = player.ToString() + " WINS!!";
        }
        private void OnCloseForm(object sender, FormClosedEventArgs e)
        {
            game.ReturnToSelect();
        }
    }
}
