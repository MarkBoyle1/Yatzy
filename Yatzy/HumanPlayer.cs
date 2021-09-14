using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class HumanPlayer : IPlayer
    {
        private IUserInput _userInput = new UserInput();
        private DiceRoll _diceRoll = new DiceRoll();
        public List<int> remainingCategories = new List<int>(Enumerable.Range(0,15).ToList());
        private ScoringCalculator _calculator = new ScoringCalculator();
        private IOutput _output = new ConsoleOutput();
        private Validations _validations = new Validations();
        private HumanDecisions _humanDecisions = new HumanDecisions();
        List<int> diceCombo = new List<int>();
        public int TotalScore { get; set; } = 0;
        public string PlayerName { get; }


        public HumanPlayer(string playerName)
        {
            this.PlayerName = playerName;
        }

        public void PlayAllRoundsInOneGo()
        {
            while (remainingCategories.Count > 0)
            {
                PlayOneRound();
            }

            _output.DisplayTotalScore(TotalScore);
        }

        public void PlayOneRound()
        {
            diceCombo = _diceRoll.RollDice(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

            diceCombo = GetFinalDiceCombo(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

            int category = PickCategory();
            int roundScore = _calculator.CalculateScore(diceCombo, (ScoringCategories)category);
            TotalScore += roundScore;
            _output.DisplayCurrentScore(TotalScore, roundScore);
            diceCombo.Clear();
        }

        public List<int> GetFinalDiceCombo(List<int> diceCombo)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                //User will choose numbers that will be removed and the dice will be rolled to replace those values.
                if (_humanDecisions.MakeDecisionToRemoveNumber(remainingCategories))
                {
                    diceCombo = _humanDecisions.RemoveChosenNumbers(diceCombo, remainingCategories);
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

        public int PickCategory()
        {
            _output.DisplayCategorySelectionMessage();
            _output.DisplayRemainingCategories(remainingCategories);
            
            string response = _userInput.GetUserResponse();
            int category = _validations.EnsureNumberIsValid(response);
            
            category = _validations.CheckCategoryExists(category, remainingCategories);
            remainingCategories.Remove(category);
            return category;
        }
        
        public int GetNumberOfRemainingCategories()
        {
            return remainingCategories.Count;
        }
    }
}