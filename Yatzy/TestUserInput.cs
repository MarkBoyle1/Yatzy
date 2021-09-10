
namespace Yatzy
{
    public class TestUserInput : IUserInput
    {
        private DiceRoll _diceRoll = new DiceRoll();
        private int number;

        public TestUserInput(int number)
        {
            this.number = number;
        }
        public int GetUserResponse()
        {
            return number;
        }

        public int EnsureNumberIsValid(string response)
        {
            return number;
        }

        public string GetPlayerName()
        {
            return "Test";
        }
    }
}