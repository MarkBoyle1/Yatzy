using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Validations
    {
        private IOutput _output = new ConsoleOutput();
        private UserInput _userInput = new UserInput();
        
        public int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                _output.InvalidResponseMessage();
                response = _userInput.GetUserResponse();
            }

            return Convert.ToInt32(response);
        }

        //Player name can't be empty.
        public string ValidatePlayerName(string response)
        {
            while(String.IsNullOrWhiteSpace(response))
            {
                _output.DisplayInvalidNameMessage();
                response = Console.ReadLine();
            }

            return response;
        }
        
        public int CheckCategoryExists(int category, List<int> remainingCategories)
        {
            while (!remainingCategories.Contains(category))
            {
                _output.InvalidCategoryMessage();
                string response = _userInput.GetUserResponse();
                category = EnsureNumberIsValid(response);
            }

            return category;
        }
        
        public int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove)
        {
            while (!diceCombo.Contains(numberToRemove))
            {
                _output.DisplayInvalidNumberMessage();
                string response = _userInput.GetUserResponse();
                numberToRemove = EnsureNumberIsValid(response);
            }

            return numberToRemove;
        }
        
    }
}