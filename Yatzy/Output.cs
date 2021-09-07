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
            Console.WriteLine("Your current dice combo is:");
            foreach (int dice in diceRoll)
            {
                Console.Write(dice + " ");
            }

            Console.WriteLine();
        }

        public void AskToRemoveNumber()
        {
            Console.WriteLine("Would you like to remove a number: (Yes = 0, No = 1");
        }
    }
}