using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class CGrid
    {
        public readonly Connect.Player[,] map;

        public CGrid()
        {
            map = new Connect.Player[7, 6];
        }

        public void Clear()
        {
            for (int r = 0; r < GetRows(); r++)
            {
                for (int c = 0; c < GetColumns(); c++)
                {
                    map[c, r] = Connect.Player.EMPTY;
                }
            }
        }

        public int GetColumns()
        {
            return map.GetLength(0);
        }
        public int GetRows()
        {
            return map.GetLength(1);
        }

        public bool Add(int c, Connect.Player plr, bool simulate)
        {
            if (c < 0 || c > GetRows()) return false;
            if (IsFull()) return true;

            for (int i = GetRows() - 1; i > 0; i--)
            {
                if (map[c, i] == Connect.Player.EMPTY)
                {
                    if (!simulate)
                    {
                        map[c, i] = plr;
                    }
                    return true;
                }
            }

            return false;
        }

        public bool IsFull()
        {
            for (int c = 0; c < GetColumns(); c++)
            {
                for (int r = 0; r < GetRows(); r++)
                {
                    if (map[c, r] == Connect.Player.EMPTY) return false;
                }
            }

            return true;
        }

        public Connect.Player GetWinner()
        {
            Connect.Player plr;

            for (int r = GetRows() - 1; r > 0; r--)
            {
                for (int c = 0; c < GetColumns(); c++)
                {
                    plr = map[c, r];

                    // check horizontal
                    if (!(c >= GetColumns() - 4))
                    {
                        bool valid = true;
                        for (int i = 0; i < 4; i++)
                        {
                            valid = valid && (plr == map[c + i, r]);
                            if (!valid) break;
                        }

                        if (valid)
                        {
                            return plr;
                        }
                    }

                    // check vertical todo - this gets ran more times than necessary
                    if (!(r >= GetRows() - 4))
                    {
                        bool valid = true;
                        for (int i = 0; i < 4; i++)
                        {
                            valid = valid && (plr == map[c, r + i]);
                            if (!valid) break;
                        }

                        if (valid)
                        {
                            return plr;
                        }
                    }
                }
            }
            return Connect.Player.EMPTY;

        }

        public void Print()
        {
            Connect.Player plr;

            for (int r = 0; r < GetRows(); r++)
            {
                Console.Write("| ");

                for (int c = 0; c < GetColumns(); c++)
                { 
                    plr = map[c, r];
                    string repr = (plr != Connect.Player.EMPTY) ? "O" : " ";

                    if (r == 0 && plr == Connect.Player.EMPTY)
                    {
                        // first row, print numbers
                        repr = c.ToString();
                    }

                    plr.SetColor();
                    Console.Write(repr);
                    Console.ResetColor();
                    Console.Write(" | ");
                }

                Console.WriteLine();
            }
        }
    }
}
