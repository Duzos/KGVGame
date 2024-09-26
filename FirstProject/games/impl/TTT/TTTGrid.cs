using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.games.impl.TTT
{
    public class TTTGrid : List<TicTacToe.Player>
    {
        private readonly int max;

        private TTTGrid(int max) : base()
        {
            this.max = max;
            Fill();
        }
        public TTTGrid() : this(9)
        {

        }

        private void Fill(TicTacToe.Player var)
        {
            Clear();

            for (int i = 0; i < max; i++)
            {
                Add(var);
            }

            if (VerifyCapacity()) return;
            throw new Exception();
        }
        public void Fill()
        {
            Fill(TicTacToe.Player.EMPTY);
        }

        private bool VerifyCapacity()
        {
            return Count <= max;
        }
        public bool IsFull()
        {
            int count = 0;

            for (int i = 0; i < max; i++)
            {
                if (this[i] != TicTacToe.Player.EMPTY) count++;
            }

            return count == max;
        }
        public bool IsEmpty(int i)
        {
            if (i > Count) return false;

            return this[i] == TicTacToe.Player.EMPTY;
        }
        public TicTacToe.Player GetWinner()
        {
            // todo - optimise

            for (int i = 0; i < max; i++)
            {
                if (this[i] == TicTacToe.Player.EMPTY) continue;

                if (i < 3) // check columns
                {
                    if (this[i] == this[i + 3] && this[i] == this[i + 6]) return this[i];

                }

                if (i % 3 == 0) // check row
                {
                    if (this[i] == this[i + 1] && this[i] == this[i + 2]) return this[i];
                }

                if (i == 4) // middle, check diagonals
                {
                    if (this[i] == this[i - 2] && this[i] == this[i + 2]) return this[i];
                    if (this[i] == this[i - 4] && this[i] == this[i + 4]) return this[i];
                }
            }

            return TicTacToe.Player.EMPTY;
        }

        public void Print()
        {
            for (int i = 0; i < max; i++)
            {
                if (i % 3 == 0)
                {
                    // new line
                    if (i != 0)
                        Console.WriteLine();

                    Console.Write("| ");
                }

                TicTacToe.Player p = this[i];
                p.SetColor();
                Console.Write((p != TicTacToe.Player.EMPTY ? p.ToString() : i.ToString()));
                Console.ResetColor();
                Console.Write(" | ");
            }
        }
    }
}
