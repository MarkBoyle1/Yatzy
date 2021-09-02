using System.Collections.Generic;

namespace Yatzy
{
    public class ScoringCalculator
    {
        public int CalculateChanceScore(List<int> playerDiceRoll)
        {
            int score = 0;
            foreach (int diceRoll in playerDiceRoll)
            {
                score += diceRoll;
            }
            return score;
        }
    }
}