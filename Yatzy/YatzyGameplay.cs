using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGameplay
    {
        private DiceRoll diceRoll = new DiceRoll();
        private ScoringCalculator _calculator = new ScoringCalculator();
        public IUserInput _userInput;
        private Output _output = new Output();
        public List<int> scoringCategories = new List<int>(Enumerable.Range(0,15).ToList());

        public YatzyGameplay(IUserInput userInput)
        {
            this._userInput = userInput;
        }

        public void UserAction()
        {
            int totalScore = 0;
            List<int> diceCombo = new List<int>();

            //The while loop continues until all scoring categories have been used and the player's turn is over.
            while (scoringCategories.Count > 0)
            {
                diceCombo = diceRoll.RollDice(diceCombo);
                _output.DisplayDiceRoll(diceCombo);

                diceCombo = GetFinalDiceCombo(diceCombo);
                _output.DisplayDiceRoll(diceCombo);

                int category = PickCategory();
                int roundScore = CalculateScore(diceCombo, category);
                totalScore += roundScore;
                _output.DisplayCurrentScore(totalScore, roundScore);
                diceCombo.Clear();
            }

            _output.DisplayTotalScore(totalScore);
        }

        public List<int> GetFinalDiceCombo(List<int> diceCombo)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                //User will choose numbers that will be removed and the dice will be rolled to replace those values.
                if (_userInput.GetDecisionToRemoveNumber())
                {
                    diceCombo = _userInput.RemoveChosenNumbers(diceCombo);
                    diceCombo = diceRoll.RollDice(diceCombo);
                    _output.DisplayDiceRoll(diceCombo);
                    rollsRemaining--;
                }
                else
                {
                    break;
                }
            }

            return diceCombo;
        }

        public int PickCategory()
        {
            int category = _output.GetCategorySelection(scoringCategories);
            scoringCategories.Remove(category);
            return category;
        }

        public int CalculateScore(List<int> diceCombo, int category)
        {
            switch(category)
            {
                case 0:
                    return _calculator.CalculateChanceScore(diceCombo);
                case 1:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 1);
                case 2:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 2);
                case 3:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 3);
                case 4:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 4);
                case 5:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 5);
                case 6:
                    return _calculator.CalculateScoreForSingleNumber(diceCombo, 6);
                case 7:
                    return _calculator.CalculatePairScore(diceCombo);
                case 8:
                    return _calculator.CalculateTwoPairsScore(diceCombo);
                case 9:
                    return _calculator.CalculateThreeOrFourOfAKindScore(diceCombo, 3);
                case 10:
                    return _calculator.CalculateThreeOrFourOfAKindScore(diceCombo, 4);
                case 11:
                    return _calculator.CalculateStraightScore(diceCombo, 11);
                case 12:
                    return _calculator.CalculateStraightScore(diceCombo, 12);
                case 13:
                    return _calculator.CalculateFullHouseScore(diceCombo);
                default:
                    return _calculator.CalculateYatzyScore(diceCombo);
            }
        }
    }
}