using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Yatzy
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
    public class Output
    {
        public int GetNumberToRemove()
        {
            Console.WriteLine("What number would you like to remove:");
            string response = Console.ReadLine();

            return EnsureNumberIsValid(response);
        }

        public int InvalidNumberMessage()
        {
            Console.WriteLine("Invalid response. Please select a number from the dice roll:");
            string response = Console.ReadLine();

            return EnsureNumberIsValid(response);
        }

        public void InvalidResponseMessage()
        {
            Console.WriteLine("Invalid response. Please enter a 0 or 1:");
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

        public string GetResponseToRemoveNumber()
        {
            Console.WriteLine("Would you like to remove a number: (No = 0, Yes = 1)");
            return Console.ReadLine();
        }

        public int GetCategorySelection(List<int> remainingCategories)
        {
            Console.WriteLine("Please select a scoring category:");
            foreach(int category in remainingCategories)
            {
                Console.WriteLine("{0} = {1}", (ScoringCategories)category, category );
            }

            string response = Console.ReadLine();

            return EnsureNumberIsValid(response);
        }

        public int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                Console.WriteLine("Please enter a valid number:");
                response = Console.ReadLine();
            }

            return Convert.ToInt32(response);
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
    }
}