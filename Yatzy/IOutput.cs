using System.Collections.Generic;

namespace Yatzy
{
    public interface IOutput
    {
        void DisplayMessage(string message);

        void DisplayDiceRoll(List<int> diceCombo);

        void DisplayRemainingCategories(List<int> remaingingCategories);

        void DisplayCategorySelected(int category);

        void DisplayCurrentScore(int currentScore, int roundScore);

        void DisplayTotalScore(int totalScore);

        void DisplayEndResults(string playerName, int playerScore);
        void CurrentPlayersTurnMessage(string playerName);

        void DisplayPickGameModeMessage();
        
        void DisplayNumberOfHumanPlayersSelectionMessage(int numberOfPlayers);

        void GetPlayerNameMessage(int playerNumber);
        
        void DisplayWelcomeMessage();
    }
}