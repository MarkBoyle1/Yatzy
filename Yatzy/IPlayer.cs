using System.Collections.Generic;

namespace Yatzy
{
    public interface IPlayer
    {
        void PlayAllRoundsInOneGo();

        void PlayOneRound();

        List<int> GetFinalDiceCombo(List<int> diceCombo);

        int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove);

        bool ProcessDecisionToRemoveNumber();

        List<int> RemoveChosenNumbers(List<int> diceCombo);
        
        int PickCategory();
        
       int CheckCategoryExists(int category);

       int GetTotalScore();

       int GetNumberOfRemainingCategories();

       string GetPlayerName();

    }
}