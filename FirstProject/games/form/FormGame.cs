using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public abstract class FormGame : Game
    {
        protected FormGame(string id) : base(id)
        {
        }

        protected abstract Form CreateForm();
        
        public override void StartLoop()
        {
            Form.ActiveForm.Hide();
            CreateForm().Show();
        }

        protected override bool Run()
        {
            return false;
        }
        protected override void OnRestart()
        {
            
        }
    }
}
