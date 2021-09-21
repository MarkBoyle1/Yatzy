using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class ConsoleOutput : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayDiceRoll(List<int> diceCombo)
        {
            Console.WriteLine("Your current dice combo is:");

            Console.WriteLine(String.Join(" ", diceCombo.ToArray()));
        }

        public void DisplayRemainingCategories(List<int> remaingingCategories)
        {
            foreach(int category in remaingingCategories)
            {
                Console.WriteLine((ScoringCategories)category + " = " + category);
            }
        }

        public void DisplayCurrentScore(int currentScore, int roundScore, int category)
        {
            Console.WriteLine($"Category selected: {(ScoringCategories)category}");
            Console.WriteLine("You gained {0} points", roundScore);
            Console.WriteLine("Your current score is: " + currentScore);
        }
        
        public void DisplayTotalScore(int totalScore)
        {
            Console.WriteLine("Your total score is: " + totalScore);
        }
        
        public void DisplayEndResults(string playerName, int playerScore)
        {
            Console.WriteLine("{0}'s score: {1}", playerName, playerScore);
        }

        public void CurrentPlayersTurnMessage(string playerName)
        {
            Console.WriteLine("\n{0}'s turn:", playerName);
        }

        public void DisplayPickGameModeMessage()
        {
            Console.WriteLine("Please select the game mode:");

            int numberOfGameModes = Enum.GetValues(typeof(MulitPlayerGameModes)).Length;

            for(int i = 0; i < numberOfGameModes; i++)
            {
                Console.WriteLine((MulitPlayerGameModes)i + " = " + i);
            }
        }
        
        public void DisplayNumberOfHumanPlayersSelectionMessage(int numberOfPlayers)
        {
            Console.WriteLine($"Of the {numberOfPlayers} players, how many are human:");
        }

        public void GetPlayerNameMessage(int playerNumber)
        {
            Console.WriteLine($"Please select the name for player {playerNumber}:");
        }

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Yatzy!\n");
        }
    }
}