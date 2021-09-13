
namespace Yatzy
{
    public class TestUserInput : IUserInput
    {
        private DiceRoll _diceRoll = new DiceRoll();
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