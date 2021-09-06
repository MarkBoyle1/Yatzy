using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class DiceRollTests
    {
        private DiceRoll _diceRoll = new DiceRoll();
        [Fact]
        public void when_RollDice_then_return_ListOfSixNumbers()
        {
            List<int> rolledDice = new List<int>();
            rolledDice = _diceRoll.RollDice();
            Assert.Equal(6, rolledDice.Count);
        }
    }
}