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
            Console.WriteLine("Invalid response. Please enter a 0 or 1:");
        }
        
        public void InvalidCategoryMessage()
        {
            Console.WriteLine("That category is not available. Please try again:");
        }

        public void PleaseEnterValidNumberMessage()
        {
            Console.WriteLine("Please enter a valid number:");
        }

        public void DisplayDiceRoll(List<int> diceCombo)
        {
            Console.WriteLine("Your current dice combo is:");

            Console.WriteLine(String.Join(" ", diceCombo.ToArray()));
        }

        public void DisplayDecisionToRemoveNumberMessage()
        {
            Console.WriteLine("Would you like to remove a number: (No = 0, Yes = 1)");
        }

        public void DisplayCategorySelectionMessage(Enum scoringCategories, List<int> remaingingCategories)
        {

            Console.WriteLine("Please select a scoring category:");
            foreach(int category in remaingingCategories)
            {
                Console.WriteLine(Enum.GetName(scoringCategories.GetType(), category) + " = " + category);
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

        public void DisplayEndResults(string player1Name, int player1Score, string player2Name, int player2Score)
        {
            Console.WriteLine("\n{0}'s score: {1} \n{2}'s score: {3}", player1Name, player1Score, player2Name, player2Score);
        }

        public void DisplayPickGameModeMessage()
        {
            Console.WriteLine("Please select the game mode:");
            Console.WriteLine("Single Player Game = 0" +
                              "\nTwo Players All Rounds in one go = 1" +
                              "\nTwo Players Taking Turns = 2");
        }
        
        public void InvalidGameModeSelectionMessage()
        {
            Console.WriteLine("Invalid response. Please enter a 0, 1 or 2:");
        }
        
    }
}