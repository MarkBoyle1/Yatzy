using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Output
    {
        enum ScoringCategories
        {
            Chance,
            Ones,
            Twos,
            Threes,
            Fours,
            Fives,
            Sixes,
            Pair,
            TwoPairs,
            ThreeOfAKind,
            FourOfAKind,
            SmallStraight,
            LargeStraight,
            FullHouse,
            Yatzy
        }
        
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
            foreach (int dice in diceCombo)
            {
                Console.Write(dice + " ");
            }
            Console.WriteLine();
        }

        public void DisplayDecisionToRemoveNumberMessage()
        {
            Console.WriteLine("Would you like to remove a number: (No = 0, Yes = 1)");
        }

        public void DisplayCategorySelectionMessage(List<int> remainingCategories)
        {
            Console.WriteLine("Please select a scoring category:");
            foreach(int category in remainingCategories)
            {
                Console.WriteLine("{0} = {1}", (ScoringCategories)category, category );
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

        public void DisplayEndResults(int player1Score, int player2Score)
        {
            Console.WriteLine("\nPlayer1 score: {0} \nPlayer2 score: {1}", player1Score, player2Score);
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