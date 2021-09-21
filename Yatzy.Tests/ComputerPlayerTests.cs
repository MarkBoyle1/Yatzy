using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class ComputerPlayerTests
    {
        private ComputerDecisions _computerDecisions = new ComputerDecisions();
        
        [Fact]
        public void given_diceComboEquals3_3_3_4_4_and_remainingCategoriesEquals1_2_3_4_5_13_when_GetNumberToRemove_then_return_0()
        {
            List<int> diceCombo = new List<int>() {3,3,3,4,4};
            List<int> remainingCategories = new List<int>() {1,2,3,4,5,13};
        
            Assert.Equal(0,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_1_4_4_and_remainingCategoriesEquals1_2_3_8_when_GetNumberToRemove_then_return_1()
        {
            List<int> diceCombo = new List<int>() {3,3,1,4,4};
            List<int> remainingCategories = new List<int>() {1,2,3,8};
        
            Assert.Equal(1,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_3_3_4_when_GetNumberToRemove_then_return_4()
        {
            List<int> diceCombo = new List<int>() {3,3,3,3,4};
            List<int> remainingCategories = new List<int>() {1,2,3,8, 14};
        
            Assert.Equal(4,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals4_4_4_4_4_when_GetNumberToRemove_then_return_0()
        {
            List<int> diceCombo = new List<int>() {4,4,4,4,4};
            List<int> remainingCategories = new List<int>() {1,2,3,8,14};
        
            Assert.Equal(0,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals3_3_3_5_when_GetNumberToRemove_then_return_5()
        {
            List<int> diceCombo = new List<int>() {3,3,3,5};
            List<int> remainingCategories = new List<int>() {1,2,3,8};
        
            Assert.Equal(5,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals1_3_5_4_6_when_GetNumberToRemove_then_return_1()
        {
            List<int> diceCombo = new List<int>() {1,3,5,4,6};
            List<int> remainingCategories = new List<int>() {1,2,3,8,12};
        
            Assert.Equal(1,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
        
        [Fact]
        public void given_diceComboEquals1_3_3_4_5_when_GetNumberToRemove_then_return_3()
        {
            List<int> diceCombo = new List<int>() {1,3,3,4,5};
            List<int> remainingCategories = new List<int>() {1,2,3,8,11};
            
            Assert.Equal(3,_computerDecisions.GetNumberToRemove(diceCombo, remainingCategories));
        }
    }
}