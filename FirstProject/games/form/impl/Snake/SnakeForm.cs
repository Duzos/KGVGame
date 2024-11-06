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

namespace FirstProject.games.form.impl.Snake
{
    public partial class SnakeForm : Form
    {
        private readonly Snake game;
        private readonly SnakeButton[,] map;


        public SnakeForm(Snake game)
        {
            InitializeComponent();
            this.game = game;

            Shown += GenerateButtons;
            Paint += new PaintEventHandler(OnPaint);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            HandleKeyPress(keyData);

            return true;
        }
        
        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (SnakeButton b in map)
            {
                GridValue value = game.Grid[b.Col, b.Row];
                switch (value)
                {
                    case GridValue.SNAKE:
                        b.BackColor = Color.Green;
                        break;
                    case GridValue.FOOD:
                        b.BackColor = Color.Red;
                        break;
                    case GridValue.EMPTY:
                        b.BackColor = Color.White;
                        break;
                    case GridValue.OUTSIDE:
                        b.BackColor = Color.Black;
                        break;
                }
            }
        }

        private void HandleKeyPress(Keys data)
        {
            switch (data)
            {
                case Keys.Left:
                    game.ChangeDirection(Direction.LEFT);
                    break;
                case Keys.Right:
                    game.ChangeDirection(Direction.RIGHT);
                    break;
                case Keys.Up:
                    game.ChangeDirection(Direction.UP);
                    break;
                case Keys.Down:
                    game.ChangeDirection(Direction.DOWN);
                    break;
            }

        }

        private void GenerateButtons(object sender, EventArgs e)
        {
            for (int r = game.Rows - 1; r > 0; r--)
            {
                for (int c = 0; c < game.Cols; c++)
                {
                    SnakeButton but = CreateButton(c, r, 1);
                    Controls.Add(but);
                    map[c, r] = but;
                }
            }
        }

        private SnakeButton CreateButton(int c, int r, float scale)
        {
            int size = (int)(153.6f * scale);
            return new SnakeButton(c, r)
            {
                Size = new Size(size, size),
                Location = new Point(size * (c), size * (r)),
                Font = new Font("Microsoft Sans Serif", 120 * scale)
            };
        }
    }
}
