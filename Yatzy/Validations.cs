using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Validations
    {
        private IOutput _output;
        private IUserInput _userInput;

        public Validations(IUserInput userInput, IOutput output)
        {
            _userInput = userInput;
            _output = output;
        }
        
        public int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
                response = _userInput.GetUserResponse();
            }

            return Convert.ToInt32(response);
        }

        //Player name can't be empty.
        public string ValidatePlayerName(string response)
        {
            while(String.IsNullOrWhiteSpace(response))
            {
                _output.DisplayMessage("Please enter a response:");
                response = Console.ReadLine();
            }

            return response;
        }
        
        //The selected category needs to be in the remainingCategories list.
        public int CheckCategoryExists(int category, List<int> remainingCategories)
        {
            while (!remainingCategories.Contains(category))
            {
                _output.DisplayMessage("That category is not available. Please try again:");
                string response = _userInput.GetUserResponse();
                category = EnsureNumberIsValid(response);
            }

            return category;
        }
        
        //The selected number needs to be in the diceCombo.
        public int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove)
        {
            while (!diceCombo.Contains(numberToRemove))
            {
                _output.DisplayMessage("Invalid response. Please select a number from the dice roll:");
                string response = _userInput.GetUserResponse();
                numberToRemove = EnsureNumberIsValid(response);
            }

            return numberToRemove;
        }
        
    }
}