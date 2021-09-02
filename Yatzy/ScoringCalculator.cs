using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoringCalculator
    {
        public int CalculateChanceScore(List<int> playerDiceRoll)
        {
            int score = 0;
            foreach (int dice in playerDiceRoll)
            {
                score += dice;
            }
            return score;
        }

        //Returns 50 only if all the numbers are the same.
        public int CalculateYatzyScore(List<int> playerDiceRoll)
        {
            if (playerDiceRoll.Any(dice => dice != playerDiceRoll[0]))
            {
                return 0;
            }

            return 50;
        }
        
        public int CalculateScoreForSingleNumber(List<int> playerDiceRoll, int category)
        {
            int score = 0;
            foreach (int dice in playerDiceRoll)
            {
                if(dice == category)
                    score += dice;
            }
            return score;
        }
    }
}