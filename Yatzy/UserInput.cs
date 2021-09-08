using System;

namespace Yatzy
{
    public class UserInput : IUserInput
    {
        private Output _output = new Output();

        public int GetUserResponse()
        {
            string response = Console.ReadLine();
            return EnsureNumberIsValid(response);
        }

        public int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                _output.PleaseEnterValidNumberMessage();
                response = Console.ReadLine();
            }

            return Convert.ToInt32(response);
        }
    }
}