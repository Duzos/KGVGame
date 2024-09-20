using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Games.RockPaperScissors;

namespace Games
{
    public static class ChoicesExtension
    {
        public static Result ResultFor(this Choices choice, Choices target)
        {
            if (choice == Choices.INVALID || target == Choices.INVALID) return Result.DRAW;

            // ow, this is bad.

            switch (choice)
            {
                case Choices.ROCK:
                    switch (target)
                    {
                        case Choices.ROCK:
                            return Result.DRAW;
                        case Choices.PAPER:
                            return Result.LOSE;
                        case Choices.SCISSORS:
                            return Result.WIN;
                    }
                    break;

                case Choices.PAPER:
                    switch (target)
                    {
                        case Choices.ROCK:
                            return Result.WIN;
                        case Choices.PAPER:
                            return Result.DRAW;
                        case Choices.SCISSORS:
                            return Result.LOSE;
                    }
                    break;

                case Choices.SCISSORS:
                    switch (target)
                    {
                        case Choices.ROCK:
                            return Result.LOSE;
                        case Choices.PAPER:
                            return Result.WIN;
                        case Choices.SCISSORS:
                            return Result.DRAW;
                    }
                    break;
            }


            return Result.DRAW;
        }

        public static Choices ParseChoice(string input)
        {
            input = input.ToUpper();

            foreach (Choices choice in Enum.GetValues(typeof(Choices)))
            {
                if (choice == Choices.INVALID) continue;

                string name = Enum.GetName(typeof(Choices), choice);
                if (name == input) return choice; // "ROCK" == "ROCK"

                if (!(input.Length == 1)) continue;
                if (name[0] == input[0]) return choice; // "R" == "R"
            }

            return Choices.INVALID;
        }
    }
}
