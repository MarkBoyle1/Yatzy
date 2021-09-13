using System;

namespace Yatzy
{
    public class UserInput : IUserInput
    {
        private Output _output = new Output();

        public string GetUserResponse()
        {
            return Console.ReadLine();
        }

    }
}