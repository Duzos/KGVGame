using FirstProject;
using System;

namespace Games
{
    public abstract class Game : Identifiable
    {
        protected readonly string identifier;

        protected Game(string id)
        {
            this.identifier = id;
        }


        public virtual void StartLoop()
        {
            this.OnRestart();

            bool isPlaying = true;

            while (isPlaying)
            {
                bool finished = this.Run();
                if (!finished) continue;

                Console.Write("Would you like to play again? ");
                isPlaying = Util.ReadBoolean();

                if (isPlaying)
                {
                    this.OnRestart();
                }
            }

            Console.WriteLine("Bye bye!");
        }
        protected abstract bool Run();
        protected abstract void OnRestart();

        public string id()
        {
            return this.identifier;
        }
    
        public virtual string Name()
        {
            return id();
        }
    }
}
