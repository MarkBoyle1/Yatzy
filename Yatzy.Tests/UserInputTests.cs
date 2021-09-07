using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class UserInputTests
    {
        [Fact]
        public void given_GetDecisionToRemoveNumberEqualsTrue_when_RemoveChosenNumbers_then_DiceRollDecrementsByMoreThanOne()
        {
            IUserInput _userInput = new TestUserInput(true);
            
            List<int> diceCombo = new List<int>() {3,4,5,3,2};
            diceCombo = _userInput.RemoveChosenNumbers(diceCombo);
            
            Assert.True(diceCombo.Count < 4);
        }
        
        [Fact]
        public void given_GetDecisionToRemoveNumberEqualsFalse_when_RemoveChosenNumbers_then_DiceRollDecrementsByOne()
        {
            IUserInput _userInput = new TestUserInput(false);
            
            List<int> diceCombo = new List<int>() {3,4,5,3,2};
            diceCombo = _userInput.RemoveChosenNumbers(diceCombo);
            
            Assert.True(diceCombo.Count == 4);
        }
    }
}