using System.Collections.Generic;

namespace Yatzy
{
    public interface IUserInput
    {
        int GetNumberToRemove(List<int> diceRoll);

        bool GetDecisionToRemoveNumber();

        List<int> RemoveChosenNumbers(List<int> diceCombo);
    }
}