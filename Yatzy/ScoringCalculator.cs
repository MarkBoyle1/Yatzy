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
            int score = 0;
            foreach (int dice in diceRoll)
            {
                if(dice == category)
                    score += dice;
            }
            return score;
        }

        public int CalculatePairScore(List<int> diceRoll)
        {
            List<int> pairs = CollectDuplicateNumbers(diceRoll);

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
        
        public int CalculateScore(List<int> diceCombo, int category)
        {
            switch(category)
            {
                case 0:
                    return CalculateChanceScore(diceCombo);
                case 1:
                    return CalculateScoreForSingleNumber(diceCombo, 1);
                case 2:
                    return CalculateScoreForSingleNumber(diceCombo, 2);
                case 3:
                    return CalculateScoreForSingleNumber(diceCombo, 3);
                case 4:
                    return CalculateScoreForSingleNumber(diceCombo, 4);
                case 5:
                    return CalculateScoreForSingleNumber(diceCombo, 5);
                case 6:
                    return CalculateScoreForSingleNumber(diceCombo, 6);
                case 7:
                    return CalculatePairScore(diceCombo);
                case 8:
                    return CalculateTwoPairsScore(diceCombo);
                case 9:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 3);
                case 10:
                    return CalculateThreeOrFourOfAKindScore(diceCombo, 4);
                case 11:
                    return CalculateStraightScore(diceCombo, 11);
                case 12:
                    return CalculateStraightScore(diceCombo, 12);
                case 13:
                    return CalculateFullHouseScore(diceCombo);
                default:
                    return CalculateYatzyScore(diceCombo);
            }
        }
    }
}