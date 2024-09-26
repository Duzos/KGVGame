using FirstProject;
using FirstProject.games.impl.Blackjack;
using FirstProject.games.impl.Blackjack.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class BlackJack : Game
    {
        private readonly Deck deck;
        private readonly Hand player;
        private readonly Hand dealer;
        private readonly DealerAI ai;

        public BlackJack() : base("blackjack")
        {
            deck = new Deck();
            player = new Hand();
            dealer = new Hand();
            ai = new DealerAI();
        }

        protected override void OnRestart()
        { 
            deck.Fill();

            player.Clear();
            dealer.Clear();
            
            player.Add(deck.Random(true));
            dealer.Add(deck.Random(true));
        }

        protected override bool Run()
        {
            Choice playerChoice = PlayerTurn();
            if (player.IsBust())
            {
                Console.WriteLine("You went bust.");
                WriteHands();
                return true;
            }

            Choice dealerChoice = DealerTurn();
            if (dealer.IsBust())
            {
                Console.WriteLine("You won!");
                WriteHands();
                return true;
            }

            if (dealerChoice == Choice.STAND && dealerChoice == playerChoice)
            {
                if (player.Total() >= dealer.Total())
                {
                    Console.WriteLine("You won!");
                    WriteHands();
                    return true;
                }

                Console.WriteLine("You lost.");
                WriteHands();
                return true;
            }

            return false;
        }

        private Choice PlayerTurn()
        {
            Util.Write(player);
            Console.WriteLine("total: " + player.Total());

            Choice choice = ParseChoice(Util.ReadString(new List<string>() { "stand", "hit" }, true));

            if (choice == Choice.STAND) return choice;

            // must be hit
            player.Add(deck.Random(true));
            return choice;
        }

        private Choice DealerTurn()
        {
            Choice choice = ai.CalculateChoice(dealer);

            Console.WriteLine("Dealer: " + choice.ToString());
            Console.WriteLine();

            if (choice == Choice.STAND) return choice;

            // must be hit
            dealer.Add(deck.Random(true));
            return choice;
        }
        private void WriteHands()
        {
            Console.Write("You had: ");
            Util.Write(player);
            Console.WriteLine("total: " + player.Total());

            Console.WriteLine();

            Console.Write("Dealer had: ");
            Util.Write(dealer);
            Console.WriteLine("total: " + dealer.Total());

            Console.WriteLine();
        }

        public enum Choice
        {
            HIT,
            STAND
        }

        private static Choice ParseChoice(string input)
        {
            input = input.ToLower();

            if (input == "stand") return Choice.STAND;
            if (input == "hit") return Choice.HIT;

            throw new Exception();
        }
    }
}
