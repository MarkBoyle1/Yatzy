using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class HumanPlayer : IPlayer
    {
        private static IUserInput _userInput;
        private DiceRoll _diceRoll = new DiceRoll();
        public List<int> remainingCategories = new List<int>(Enumerable.Range(0,15).ToList());
        private ScoringCalculator _calculator = new ScoringCalculator();
        private static IOutput _output;
        private Validations _validations = new Validations(_userInput, _output);
        List<int> diceCombo = new List<int>();
        public int TotalScore { get; set; } = 0;
        public string PlayerName { get; }


        public HumanPlayer(string playerName, IUserInput userInput, IOutput output)
        {
            PlayerName = playerName;
            _userInput = userInput;
            _output = output;
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

        private List<int> GetFinalDiceCombo(List<int> diceCombo)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                //User will choose numbers that will be removed and the dice will be rolled to replace those values.
                if (MakeDecisionToRemoveNumber(remainingCategories))
                {
                    diceCombo = RemoveChosenNumbers(diceCombo, remainingCategories);
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
        
        private List<int> RemoveChosenNumbers(List<int> diceCombo, List<int> remainingCategories)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                //Individual numbers will be selected and removed from the dice combo.
                if (diceCombo.Count > 0)
                {
                    _output.DisplayMessage("What number would you like to remove:");
                    
                    string response = _userInput.GetUserResponse();
                    int numberToRemove = _validations.EnsureNumberIsValid(response);
                    
                    numberToRemove = _validations.CheckIfNumberToRemoveExists(diceCombo, numberToRemove);
                    diceCombo = _diceRoll.RemoveNumberFromDiceRoll( diceCombo, numberToRemove);
                    
                    _output.DisplayDiceRoll(diceCombo);
                    stillRemoving = MakeDecisionToRemoveNumber(remainingCategories);
                }
                else
                {
                    stillRemoving = false;
                }
            }

            return diceCombo;
        }
        
        private bool MakeDecisionToRemoveNumber(List<int> remainingCategories)
        {
            while (true)
            {
                _output.DisplayMessage("\nWhat would you like to do: (Please enter a number) " +
                                       "\nPick Scoring Category or Finish Removing = 0, " +
                                       "\nRemove Number = 1, " +
                                       "\nView Remaining Categories = 2");
                
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
                    _output.DisplayMessage("Invalid response. Please enter a valid number:");
                }
            }
        }

        private int PickCategory()
        {
            _output.DisplayMessage("Please select a scoring category:");
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