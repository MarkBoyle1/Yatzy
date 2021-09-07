using System.Collections.Generic;

namespace Yatzy
{
    public class TestUserInput : IUserInput
    {
        private DiceRoll _diceRoll = new DiceRoll();
        public int GetNumberToRemove(List<int> diceRoll)
        {
            return diceRoll[0];
        }

        public bool GetDecisionToRemoveNumber()
        {
            return false;
        }

        public List<int> RemoveChosenNumbers(List<int> diceCombo)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                if (diceCombo.Count > 0)
                {
                    int numberToRemove = GetNumberToRemove(diceCombo);
                    diceCombo = _diceRoll.RemoveNumberFromDiceRoll( diceCombo, numberToRemove);
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