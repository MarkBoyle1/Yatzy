using System.Collections.Generic;

namespace Yatzy
{
    public interface IOutput
    {
        void DisplayNumberToRemoveMessage();

        void DisplayInvalidNumberMessage();

        void InvalidResponseMessage();

        void InvalidCategoryMessage();

        void DisplayDiceRoll(List<int> diceCombo);

        void DisplayDecisionToRemoveNumberMessage();

        void DisplayCategorySelectionMessage();

        void DisplayRemainingCategories(List<int> remaingingCategories);

        void DisplayCategorySelected(int category);

        void DisplayCurrentScore(int currentScore, int roundScore);

        void DisplayTotalScore(int totalScore);

        void DisplayEndResults(string playerName, int playerScore);
        void CurrentPlayersTurnMessage(string playerName);

        void DisplayPickGameModeMessage();

        void InvalidGameModeSelectionMessage();

        void DisplayPlayerNumberSelectionMessage();

        void DisplayNumberOfHumanPlayersSelectionMessage(int numberOfPlayers);

        void GetPlayerNameMessage(int playerNumber);

        void DisplayInvalidNameMessage();

        void DisplayWelcomeMessage();
    }
}