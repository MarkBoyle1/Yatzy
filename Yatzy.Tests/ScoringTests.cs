using System;
using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class ScoringTests
    {
        private ScoringCalculator _scoringCalculator = new ScoringCalculator();
        [Fact]
        public void given_playerDiceRollEquals1_1_3_3_6_and_CategoryEqualsZero_when_CalculateScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 3, 3, 6};
            Assert.Equal(14, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)0));
        }
        
        [Fact]
        public void given_playerDiceRollEquals4_5_5_6_1_and_CategoryEqualsZero_when_CalculateScore_then_return_14()
        {
            List<int> playerDiceRoll = new List<int>() {4, 5, 5, 6, 1};
            Assert.Equal(21, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)0));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_1_1_1_and_CategoryEqualsFourteen_when_CalculateScore_then_return_50()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 1, 1, 1};
            Assert.Equal(50, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)14));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_1_2_1_and_CategoryEqualsFourteen_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 1, 2, 1};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)14));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_4_4_and_CategoryEqualsFour_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 4, 4};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)4));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_4_and_CategoryEqualsSeven_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 4};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)7));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_1_and_CategoryEqualsSeven_when_CalculateScore_then_return_6()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 1};
            Assert.Equal(6, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)7));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_3_3_and_CategoryEqualsEight_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 3, 3};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)8));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_3_4_and_CategoryEqualsEight_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 3, 4};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)8));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_2_2_and_CategoryEqualsEight_when_CalculateScore_then_return_6()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 2, 2};
            Assert.Equal(6, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)8));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_4_5_and_CategoryEqualsNine_when_CalculateScore_then_return_9()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 4, 5};
            Assert.Equal(9, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)9));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_4_5_6_and_CategoryEqualsNine_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 4, 5, 6};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)9));
        }
        
        [Fact]
        public void given_playerDiceRollEquals3_3_3_3_1_and_CategoryEqualsNine_when_CalculateScore_then_return_9()
        {
            List<int> playerDiceRoll = new List<int>() {3, 3, 3, 3, 1};
            Assert.Equal(9, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)9));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_2_5_and_CategoryEqualsTen_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 2, 5};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)10));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_5_5_and_CategoryEqualsTen_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 5, 5};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)10));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_2_2_2_and_CategoryEqualsTen_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 2, 2, 2};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)10));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_2_3_4_5_and_CategoryEqualsEleven_when_CalculateScore_then_return_15()
        {
            List<int> playerDiceRoll = new List<int>() {1, 2, 3, 4, 5};
            Assert.Equal(15, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)11));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_3_4_5_6_and_CategoryEqualsTwelve_when_CalculateScore_then_return_20()
        {
            List<int> playerDiceRoll = new List<int>() {2, 3, 4, 5, 6};
            Assert.Equal(20, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)12));
        }
        
        [Fact]
        public void given_playerDiceRollEquals1_1_2_2_2__and_CategoryEqualsThirteen_when_CalculateScore_then_return_8()
        {
            List<int> playerDiceRoll = new List<int>() {1, 1, 2, 2, 2};
            Assert.Equal(8, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)13));
        }
        
        [Fact]
        public void given_playerDiceRollEquals2_2_3_3_4_and_CategoryEqualsThirteen_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {2, 2, 3, 3, 4};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)13));
        }
        
        [Fact]
        public void given_playerDiceRollEquals4_4_4_4_4_and_CategoryEqualsThirteen_when_CalculateScore_then_return_0()
        {
            List<int> playerDiceRoll = new List<int>() {4, 4, 4, 4, 4};
            Assert.Equal(0, _scoringCalculator.CalculateScore(playerDiceRoll, (ScoringCategories)13));
        }
    }    
}