using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        private static Blackjack blackjackGame;
        private static int playerWins = 0;
        private static int aiWins = 0;

        static void Main(string[] args)
        {
            StartBlackjack();
        }

        public static void StartBlackjack()
        {
            Console.WriteLine("");
            Console.WriteLine("                --- New Blackjack has started ---");
            Console.WriteLine("");
            blackjackGame = new Blackjack();
            ShowTotalScores(blackjackGame.Init());
        }

        public static void ShowTotalScores(int winner)
        {
            if (winner == 1)
            {
                playerWins++;
            }
            else if(winner == 2)
            {
                aiWins++;
            }
            Console.WriteLine($"Total score: Player - {Program.playerWins}; AI - {Program.aiWins}");
            Console.WriteLine("Play one more game? (Type \"y\" if yes)");
            string printed = Console.ReadLine();
            if (printed == "y" || printed == "yes")
            {
                StartBlackjack();
            }
        }
    }
}
