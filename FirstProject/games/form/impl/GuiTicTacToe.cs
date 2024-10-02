using FirstProject.games.impl.TTT;
using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Games.TicTacToe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FirstProject.games.form.impl
{
    public class GuiTicTacToe : FormGame
    {
        private readonly TTTGrid grid;
        private TTTForm parent;
        private Player current;

        public GuiTicTacToe() : base("ttt_form")
        {
            grid = new TTTGrid();

            current = Player.X;
        }

        protected override Form CreateForm()
        {
            parent = new TTTForm(this);
            return parent;
        }

        public override string Name()
        {
            return "Tic Tac Toe";
        }


        protected override void OnRestart()
        {
            grid.Fill();
            return;
        }

        private bool CheckForWin()
        {
            if (grid.IsFull())
            {
                return true;
            }

            Player winner = grid.GetWinner();
            if (winner == Player.EMPTY) return false;

            return true;
        }

        private void Next()
        {
            if (current == Player.X) current = Player.O;
            else current = Player.X;
        }
        private Player Current()
        {
            return current;
        }

        public void OnClick(TTTButton source)
        {
            if (CheckForWin())
            {
                OnWin();
                return;
            }

            int index = source.index;

            if (grid[index] != Player.EMPTY) return;

            grid[index] = Current();
            source.UpdateContent(Current());

            Next();

            if (CheckForWin())
            {
                OnWin();
                return;
            }
        }
        private void OnWin()
        {
            parent.Text = "WINN!!!";
        }
    }
}
