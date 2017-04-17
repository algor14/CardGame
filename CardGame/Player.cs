using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    public class Player 
    {
        private List<Card> playerCards;
        protected string _name;

        public Player(string name = "Unknown Player")
        {
            playerCards = new List<Card>();
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
        public bool IsPassed { get; set; }

        public void AddCard(Card card)
        {
            playerCards.Add(card);
        }

        public void ShowAllCards()
        {
            Console.WriteLine($"================{_name} cards====================");
            for (int i = 0; i < playerCards.Count; i++)
            {
                Console.Write($"{playerCards[i].Suit}-{playerCards[i].Rank}-{(int)playerCards[i].Rank}; ");
            }
            Console.WriteLine("");
            Console.WriteLine("===============================================");
        }

        public bool CheckTwoAces()
        {
            if (playerCards[0].Rank == Rank.Ace && playerCards[1].Rank == Rank.Ace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
