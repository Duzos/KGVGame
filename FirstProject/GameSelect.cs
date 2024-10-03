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

namespace FirstProject
{
    public partial class GameSelect : Form
    {
        public GameSelect()
        {
            InitializeComponent();

            Shown += PopulateWithGames;
        }

        private void GameSelect_Load(object sender, EventArgs e)
        {
        }

        private void PopulateWithGames(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Game i in GameRegister.Instance().lookup.Values)
            {
                if (!(i is FormGame)) continue;

                Controls.Add(CreateButton((FormGame) i, count));
                count++;
            }
        }
        private Button CreateButton(FormGame game, int count)
        {
            FormButton created = new FormButton(game)
            {
                Size = new Size(128, 128),
                Location = new Point(128 * count, 0)
            };

            return created;
        }
    }
}
