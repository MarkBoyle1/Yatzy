using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Yatzy
{
    public class UserInput : IUserInput
    {
        private Output _output = new Output();
        private DiceRoll _diceRoll = new DiceRoll();

        public int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove)
        {

            while (!diceCombo.Contains(numberToRemove))
            {
                numberToRemove = _output.InvalidNumberMessage();
            }

            return numberToRemove;
        }

        public bool GetDecisionToRemoveNumber()
        {
            while (true)
            {
                string response = _output.GetResponseToRemoveNumber();

                if (response == "0")
                {
                    return false;
                }
            
                if (response == "1")
                {
                    return true;
                }

                _output.InvalidResponseMessage();
            }
        }

        public List<int> RemoveChosenNumbers(List<int> diceCombo)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                //Individual numbers will be selected and removed from the dice combo.
                if (diceCombo.Count > 0)
                {
                    int numberToRemove = _output.GetNumberToRemove();
                    numberToRemove = CheckIfNumberToRemoveExists(diceCombo, numberToRemove);
                    diceCombo = _diceRoll.RemoveNumberFromDiceRoll( diceCombo, numberToRemove);
                    _output.DisplayDiceRoll(diceCombo);
                    stillRemoving = GetDecisionToRemoveNumber();
                }
                else
                {
                    stillRemoving = false;
                }
            }

            return diceCombo;
        }
    }
}