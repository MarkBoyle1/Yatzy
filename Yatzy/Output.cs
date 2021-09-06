using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Output
    {
        public void AskUserForNumberToRemove()
        {
            Console.WriteLine("What number would you like to remove:");
        }

        public void InvalidNumberMessage()
        {
            Console.WriteLine("Invalid response. Please select a number from the dice roll:");
        }

        public void DisplayDiceRoll(List<int> diceRoll)
        {
            foreach (int dice in diceRoll)
            {
                Console.WriteLine(dice);
            }
        }

        public void AskToRemoveNumberOrPickScoringCategory()
        {
            Console.WriteLine("Would you like to remove a number or pick a scoring category: (Remove number = 1, Pick Category = 2");
        }
    }
}