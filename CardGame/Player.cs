using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    class Player : IPlayer
    {


        private List<Card> playerCards;
        private string _name = "Unnamed user";


        public Player()
        {
            playerCards = new List<Card>();
        }

        public Player(string name)
            :this()
        {
            _name = name;
        }

        public int Points
        {
            get
            {
                int total = 0;
                for (int i = 0; i < playerCards.Count; i++)
                {
                    total += (int)playerCards[i].Rank;
                }
                return total;
            }
        }

        public void AddCard(Card card)
        {
            playerCards.Add(card);
        }

        public void ShowAllCards()
        {
            Console.WriteLine($"================Your cards====================");
            for (int i = 0; i < playerCards.Count; i++)
            {
                Console.Write($"{playerCards[i].Suit}-{playerCards[i].Rank}-{(int)playerCards[i].Rank}; ");
            }
            Console.WriteLine("");
            Console.WriteLine("===============================================");
        }
    }
}
