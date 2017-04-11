using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardGame
{
    internal class AIPlayer : Player
    {
        public bool ShouldTakeCard(int chance)
        {
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
            return decision;
        }
    }
}
