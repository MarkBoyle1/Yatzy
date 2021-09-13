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
        public int TotalScore { get; set; } = 0;
        List<int> diceCombo = new List<int>();
        private Output _output = new Output();
        private Validations _validations = new Validations();
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
                string response = _userInput.GetUserResponse();
                numberToRemove = _validations.EnsureNumberIsValid(response);
            }

            return numberToRemove;
        }

        public bool ProcessDecisionToRemoveNumber()
        {
            while (true)
            {
                _output.DisplayDecisionToRemoveNumberMessage();
                string responseString = _userInput.GetUserResponse();
                int response = _validations.EnsureNumberIsValid(responseString);

                if (response == 0)
                {
                    return false;
                }
                if (response == 1)
                {
                    return true;
                }
                if (response == 2)
                {
                    _output.DisplayRemainingCategories(remainingCategories);
                }
                else
                {
                    _output.InvalidResponseMessage();
                }

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
                    
                    string response = _userInput.GetUserResponse();
                    int numberToRemove = _validations.EnsureNumberIsValid(response);
                    
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
            _output.DisplayCategorySelectionMessage();
            _output.DisplayRemainingCategories(remainingCategories);
            
            string response = _userInput.GetUserResponse();
            int category = _validations.EnsureNumberIsValid(response);
            
            category = CheckCategoryExists(category);
            remainingCategories.Remove(category);
            return category;
        }

        public int CheckCategoryExists(int category)
        {
            while (!remainingCategories.Contains(category))
            {
                _output.InvalidCategoryMessage();
                string response = _userInput.GetUserResponse();
                category = _validations.EnsureNumberIsValid(response);
            }

            return category;
        }

        public int GetNumberOfRemainingCategories()
        {
            return remainingCategories.Count;
        }
    }
}