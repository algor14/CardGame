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
        internal static int playerWins = 0;
        internal static int aiWins = 0;
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
        
    }
}
