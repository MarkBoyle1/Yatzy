using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class HumanPlayer
    {
        private IUserInput _userInput = new UserInput();
        private DiceRoll _diceRoll = new DiceRoll();
        public List<int> scoringCategories = new List<int>(Enumerable.Range(0,15).ToList());
        private ScoringCalculator _calculator = new ScoringCalculator();
        public int totalScore = 0;
        List<int> diceCombo = new List<int>();
        private Output _output = new Output();

        public void PlayAllRoundsInOneGo()
        {
            while (scoringCategories.Count > 0)
            {
                PlayOneRound();
            }

            _output.DisplayTotalScore(totalScore);
        }

        public void PlayOneRound()
        {
            diceCombo = _diceRoll.RollDice(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

            diceCombo = GetFinalDiceCombo(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

            int category = PickCategory();
            int roundScore = _calculator.CalculateScore(diceCombo, category);
            totalScore += roundScore;
            _output.DisplayCurrentScore(totalScore, roundScore);
            diceCombo.Clear();
        }

        public List<int> GetFinalDiceCombo(List<int> diceCombo)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                //User will choose numbers that will be removed and the dice will be rolled to replace those values.
                if (ProcessDecisionToRemoveNumber())
                {
                    diceCombo = RemoveChosenNumbers(diceCombo);
                    diceCombo = _diceRoll.RollDice(diceCombo);
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
        public int CheckIfNumberToRemoveExists(List<int> diceCombo, int numberToRemove)
        {
            while (!diceCombo.Contains(numberToRemove))
            {
                _output.DisplayInvalidNumberMessage();
                numberToRemove = _userInput.GetUserResponse();
            }

            return numberToRemove;
        }

        public bool ProcessDecisionToRemoveNumber()
        {
            while (true)
            {
                _output.DisplayDecisionToRemoveNumberMessage();
                int response = _userInput.GetUserResponse();

                if (response == 0)
                {
                    return false;
                }
            
                if (response == 1)
                {
                    return true;
                }

                _output.InvalidResponseMessage();
            }
        }
        public List<int> RemoveChosenNumbers(List<int> diceCombo)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                //Individual numbers will be selected and removed from the dice combo.
                if (diceCombo.Count > 0)
                {
                    _output.DisplayNumberToRemoveMessage();
                    int numberToRemove = _userInput.GetUserResponse();
                    numberToRemove = CheckIfNumberToRemoveExists(diceCombo, numberToRemove);
                    diceCombo = _diceRoll.RemoveNumberFromDiceRoll( diceCombo, numberToRemove);
                    _output.DisplayDiceRoll(diceCombo);
                    stillRemoving = ProcessDecisionToRemoveNumber();
                }
                else
                {
                    stillRemoving = false;
                }
            }

            return diceCombo;
        }
        
        public int PickCategory()
        {
            _output.DisplayCategorySelectionMessage(scoringCategories);
            int category = _userInput.GetUserResponse();
            category = CheckCategoryExists(category);
            scoringCategories.Remove(category);
            return category;
        }

        private int CheckCategoryExists(int category)
        {
            while (!scoringCategories.Contains(category))
            {
                _output.InvalidCategoryMessage();
                category = _userInput.GetUserResponse();
            }

            return category;
        }
    }
}