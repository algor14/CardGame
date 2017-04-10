using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    public class AIPlayer : IPlayer
    {


        private List<Card> playerCards;
        private string _name = "AI player";


        public AIPlayer()
        {
            playerCards = new List<Card>();
        }

        public AIPlayer(string name)
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

        public bool ShouldTakeCard(int chance)
        {
            //Console.WriteLine($"*******[SYSTEM MESSAGE]: chance = {chance}");
            Random rnd = new Random();
            int randNumber = rnd.Next(0, 100);
            bool decision = false;
            switch (chance)
            {
                case 4:
                    decision = (randNumber > 80) ? true : false;
                    break;
                case 5:
                    decision = (randNumber > 60) ? true : false;
                    break;
                case 6:
                    decision = (randNumber > 40) ? true : false;
                    break;
                default:
                    decision = true;
                    break;
            }
            //Console.WriteLine($"*******[SYSTEM MESSAGE]: decision = {decision}");
            return decision;
        }

        public void ShowAllCards()
        {
            Console.WriteLine($"================{_name}======================");
            for (int i = 0; i < playerCards.Count; i++)
            {
                Console.Write($"{playerCards[i].Suit}-{playerCards[i].Rank}-{(int)playerCards[i].Rank}; ");
            }
            Console.WriteLine("");
            Console.WriteLine("===============================================");
        }
        
    }
}
