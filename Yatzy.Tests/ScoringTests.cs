using System;
using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class ScoringTests
    {
        private ScoringCalculator _scoringCalculator = new ScoringCalculator();
        [Fact]
        public void given_playerDiceRollEquals1And1And3And3And6_when_CalculateChanceScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 3, 3, 6};
            Assert.Equal(14, _scoringCalculator.CalculateChanceScore(playerDiceRoll));
        }
        [Fact]
        public void given_playerDiceRollEquals4And5And5And6And1_when_CalculateChanceScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {4, 5, 5, 6, 1};
            Assert.Equal(21, _scoringCalculator.CalculateChanceScore(playerDiceRoll));
        }
    }    
}