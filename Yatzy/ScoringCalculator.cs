using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoringCalculator
    {
        public int CalculateChanceScore(List<int> diceRoll)
        {
            int score = 0;
            foreach (int dice in diceRoll)
            {
                score += dice;
            }
            return score;
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
            List<int> pairs = new List<int>();
            var groupings = diceRoll.GroupBy(number => number);
            foreach (var value in groupings)
            {
                if(value.Count() > 1)
                    pairs.Add(value.Key);
            }

            return pairs;
        }

        public int CalculateThreeOfAKindScore(List<int> diceRoll)
        {
            var groupings = diceRoll.GroupBy(number => number);
            foreach (var value in groupings)
            {
                if(value.Count() > 2)
                    return value.Key * 3;
            }

            return 0;
        }
    }
}