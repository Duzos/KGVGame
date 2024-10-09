using Games;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Games.Connect;

namespace FirstProject.games.form.impl
{
    public class GuiConnect : FormGame
    {
        private ConnectForm parent;
        public CGrid grid;
        private int players;
        private Player current;

        public GuiConnect() : base("connect_form")
        {
        }

        protected override Form CreateForm()
        {
            parent = new ConnectForm(this);

            parent.OnTurn(current);

            return parent;
        }

        public override string Name()
        {
            return "Connect 4";
        }


        protected override void OnRestart()
        {
            current = Player.RED;
            players = QueryPlayers();

            grid = new CGrid(players);
            return;
        }
        private int QueryPlayers()
        {
            string response = "";

            Util.InputBox(this.Name(), "How many players? ( 2 -> 6 )", ref response);

            bool success = int.TryParse(response, out int result);

            if (!success || (result < 2) || result > 6) result = 2;

            return result;
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

        public void OnClick(ConnectButton source)
        {
            if (CheckForWin())
            {
                OnWin();
                return;
            }

            KeyValuePair<bool, int?> result = grid.Add(source.column, Player.EMPTY, true);

            if (!result.Key || result.Value == null) return;

            grid.Add(source.column, current, false);
            parent.GetButton(source.column, result.Value.Value).UpdateContent(current);

            Next();

            if (CheckForWin())
            {
                OnWin();
                return;
            }
        }
        private void OnWin()
        {
            parent.OnWin(grid.GetWinner(), grid.IsFull());
        }

        private void Next()
        {
            current = current.Next();

            if ((int)current > players || current == Player.EMPTY) 
            {
                current = Player.RED;
            }

            parent.OnTurn(current);
        }
        
        public int PlayerCount()
        {
            return players;
        }
    }
}
