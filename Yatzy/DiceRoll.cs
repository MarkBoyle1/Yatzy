using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class DiceRoll
    {
        private Random random = new Random();
        public List<int> RollDice()
        {
            List<int> diceRoll = new List<int>();
            while (diceRoll.Count() < 6)
            {
                diceRoll.Add(random.Next(1,6));
            }

            return diceRoll;
        }
    }
}