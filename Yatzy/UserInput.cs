using System;

namespace Yatzy
{
    public class UserInput : IUserInput
    {
        public string GetUserResponse()
        {
            return Console.ReadLine();
        }
    }
}