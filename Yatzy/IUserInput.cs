using System.Collections.Generic;

namespace Yatzy
{
    public interface IUserInput
    {
        int GetUserResponse();

        int EnsureNumberIsValid(string response);
        
    }
}