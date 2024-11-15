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
            map = new SnakeButton[game.Cols, game.Rows];

            Shown += GenerateButtons;
            Paint += new PaintEventHandler(OnPaint);
            FormClosed += OnCloseForm;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            HandleKeyPress(keyData);

            return true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            scoreLabel.Text = "SCORE: " + game.Score;

            foreach (SnakeButton b in map)
            {
                if (b == null) continue;

                if (game.GameOver)
                {
                    b.BackColor = Color.DarkSlateGray;
                    continue;
                }

                if (game.Head().Row == b.Row && game.Head().Col == b.Col)
                {
                    b.BackColor = Color.LightGreen;
                    continue;
                }

                GridValue value = game.Grid[b.Row, b.Col];
                switch (value)
                {
                    case GridValue.SNAKE:
                        b.BackColor = Color.DarkGreen;
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
                    SnakeButton but = CreateButton(c, r, 1f - GetProgress(game.Cols, 10, 33));
                    Controls.Add(but);
                    map[c, r] = but;
                }
            }
        }

        public static float GetProgress(int i, int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min must be less than max.");
            }

            // Clamp i to the range [min, max]
            i = Math.Max(min, Math.Min(i, max));

            // Calculate progress as a percentage
            return (float)(i - min) / (max - min);
        }

        private SnakeButton CreateButton(int c, int r, float scale)
        {
            int size = (int)(32f * scale);
            size = (int)Math.Max(size, 10f);
            return new SnakeButton(c, r)
            {
                Size = new Size(size, size),
                Location = new Point(16 + size * (c), 16 + size * (r)),
                Font = new Font("Microsoft Sans Serif", 120 * scale)
            };
        }
        private void OnCloseForm(object sender, FormClosedEventArgs e)
        {
            game.ReturnToSelect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
