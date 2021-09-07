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
            rolledDice = _diceRoll.RollDice(rolledDice);
            Assert.Equal(5, rolledDice.Count);
        }
        
        [Fact]
        public void when_RollDiceIsCalledTwice_then_return_DifferentListsOfSixNumbers()
        {
            List<int> rolledDice = new List<int>();
            rolledDice = _diceRoll.RollDice(rolledDice);
            List<int> secondRolledDice = new List<int>();
            secondRolledDice = _diceRoll.RollDice(secondRolledDice);
            
            Assert.True(rolledDice != secondRolledDice);
        }
        
        [Fact]
        public void given_DiceRollEquals2_4_5_6_2_when_RemoveNumberFromDiceRoll_FiveIsSelected_then_return_2_4_6_2()
        {
            List<int> diceCombo = new List<int>() {2, 4, 5, 6, 2};
            List<int> expected = new List<int>() {2, 4, 6, 2};
            Assert.Equal(expected, _diceRoll.RemoveNumberFromDiceRoll(diceCombo, 5));
        }
        
        [Fact]
        public void given_DiceRollEquals2_4_5_6_2_when_RemoveNumberFromDiceRoll_TwoIsSelected_then_return_4_5_6_2()
        {
            List<int> diceCombo = new List<int>() {2, 4, 5, 6, 2};
            List<int> expected = new List<int>() {4, 5, 6, 2};
            Assert.Equal(expected, _diceRoll.RemoveNumberFromDiceRoll(diceCombo, 2));
        }
    }
}