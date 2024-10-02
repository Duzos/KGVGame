using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject.games.form.impl
{
    public partial class TTTForm : Form
    {
        private readonly GuiTicTacToe game;

        public TTTForm(GuiTicTacToe g)
        {
            InitializeComponent();

            game = g;
            Shown += GenerateButtons;
        }

        private void TTTForm_Load(object sender, EventArgs e)
        {

        }

        private void GenerateButtons(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Controls.Add(CreateButton(i));
            }
        }

        private TTTButton CreateButton(int index)
        {
            return new TTTButton(game, index)
            {
                Size = new Size(128, 128),
                Location = new Point(128 * (index % 3), 128 * (index / 3)),
                Font = new Font("Microsoft Sans Serif", 100)
            };
        }
    }
}
