using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class ComputerPlayerTests
    {
        private ComputerPlayer _computerPlayer = new ("Test", new ConsoleOutput());
        
        [Fact]
        public void given_diceComboEquals3_3_3_4_4_and_remainingCategoriesEquals1_2_3_4_5_13_when_CheckForFullHouse_then_return_true()
        {
            List<int> diceCombo = new List<int>() {3,3,3,4,4};
            List<int> remainingCategories = new List<int>() {1,2,3,4,5,13};

            Assert.True(_computerPlayer.CheckForFullHouseOrTwoPairs(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_1_4_4_and_remainingCategoriesEquals1_2_3_8_when_CheckForTwoPairs_then_return_true()
        {
            List<int> diceCombo = new List<int>() {3,3,1,4,4};
            List<int> remainingCategories = new List<int>() {1,2,3,8};

            Assert.True(_computerPlayer.CheckForFullHouseOrTwoPairs(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_1_3_4_when_CheckForThreeOfAKindOrMore_then_return_true()
        {
            List<int> diceCombo = new List<int>() {3,3,1,3,4};

            Assert.True(_computerPlayer.CheckForThreeOfAKindOrMore(diceCombo));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_1_4_4_when_RemoveSingleNumber_then_return_3_3_4_4()
        {
            List<int> diceCombo = new List<int>() {3,3,1,4,4};
            List<int> expected = new List<int>() {3,3,4,4};

            Assert.Equal(expected, _computerPlayer.RemoveSingleNumber(diceCombo));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_3_4_4_when_RemoveOtherNumbers_then_return_3_3_3()
        {
            List<int> diceCombo = new List<int>() {3,3,3,4,4};
            List<int> expected = new List<int>() {3,3,3};

            Assert.Equal(expected, _computerPlayer.RemoveOtherNumbers(diceCombo));
        }
        
        [Fact]
        public void given_diceComboEquals1_3_3_4_6_when_TryForLargeStraight_then_return_3_4_6()
        {
            List<int> diceCombo = new List<int>() {1,3,3,4,6};
            List<int> expected = new List<int>() {3,4,6};

            Assert.Equal(expected, _computerPlayer.TryForLargeStraight(diceCombo));
        }
        
        [Fact]
        public void given_diceComboEquals1_3_3_4_5_when_TryForSmallStraight_then_return_1_3_4()
        {
            List<int> diceCombo = new List<int>() {1,3,3,4,5};
            List<int> expected = new List<int>() {1,3,4,5};
            
            Assert.Equal(expected, _computerPlayer.TryForSmallStraight(diceCombo));
        }
    }
}