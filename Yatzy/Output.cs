using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Output
    {
        public void DisplayNumberToRemoveMessage()
        {
            Console.WriteLine("What number would you like to remove:");
        }

        public void DisplayInvalidNumberMessage()
        {
            Console.WriteLine("Invalid response. Please select a number from the dice roll:");
        }

        public void InvalidResponseMessage()
        {
            Console.WriteLine("Invalid response. Please enter a valid number:");
        }
        
        public void InvalidCategoryMessage()
        {
            Console.WriteLine("That category is not available. Please try again:");
        }

        public void DisplayDiceRoll(List<int> diceCombo)
        {
            Console.WriteLine("Your current dice combo is:");

            Console.WriteLine(String.Join(" ", diceCombo.ToArray()));
        }

        public void DisplayDecisionToRemoveNumberMessage()
        {
            Console.WriteLine("\nWhat would you like to do: (Please enter a number) \nPick Scoring Category = 0, \nRemove Number = 1, \nView Remaining Categories = 2");
        }

        public void DisplayCategorySelectionMessage()
        {
            Console.WriteLine("Please select a scoring category:");
        }

        public void DisplayRemainingCategories(List<int> remaingingCategories)
        {
            foreach(int category in remaingingCategories)
            {
                Console.WriteLine((ScoringCategories)category + " = " + category);
            }
        }
        
        public void DisplayCurrentScore(int currentScore, int roundScore)
        {
            Console.WriteLine("You gained {0} points", roundScore);
            Console.WriteLine("Your current score is: " + currentScore);
        }
        
        public void DisplayTotalScore(int totalScore)
        {
            Console.WriteLine("Your total score is: " + totalScore);
        }

        public void CurrentPlayersTurnMessage(string playerName)
        {
            Console.WriteLine("\n{0}'s turn:", playerName);
        }

        public void DisplayEndResults(string playerName, int playerScore)
        {
            Console.WriteLine("{0}'s score: {1}", playerName, playerScore);
        }

        public void DisplayPickGameModeMessage()
        {
            Console.WriteLine("Please select the game mode:");

            int numberOfGameModes = Enum.GetValues(typeof(MulitPlayerGameModes)).Length;

            for(int gameModeNumber = 0; gameModeNumber < numberOfGameModes; gameModeNumber++)
            {
                Console.WriteLine((MulitPlayerGameModes)gameModeNumber + " = " + gameModeNumber);
            }
        }
        
        public void InvalidGameModeSelectionMessage()
        {
            Console.WriteLine("Invalid response. Please enter 1 or 2:");
        }

        public void DisplayPlayerNumberSelectionMessage()
        {
            Console.WriteLine("Please select the number of players:");
        }

        public void GetPlayerNameMessage(int playerNumber)
        {
            Console.WriteLine($"Please select the name for player {playerNumber}:");
        }

        public void DisplayInvalidNameMessage()
        {
            Console.WriteLine("Please enter a response:");
        }
    }
}