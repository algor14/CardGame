using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    interface IPlayer
    {
        void AddCard(Card card);
        void ShowAllCards();
        int Points { get; }
    }
}
