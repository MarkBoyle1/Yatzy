using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ComputerDecisions
    {
        private ScoringCalculator _calculator;

        public ComputerDecisions()
        {
            _calculator = new ScoringCalculator();
        }

        public int GetCategoryFromComputerPlayer(List<int> diceCombo, List<int> remainingCategories)
        {
            int maxScore = 0;
            int winningCategory = remainingCategories[0];

            foreach (int category in remainingCategories)
            {
                int score = _calculator.CalculateScore(diceCombo, (ScoringCategories) category);

                if (score >= maxScore)
                {
                    maxScore = score;
                    winningCategory = category;
                }
            }

            return winningCategory;
        }

        public bool GetDecisionToRemoveNumber(List<int> diceCombo, List<int> remainingCategories)
        {
            return GetNumberToRemove(diceCombo, remainingCategories) != 0;
        }

        public int GetNumberToRemove(List<int> diceCombo, List<int> remainingCategories)
        {
            int numberToRemove;
            
            if (CheckForFullHouseOrTwoPairs(diceCombo, remainingCategories))
            {
                numberToRemove = RemoveSingleNumber(diceCombo);
            }
            else if (CheckForThreeOfAKindOrMore(diceCombo))
            {
                numberToRemove = RemoveOtherNumbers(diceCombo);
            }
            else if (diceCombo.Contains(6))
            {
                numberToRemove = TryForLargeStraight(diceCombo);
            }
            else
            {
                numberToRemove = TryForSmallStraight(diceCombo);
            }

            return numberToRemove;
        }
        
        private bool CheckForFullHouseOrTwoPairs(List<int> diceCombo, List<int> remainingCategories)
        {
            int twoPairsScore = _calculator.CalculateScore(diceCombo, ScoringCategories.TwoPairs);

            bool fullHouseCategoryExists = remainingCategories.Contains((int) ScoringCategories.FullHouse);
            bool twoPairsCategoryExists = remainingCategories.Contains((int) ScoringCategories.TwoPairs);

            return (twoPairsScore > 0 && (fullHouseCategoryExists || twoPairsCategoryExists));
        }

        private bool CheckForThreeOfAKindOrMore(List<int> diceCombo)
        {
            int numbersOccuringThreeOrMoreTimes = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() >= 3)
                .Count();
            
            return numbersOccuringThreeOrMoreTimes > 0;
        }

        private int RemoveSingleNumber(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() == 1)
                .Select(number => number.Key)
                .ToList();

            return (numbersToRemove.Count > 0) ? numbersToRemove[0] : 0;
        }
        
        //Removes all numbers that are not 3 of a kind or more.
        private int RemoveOtherNumbers(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() < 3)
                .Select(number => number.Key)
                .ToList();

            return (numbersToRemove.Count > 0) ? numbersToRemove[0] : 0;
        }

        private int TryForLargeStraight(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                 .Where(group => group.Count() > 1)
                 .Select(number => number.Key)
                 .ToList();

             if (diceCombo.Contains(1))
             {
                 return 1;
             }
             return (numbersToRemove.Count > 0) ? numbersToRemove[0] : 0;
        }
        
        private int TryForSmallStraight(List<int> diceCombo)
        {
            List<int> numbersToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() > 1)
                .Select(number => number.Key)
                .ToList();

            return (numbersToRemove.Count > 0) ? numbersToRemove[0] : 0;
        }
    }
}