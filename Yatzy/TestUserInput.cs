using System.Collections.Generic;

namespace Yatzy
{
    public class TestUserInput : IUserInput
    {
        private DiceRoll _diceRoll = new DiceRoll();
        private bool isRemovingNumber;

        public TestUserInput(bool isRemovingNumber)
        {
            this.isRemovingNumber = isRemovingNumber;
        }
        public int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove)
        {
            return numberToRemove;
        }

        public bool GetDecisionToRemoveNumber()
        {
            return isRemovingNumber;
        }

        public List<int> RemoveChosenNumbers(List<int> diceCombo)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                if (diceCombo.Count > 0)
                {
                    int numberToRemove = CheckIfNumberToRemoveExists(diceCombo, diceCombo[0]);
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