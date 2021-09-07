using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class DiceRoll
    {
        private Random random = new Random();
        public List<int> RollDice(List<int> diceRoll)
        {
            while (diceRoll.Count() < 5)
            {
                diceRoll.Add(random.Next(1,6));
            }

            return diceRoll;
        }
        
        public List<int> RemoveNumberFromDiceRoll(List<int> diceRoll, int numberToRemove)
        {
            diceRoll.Remove(numberToRemove);
            return diceRoll;
        }
    }
}