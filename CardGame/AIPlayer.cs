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

        public AIPlayer(string name = "AI")
        {
            _name = name;
        }
        public bool ShouldTakeCard()
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(0, 100);
            bool decision = false;
            int chance = 21 - Points;
            if(chance < 4)
            {
                decision = false;
            }else if(chance == 4)
            {
                decision = (randNumber > 80) ? true : false;
            }
            else if (chance == 5)
            {
                decision = (randNumber > 60) ? true : false;
            }
            else if (chance == 6)
            {
                decision = (randNumber > 40) ? true : false;
            }else
            {
                decision = true;
            }           
            return decision;
        }
    }
}
