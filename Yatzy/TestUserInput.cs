
namespace Yatzy
{
    public class TestUserInput : IUserInput
    {
        private string number;

        public TestUserInput(string number)
        {
            this.number = number;
        }
        public string GetUserResponse()
        {
            return number;
        }
        
    }
}