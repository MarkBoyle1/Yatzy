using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class YatzyGameplayTests
    {
        ScoringCalculator calculator = new ScoringCalculator();
        [Fact]
        public void given_diceComboEquals3_3_3_4_4_and_CategoryEqualsThirteen_when_CalculateScore_then_return_17()
        {

            List<int> diceCombo = new List<int>() {3,3,3,4,4};
            Assert.Equal(17, calculator.CalculateScore(diceCombo, (ScoringCategories)13));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_3_4_4_and_CategoryEqualsSeven_when_CalculateScore_then_return_8()
        {

            List<int> diceCombo = new List<int>() {3,3,3,4,4};
            Assert.Equal(8, calculator.CalculateScore(diceCombo, (ScoringCategories)7));
        }
    }
}