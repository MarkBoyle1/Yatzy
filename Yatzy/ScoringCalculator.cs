using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoringCalculator
    {
        public int CalculateChanceScore(List<int> diceRoll)
        {
            return diceRoll.Sum();
        }

        //Returns 50 only if all the numbers are the same.
        public int CalculateYatzyScore(List<int> diceRoll)
        {
            if (diceRoll.Any(dice => dice != diceRoll[0]))
            {
                return 0;
            }

            return 50;
        }
        
        public int CalculateScoreForSingleNumber(List<int> diceRoll, int category)
        {
            int numberOfOccurences = diceRoll.Where(value => value == category).Count();

            return numberOfOccurences * category;
        }

        public int CalculatePairScore(List<int> diceRoll)
        {
            List<int> pairs = CollectDuplicateNumbers(diceRoll);

            if (pairs.Count == 0)
            {
                return 0;
            }
            return pairs.Max() * 2;
        }
        
        public int CalculateTwoPairsScore(List<int> diceRoll)
        {
            List<int> pairs = CollectDuplicateNumbers(diceRoll);
            if(pairs.Count() == 2)
                return pairs.Sum() * 2;

            return 0;
        }

        private List<int> CollectDuplicateNumbers(List<int> diceRoll)
        {
            return GroupTogetherNumbers(diceRoll)
                .Where(group => group.Count() > 1)
                .Select(dice => dice.Key)
                .ToList();
        }
        
        public IEnumerable<IGrouping<int, int>> GroupTogetherNumbers(List<int> diceRoll)
        {
            return diceRoll.GroupBy(number => number);
        }

        public int CalculateThreeOrFourOfAKindScore(List<int> diceRoll, int category)
        {
            var groupings = GroupTogetherNumbers(diceRoll);
            foreach (var value in groupings)
            {
                if(value.Count() >= category)
                    return value.Key * category;
            }
            
            return 0;
        }

        public int CalculateStraightScore(List<int> diceRoll, int category)
        {
            if (CheckForStraight(diceRoll, 1) && category == 12)
            {
                return 20;
            }
            
            if (CheckForStraight(diceRoll, 6) && category == 11)
            {
                return 15;
            }
            
            return 0;
        }

        public bool CheckForStraight(List<int> diceRoll, int missingNumber)
        {
            return (diceRoll.Distinct().Count() == 5 && !diceRoll.Contains(missingNumber));
        }
        
        public int CalculateFullHouseScore(List<int> diceRoll)
        {
            var groupings = GroupTogetherNumbers(diceRoll);
            if(groupings.Distinct().Count() == 2 && groupings.Any(dice => dice.Count() == 2))
                return diceRoll.Sum();
            
            return 0;
        }
        
        public int CalculateScore(List<int> diceCombo, Enum category)
        {
            switch(category)
            {
                case ScoringCategories.Chance:
                    return CalculateChanceScore(diceCombo);
                case ScoringCategories.Ones:
                    return CalculateScoreForSingleNumber(diceCombo, 1);
                case ScoringCategories.Twos:
                    return CalculateScoreForSingleNumber(diceCombo, 2);
                case ScoringCategories.Threes:
                    return CalculateScoreForSingleNumber(diceCombo, 3);
                case ScoringCategories.Fours:
                    return CalculateScoreForSingleNumber(diceCombo, 4);
                case ScoringCategories.Fives:
                    return CalculateScoreForSingleNumber(diceCombo, 5);
                case ScoringCategories.Sixes:
                    return CalculateScoreForSingleNumber(diceCombo, 6);
                case ScoringCategories.Pair:
                    return CalculatePairScore(diceCombo);
                case ScoringCategories.TwoPairs:
                    return CalculateTwoPairsScore(diceCombo);
                case ScoringCategories.ThreeOfAKind:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 3);
                case ScoringCategories.FourOfAKind:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 4);
                case ScoringCategories.SmallStraight:
                    return CalculateStraightScore(diceCombo, 11);
                case ScoringCategories.LargeStraight:
                    return CalculateStraightScore(diceCombo, 12);
                case ScoringCategories.FullHouse:
                    return CalculateFullHouseScore(diceCombo);
                default:
                    return CalculateYatzyScore(diceCombo);
            }
        }
    }
}