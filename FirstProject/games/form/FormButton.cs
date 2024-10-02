using System;
using System.Windows.Forms;

namespace Games
{
    public class FormButton : Button
    {
        private readonly FormGame game;

        public FormButton(FormGame game) : base()
        {
            this.game = game;

            Text = game.Name();

            Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            game.StartLoop();
        }
    }
}
