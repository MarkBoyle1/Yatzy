using System;
using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class ScoringTests
    {
        private ScoringCalculator _scoringCalculator = new ScoringCalculator();
        [Fact]
        public void given_playerDiceRollEquals1_1_3_3_6_when_CalculateChanceScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 3, 3, 6};
            Assert.Equal(14, _scoringCalculator.CalculateChanceScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals4_5_5_6_1_when_CalculateChanceScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {4, 5, 5, 6, 1};
            Assert.Equal(21, _scoringCalculator.CalculateChanceScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_1_1_1_when_CalculateYatzyScore_then_return_50()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 1, 1, 1};
            Assert.Equal(50, _scoringCalculator.CalculateYatzyScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_1_2_1_when_CalculateYatzyScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 1, 2, 1};
            Assert.Equal(0, _scoringCalculator.CalculateYatzyScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_4_4_and_CategoryEquals4_when_CalculateScoreForSingleNumber_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 4, 4};
            Assert.Equal(8, _scoringCalculator.CalculateScoreForSingleNumber(playerDiceRoll, 4));
        }
    }    
}