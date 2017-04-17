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
            StartGame();
        }

        private void StartGame()
        {
            player = new Player("Player");
            aiPlayer = new AIPlayer("AI");
            Console.WriteLine("Do you want to be a first hand? (Type \"y\" if yes)");
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
        private bool gameStop = false;
        private void GameLogic()
        {
            
            while (!gameStop)
            {
                if (player.CheckTwoAces())
                    player.IsPassed = true;
                if (aiPlayer.CheckTwoAces())
                    aiPlayer.IsPassed = true;
                if (playerFirst)
                {
                    PlayerMakeDecision();
                    AIMakeDecision();
                }
                else
                {
                    AIMakeDecision();
                    PlayerMakeDecision();
                }
                if (player.IsPassed && aiPlayer.IsPassed)
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
                else if (aiPlayer.Points > 21 || player.Points > 21)
                {
                    Console.WriteLine("");
                    if (aiPlayer.CheckTwoAces())
                    {
                        Console.WriteLine("AI has Blackjack!!!");
                        CheckAllHandsCards();
                        AIWon();
                    }
                    else if (player.CheckTwoAces())
                    {
                        Console.WriteLine(" You have Blackjack!!!");
                        CheckAllHandsCards();
                        PlayerWon();
                    }
                    else
                    {
                        Console.WriteLine("Bust!!!");
                        CheckAllHandsCards();
                        if (aiPlayer.Points > 21 && player.Points > 21)
                        {
                            if (aiPlayer.Points > player.Points)
                            {
                                PlayerWon();
                            }
                            else if (aiPlayer.Points < player.Points)
                            {
                                AIWon();
                            }
                            else
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
                }
                else if (aiPlayer.Points == 21 || player.Points == 21)
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
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("                  New Round");
                    Console.WriteLine("");
                }
            }
        }

        private void PlayerMakeDecision()
        {
            Console.WriteLine("-----------Your turn----------");
            if(player.IsPassed)
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
                player.IsPassed = true;
            }
        }

        private void AIMakeDecision()
        {
            Console.WriteLine("-----------AI turn----------");
            if(aiPlayer.IsPassed)
            {
                Console.WriteLine("--AI Refused cards");
                return;
            }
            Console.WriteLine($"--AI player is thinking...");
            if (aiPlayer.Points == 21)
            {
                Console.WriteLine("--Stops taking");
            }
            else if(aiPlayer.ShouldTakeCard())
            {                              
                 Console.WriteLine("--Takes one more card");
                 GiveCardsToPlayer(aiPlayer);               
            }
            else
            {
                 Console.WriteLine("--Stop taking");
                 aiPlayer.IsPassed = true;
            }
        }

        private void GiveCardsToPlayer(Player currentPlayer, int cardsNumber = 1)
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
            gameStop = true;
            Program.PlayerWin();
            Console.WriteLine("You won!");
            AskAboutNewGame();
        }

        private void AIWon()
        {
            gameStop = true;
            Program.AIWin();
            Console.WriteLine("AI won!");
            AskAboutNewGame();
        }

        private void NobodyWon()
        {
            gameStop = true;
            Console.WriteLine("Nobody won!");
            AskAboutNewGame();
        }

        private void AskAboutNewGame()
        {
            Program.ShowTotalScores();
            Console.WriteLine("Play one more game? (Type \"y\" if yes)");
            string printed = Console.ReadLine();
            if (printed == "y" || printed == "yes")
            {
                Program.StartBlackjack();
            }
        }
    }
}
