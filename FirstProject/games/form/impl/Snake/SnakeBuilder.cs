using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject.games.form.impl.Snake
{
    public class SnakeBuilder : FormGame
    {
        public SnakeBuilder() : base("snake")
        {
        }

        public override void StartLoop()
        {
            OnRestart();
        }
        
        protected override Form CreateForm()
        {
            return null;
        }

        protected override void OnRestart()
        {
            int size = Snake.QuerySize(this, 10, 32);
            Snake game = new Snake(size, size);
            game.StartLoop();
        }

        protected override bool Run()
        {
            return true;
        }
        public override string Name()
        {
            return "Snake";
        }
    }
}
