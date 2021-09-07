using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Yatzy
{
    public class UserInput : IUserInput
    {
        private Output _output = new Output();
        private DiceRoll _diceRoll = new DiceRoll();

        public int GetNumberToRemove(List<int> diceRoll)
        {
            _output.AskUserForNumberToRemove();
                string numberToRemove = "0";
                _output.DisplayDiceRoll(diceRoll);

                do
                {
                    numberToRemove = Console.ReadLine();

                    if (!diceRoll.Contains(Convert.ToInt32(numberToRemove)))
                    {
                        _output.InvalidNumberMessage();
                    }
                
                } while (!diceRoll.Contains(Convert.ToInt32(numberToRemove)));
                
                return Convert.ToInt32(numberToRemove);
        }
        
        public bool GetDecisionToRemoveNumber()
        {
            _output.AskToRemoveNumber();
            string response = Console.ReadLine();

            if (response == "0")
            {
                return true;
            }
            
            if (response == "1")
            {
                return false;
            }

            return true;
        }

        public List<int> RemoveChosenNumbers(List<int> diceCombo)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                //Individual numbers will be selected and removed from the dice combo.
                if (diceCombo.Count > 0)
                {
                    int numberToRemove = GetNumberToRemove(diceCombo);
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