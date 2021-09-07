using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class UserInputTests
    {
        IUserInput _userInput = new TestUserInput();

        [Fact]
        public void given_GetDecisionToRemoveNumberEqualsTrue_when_RemoveChosenNumbers_then_DiceRollDecrements()
        {
            List<int> diceCombo = new List<int>() {3,4,5,3,2};
            diceCombo = _userInput.RemoveChosenNumbers(diceCombo);
            
            Assert.True(diceCombo.Count < 5);
        }
    }
}