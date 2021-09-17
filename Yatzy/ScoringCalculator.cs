using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoringCalculator
    {
        public int CalculateChanceScore(List<int> diceCombo)
        {
            return diceCombo.Sum();
        }

        //Returns 50 only if all the numbers are the same.
        public int CalculateYatzyScore(List<int> diceCombo)
        {
            if (diceCombo.Any(dice => dice != diceCombo[0]))
            {
                return 0;
            }

            return 50;
        }
        
        public int CalculateScoreForSingleNumber(List<int> diceCombo, int category)
        {
            int numberOfOccurences = diceCombo.Where(value => value == category).Count();

            return numberOfOccurences * category;
        }

        public int CalculatePairScore(List<int> diceCombo)
        {
            List<int> pairs = CollectDuplicateNumbers(diceCombo);

            if (pairs.Count > 0)
            {
                return pairs.Max() * 2;
            }
            
            return 0;
        }
        
        public int CalculateTwoPairsScore(List<int> diceCombo)
        {
            List<int> pairs = CollectDuplicateNumbers(diceCombo);

            if (pairs.Count == 2)
            {
                return pairs.Sum() * 2;
            }

            return 0;
        }

        private List<int> CollectDuplicateNumbers(List<int> diceCombo)
        {
            return GroupTogetherNumbers(diceCombo)
                .Where(group => group.Count() > 1)
                .Select(dice => dice.Key)
                .ToList();
        }
        
        public IEnumerable<IGrouping<int, int>> GroupTogetherNumbers(List<int> diceCombo)
        {
            return diceCombo.GroupBy(number => number);
        }

        public int CalculateThreeOrFourOfAKindScore(List<int> diceCombo, int category)
        {
            var groupings = GroupTogetherNumbers(diceCombo);
            foreach (var value in groupings)
            {
                if(value.Count() >= category)
                    return value.Key * category;
            }
            
            return 0;
        }

        public int CalculateSmallStraightScore(List<int> diceCombo)
        {
            return (CheckForStraight(diceCombo, 6)) ? 15 : 0;
        }

        public int CalculateLargeStraightScore(List<int> diceCombo)
        {
            return (CheckForStraight(diceCombo, 1)) ? 20 : 0;
        }

        public bool CheckForStraight(List<int> diceCombo, int missingNumber)
        {
            return (diceCombo.Distinct().Count() == 5 && !diceCombo.Contains(missingNumber));
        }
        
        public int CalculateFullHouseScore(List<int> diceCombo)
        {
            var groupings = GroupTogetherNumbers(diceCombo);
            if(groupings.Distinct().Count() == 2 && groupings.Any(dice => dice.Count() == 2))
                return diceCombo.Sum();
            
            return 0;
        }
        
        public int CalculateScore(List<int> diceCombo, Enum category)
        {
            switch(category)
            {
                case ScoringCategories.Chance:
                    return CalculateChanceScore(diceCombo);
                case ScoringCategories.Ones:
                case ScoringCategories.Twos:
                case ScoringCategories.Threes:
                case ScoringCategories.Fours:
                case ScoringCategories.Fives:
                case ScoringCategories.Sixes:
                    return CalculateScoreForSingleNumber(diceCombo, Convert.ToInt32(category));
                case ScoringCategories.Pair:
                    return CalculatePairScore(diceCombo);
                case ScoringCategories.TwoPairs:
                    return CalculateTwoPairsScore(diceCombo);
                case ScoringCategories.ThreeOfAKind:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 3); 
                case ScoringCategories.FourOfAKind:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 4);
                case ScoringCategories.SmallStraight:
                    return CalculateSmallStraightScore(diceCombo);
                case ScoringCategories.LargeStraight:
                    return CalculateLargeStraightScore(diceCombo);
                case ScoringCategories.FullHouse:
                    return CalculateFullHouseScore(diceCombo);
                default:
                    return CalculateYatzyScore(diceCombo);
            }
        }
    }
}