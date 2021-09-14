using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ComputerDecisions
    {
        private ScoringCalculator _calculator = new ScoringCalculator();
        public bool CheckForFullHouse(List<int> diceCombo, List<int> remainingCategories)
        {
            int fullHouseScore = _calculator.CalculateScore(diceCombo, ScoringCategories.FullHouse);
            bool fullHouseCategoryExists = remainingCategories.Contains((int) ScoringCategories.FullHouse);
            bool twoPairsCategoryExists = remainingCategories.Contains((int) ScoringCategories.TwoPairs);
            
            if (fullHouseScore > 0 && (fullHouseCategoryExists || twoPairsCategoryExists))
            {
                return true;
            }

            return false;
        }
        
        public bool CheckForTwoPairs(List<int> diceCombo, List<int> remainingCategories)
        {
            int twoPairsScore = _calculator.CalculateScore(diceCombo, ScoringCategories.TwoPairs);
            bool twoPairsCategoryExists = remainingCategories.Contains((int) ScoringCategories.TwoPairs);
            bool fullHouseCategoryExists = remainingCategories.Contains((int) ScoringCategories.FullHouse);

            return twoPairsScore > 0 && (twoPairsCategoryExists || fullHouseCategoryExists);
        }
        
        public bool CheckForThreeOfAKindOrMore(List<int> diceCombo)
        {
            int numbersOccuringThreeOrMoreTimes = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() >= 3)
                .Count();
            
            return numbersOccuringThreeOrMoreTimes > 0;
        }

        public List<int> RemoveSingleNumber(List<int> diceCombo)
        {
            List<int> numberToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() == 1)
                .Select(number => number.Key)
                .ToList();

            diceCombo.Remove(numberToRemove[0]);

            return diceCombo;
        }
        
        public List<int> RemoveOtherNumbers(List<int> diceCombo)
        {
            List<int> numberToKeep = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() >= 3)
                .Select(number => number.Key)
                .ToList();
            
            return diceCombo.Where(number => number == numberToKeep[0]).ToList();
        }

        public List<int> TryForLargeStraight(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() == 2)
                .Select(number => number.Key)
                .ToList();
            
            foreach (int number in numbersToRemove)
            {
                diceCombo.Remove(number);
            }

            if (diceCombo.Contains(1))
            {
                diceCombo.Remove(1);
            }

            return diceCombo;
        }
        
        public List<int> TryForSmallStraight(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() == 2)
                .Select(number => number.Key)
                .ToList();
            
            foreach (int number in numbersToRemove)
            {
                diceCombo.Remove(number);
            }

            return diceCombo;
        }
    }
}