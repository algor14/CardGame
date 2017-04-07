using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    class Blackjack
    {
        private Card[] arrCards; // array with all cards
        private int cardDeckIndex = 0; // index of last given card in a deck
        private Card[] playerCards = new Card[0]; // array of players card
        private Card[] AICards = new Card[0];     // array of computers cards
        private bool playerFirst = false;
        public Blackjack()
        {
            arrCards = new Card[]{
                new Card() {Suit = Suit.Spades , Rank = Rank.Six},
                new Card() {Suit = Suit.Spades, Rank = Rank.Seven},
                new Card() {Suit = Suit.Spades, Rank = Rank.Eight},
                new Card() {Suit = Suit.Spades, Rank = Rank.Nine},
                new Card() {Suit = Suit.Spades, Rank = Rank.Ten},
                new Card() {Suit = Suit.Spades, Rank = Rank.Jack},
                new Card() {Suit = Suit.Spades, Rank = Rank.Queen},
                new Card() {Suit = Suit.Spades, Rank = Rank.King},
                new Card() {Suit = Suit.Spades, Rank = Rank.Ace},
                //****************************************************
                new Card() {Suit = Suit.Clubs, Rank = Rank.Six},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Seven},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Eight},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Nine},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Ten},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Queen},
                new Card() {Suit = Suit.Clubs, Rank = Rank.King},
                new Card() {Suit = Suit.Clubs, Rank = Rank.Ace},
                //*****************************************************
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Six},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Seven},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Eight},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Nine},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Ten},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Jack},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Queen},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.King},
                new Card() {Suit = Suit.Diamonds, Rank = Rank.Ace},
                //****************************************************
                new Card() {Suit = Suit.Hearts, Rank = Rank.Six},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Seven},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Eight},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Nine},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Ten},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Jack},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Queen},
                new Card() {Suit = Suit.Hearts, Rank = Rank.King},
                new Card() {Suit = Suit.Hearts, Rank = Rank.Ace},
                //*****************************************************
            };
            shuffleArray(arrCards);
        }

        public void StartGame()
        {
            Console.WriteLine("Do you want to be first hand? (Type \"y\" if yes)");
            if (Console.ReadLine() == "y" || Console.ReadLine() == "yes")
            {
                playerFirst = true;
            }
            giveUsCards(2);
            checkHandsCards();
        }

        private void shuffleArray(Card[] arr)
        {
            Random rnd = new Random();
            int i = arr.Length - 1;
            while (i > 0)
            {
                int index = rnd.Next(--i);
                Card tmp = arr[i + 1];
                arr[i + 1] = arr[index];
                arr[index] = tmp;
            }
        }

        private void giveUsCards(int cardsNumber)
        {
            for (int j = 0; j < cardsNumber; j++)
            {
                Card[] tempArray = new Card[playerCards.Length];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = playerCards[i];
                }
                playerCards = new Card[playerCards.Length + 1];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    playerCards[i] = tempArray[i];
                }
                playerCards[playerCards.Length - 1] = arrCards[cardDeckIndex++];               
            }
        }
        private void checkHandsCards()
        {
            Console.WriteLine("===============PlayerCards===================");
            
            for (int i = 0; i < playerCards.Length; i++)
            {
                Console.Write($"{playerCards[i].Suit}-{playerCards[i].Rank}; ");
            }
            Console.WriteLine("");
            Console.WriteLine("=================AICards=====================");
        }
        
    }
}
