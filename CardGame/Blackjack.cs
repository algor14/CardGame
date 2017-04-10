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


        private Card[] arrCards;                // array with all cards
        private int cardDeckIndex = 0;          // index of last given card in a deck
        private Player player;
        private AIPlayer aiPlayer;
        private bool playerFirst = false;       // shows who is first hand
        private bool AIPass = false;            // shows that AI stop taking cards 
        private bool playerPass = false;        // shows that player stop taking cards


        public Blackjack()
        {
            arrCards = new Card[36];
            int i = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    arrCards[i++] = new Card() { Suit = suit, Rank = rank };
                }
            }            
            ShuffleArray(arrCards);
        }

        public void StartGame()
        {
            player = new Player("Me");
            aiPlayer = new AIPlayer();
            Console.WriteLine("Do you want to be first hand? (Type \"y\" if yes)");
            string printed = Console.ReadLine();
            if (printed == "y" || printed == "yes")
            {
                playerFirst = true;
            }
            GiveCardsToPlayer(player, 2);
            Console.WriteLine("--You got 2 cards");
            GiveCardsToPlayer(aiPlayer, 2);
            Console.WriteLine("--AI got 2 cards");       
            GameLogic();           
        }

        private void ShuffleArray(Card[] arr)
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

        // algorithm of winning
        private void GameLogic()
        {
            if(playerFirst)
            {
                PlayerMakeDecision();
                AIMakeDecision();
            }else
            {
                AIMakeDecision();
                PlayerMakeDecision();
            }
            if (aiPlayer.Points > 21 || player.Points > 21)
            #region
            {

                Console.WriteLine("");
                Console.WriteLine("Bust!!!");
                CheckAllHandsCards();
                if (aiPlayer.Points > 21 && player.Points > 21)
                {
                    if (aiPlayer.Points > player.Points)
                    {
                        PlayerWon();
                    }
                    else if(aiPlayer.Points < player.Points)
                    {
                        AIWon();
                    }else
                    {
                        NobodyWon();
                    }
                }
                else if (aiPlayer.Points > 21)
                {
                    PlayerWon();
                }
                else
                {
                    AIWon();
                }
            }
            #endregion
            else if (aiPlayer.Points == 21 || player.Points == 21)
            #region
            {
                Console.WriteLine("");
                Console.WriteLine("Blackjack!!!");
                CheckAllHandsCards();
                if (aiPlayer.Points == 21 && player.Points == 21)
                {
                    NobodyWon();
                }
                else if (player.Points == 21)
                {
                    PlayerWon();
                }
                else
                {
                    AIWon();
                }
            }
            #endregion
            else if (playerPass && AIPass)
            #region
            {
                Console.WriteLine("");
                Console.WriteLine("All players passed");
                CheckAllHandsCards();
                if (aiPlayer.Points == player.Points)
                {
                    NobodyWon();
                }
                else if (aiPlayer.Points > player.Points)
                {
                    AIWon();
                }
                else
                {
                    PlayerWon();
                }                           
            }
            #endregion
            else
            {
                Console.WriteLine("");
                Console.WriteLine("                  New Round");
                Console.WriteLine("");
                GameLogic();
            }
        }

        private void PlayerMakeDecision()
        {
            Console.WriteLine("-----------Your turn----------");
            if(playerPass)
            {
                Console.WriteLine("--You refused cards");
                return;
            }
            ShowOurCards();
            Console.WriteLine("Do you want a one more card? (Type \"y\" if yes)");
            string printed = Console.ReadLine();
            if (printed == "y" || printed == "yes")
            {
                Console.WriteLine($"You've got a {arrCards[cardDeckIndex].Suit}-{arrCards[cardDeckIndex].Rank}");
                GiveCardsToPlayer(player);
            }else
            {
                playerPass = true;
            }
        }

        private void AIMakeDecision()
        {
            Console.WriteLine("-----------AI turn----------");
            if(AIPass)
            {
                Console.WriteLine("--AI Refused cards");
                return;
            }
            Console.WriteLine($"--AI player is thinking...");
            if (aiPlayer.Points > 20)
            {
                Console.WriteLine("--Stops taking");
            }else if(aiPlayer.Points > 17)
            {
                AIPass = true;
                Console.WriteLine("--Stops taking");
            }
            else
            {
                if (aiPlayer.ShouldTakeCard((21 - aiPlayer.Points)))
                {
                    Console.WriteLine("--Takes one more card");
                    GiveCardsToPlayer(aiPlayer);
                }else
                {
                    Console.WriteLine("--Stop taking");
                    AIPass = true;
                }
            }
        }

        private void GiveCardsToPlayer(IPlayer currentPlayer, int cardsNumber = 1)
        {
            for (int j = 0; j < cardsNumber; j++)
            {
                currentPlayer.AddCard(arrCards[cardDeckIndex++]);
            };
        }

        private void CheckAllHandsCards()
        {            
            player.ShowAllCards();
            aiPlayer.ShowAllCards();
            Console.WriteLine($"You have {player.Points}. AI has {aiPlayer.Points}");
        }

        private void ShowOurCards()
        {            
            player.ShowAllCards();
        }

        private void PlayerWon()
        {
            Program.playerWins++;
            Console.WriteLine("You won!");
            AskAboutNewGame();
        }

        private void AIWon()
        {
            Program.aiWins++;
            Console.WriteLine("AI won!");
            AskAboutNewGame();
        }

        private void NobodyWon()
        {
            Console.WriteLine("Nobody won!");
            AskAboutNewGame();
        }

        private void AskAboutNewGame()
        {
            Console.WriteLine($"Total score: Player - {Program.playerWins}; AI - {Program.aiWins}");
            Console.WriteLine("Play one more game? (Type \"y\" if yes)");
            string printed = Console.ReadLine();
            if (printed == "y" || printed == "yes")
            {
                Program.StartBlackjack();
            }
        }
    }
}
