using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class DiceRoll
    {
        private Random random = new Random();
        public List<int> RollDice(List<int> diceCombo)
        {
            while (diceCombo.Count() < 5)
            {
                diceCombo.Add(random.Next(1,7));
            }

            return diceCombo;
        }
        
        public List<int> RemoveNumberFromDiceRoll(List<int> diceCombo, int numberToRemove)
        {
            diceCombo.Remove(numberToRemove);
            return diceCombo;
        }
    }
}