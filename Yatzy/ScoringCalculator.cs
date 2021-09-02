using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoringCalculator
    {
        //Adds all numbers together.
        public int CalculateChanceScore(List<int> playerDiceRoll)
        {
            int score = 0;
            foreach (int diceRoll in playerDiceRoll)
            {
                score += diceRoll;
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
    }
}