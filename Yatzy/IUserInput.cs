using System.Collections.Generic;

namespace Yatzy
{
    public interface IUserInput
    {
        int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove);

        bool GetDecisionToRemoveNumber();

        List<int> RemoveChosenNumbers(List<int> diceCombo);
    }
}