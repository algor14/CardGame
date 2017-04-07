using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static Blackjack blackjackGame;
        static void Main(string[] args)
        {
            startBlackjack();
        }
        static void startBlackjack()
        {
            blackjackGame = new Blackjack();
            blackjackGame.StartGame();
        }
    }
}
