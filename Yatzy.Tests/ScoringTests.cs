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
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_4_when_CalculatePairScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 4};
            Assert.Equal(8, _scoringCalculator.CalculatePairScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_1_when_CalculatePairScore_then_return_6()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 1};
            Assert.Equal(6, _scoringCalculator.CalculatePairScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_3_3_when_CalculateTwoPairsScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 3, 3};
            Assert.Equal(8, _scoringCalculator.CalculateTwoPairsScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_3_4_when_CalculateTwoPairsScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 3, 4};
            Assert.Equal(0, _scoringCalculator.CalculateTwoPairsScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_2_2_when_CalculateTwoPairsScore_then_return_6()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 2, 2};
            Assert.Equal(6, _scoringCalculator.CalculateTwoPairsScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_5_when_CalculateThreeOrFourOfAKindScore_then_return_9()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 5};
            Assert.Equal(9, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll, 3));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_4_5_6_when_CalculateThreeOrFourOfAKindScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 4, 5, 6};
            Assert.Equal(0, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll,3));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_3_1_when_CalculateThreeOrFourOfAKindScore_then_return_9()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 3, 1};
            Assert.Equal(9, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll,3));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_2_5_when_CalculateThreeOrFourOfAKindScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 2, 5};
            Assert.Equal(8, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll,4));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_5_5_when_CalculateFourOfAKindScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 5, 5};
            Assert.Equal(0, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll,4));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_2_2_when_CalculateThreeOrFourOfAKindScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 2, 2};
            Assert.Equal(8, _scoringCalculator.CalculateThreeOrFourOfAKindScore(playerDiceRoll,4));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_2_3_4_5_when_CalculateSmallStraightScore_then_return_15()
        {
            List<int> playerDiceRoll = new List<int>() {1, 2, 3, 4, 5};
            Assert.Equal(15, _scoringCalculator.CalculateSmallStraightScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_3_4_5_6_when_CalculateLargeStraightScore_then_return_20()
        {
            List<int> playerDiceRoll = new List<int>() {2, 3, 4, 5, 6};
            Assert.Equal(20, _scoringCalculator.CalculateLargeStraightScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_2_2_when_CalculateFullHouseScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 2, 2};
            Assert.Equal(8, _scoringCalculator.CalculateFullHouseScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_3_3_4_when_CalculateFullHouseScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 3, 3, 4};
            Assert.Equal(0, _scoringCalculator.CalculateFullHouseScore(playerDiceRoll));
        }
        
        [Fact]
        public void given_playerDiceRollEquals4_4_4_4_4_when_CalculateFullHouseScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {4, 4, 4, 4, 4};
            Assert.Equal(0, _scoringCalculator.CalculateFullHouseScore(playerDiceRoll));
        }
    }    
}