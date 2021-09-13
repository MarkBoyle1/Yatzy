using System;

namespace Yatzy
{
    public class Validations
    {
        private Output _output = new Output();
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

        public string ValidatePlayerName(string response)
        {
            while(String.IsNullOrWhiteSpace(response))
            {
                _output.DisplayInvalidNameMessage();
                response = Console.ReadLine();
            }

            return response;
        }
        
    }
}