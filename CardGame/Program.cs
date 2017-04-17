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
        }
        public static void AIWin()
        {
            aiWins++;
        }
        public static void PlayerWin()
        {
            playerWins++;
        }
        public static void ShowTotalScores()
        {
            Console.WriteLine($"Total score: Player - {Program.playerWins}; AI - {Program.aiWins}");

        }
    }
}
