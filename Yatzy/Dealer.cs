using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Dealer
    {
        private IUserInput _userInput;
        private DiceRoll _diceRoll;
        private ScoringCalculator _calculator;
        private IOutput _output;
        private List<int> _diceCombo;
        private ComputerDecisions _computerDecisions;
        private Player _player; 
        
        public Dealer(IOutput output, IUserInput userInput)
        {
            _output = output;
            _userInput = userInput;
            _diceRoll = new DiceRoll();
            _calculator = new ScoringCalculator();
            _diceCombo = new List<int>();
            _computerDecisions = new ComputerDecisions();
        }

        public int PlayOneRound(Player player)
        {
            _player = player;

            _diceCombo = _diceRoll.RollDice(_diceCombo);
            _output.DisplayDiceRoll(_diceCombo);
        
            _diceCombo = GetFinalDiceCombo(_diceCombo, player);
            _output.DisplayDiceRoll(_diceCombo);

            int category = player.PlayerType == "human"
                ? PickCategory()
                : _computerDecisions.GetCategoryFromComputerPlayer(_diceCombo, _player.RemainingCategories);
            
            _output.DisplayCategorySelected(category);
            
            player.RemainingCategories.Remove(category);
            
            int roundScore = _calculator.CalculateScore(_diceCombo, (ScoringCategories)category);
            _diceCombo.Clear();
            
            return roundScore;
        }

        private List<int> GetFinalDiceCombo(List<int> diceCombo, Player player)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                bool decision = player.PlayerType == "human" 
                    ? MakeDecisionToRemoveNumber() 
                    : _computerDecisions.GetDecisionToRemoveNumber(diceCombo, _player.RemainingCategories);
                
                //User will choose numbers that will be removed and the dice will be rolled to replace those values.
                if (decision)
                {
                    diceCombo = RemoveChosenNumbers(diceCombo, player);
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
        
        private List<int> RemoveChosenNumbers(List<int> diceCombo, Player player)
        {
            bool stillRemoving = true;

            while (stillRemoving)
            {
                //Individual numbers will be selected and removed from the dice combo.
                if (diceCombo.Count > 0)
                {
                    int numberToRemove;
                    
                    if (player.PlayerType == "human")
                    {
                        _output.DisplayMessage("What number would you like to remove:");
                        string response = _userInput.GetUserResponse();
                        numberToRemove = EnsureNumberIsValid(response);
                    }
                    else
                    {
                        numberToRemove = _computerDecisions.GetNumberToRemove(diceCombo, _player.RemainingCategories);
                    }
                    
                    bool doesExist = diceCombo.Contains(numberToRemove);
                    
                    while (!doesExist)
                    {
                        _output.DisplayMessage("Invalid response. Please select a number from the dice roll:");
                        string response = _userInput.GetUserResponse();
                        numberToRemove = EnsureNumberIsValid(response);
                        doesExist = diceCombo.Contains(numberToRemove);
                    }
                    
                    diceCombo = _diceRoll.RemoveNumberFromDiceRoll( diceCombo, numberToRemove);
                    
                    _output.DisplayDiceRoll(diceCombo);
                    stillRemoving = player.PlayerType == "human" 
                        ? MakeDecisionToRemoveNumber() 
                        : _computerDecisions.GetDecisionToRemoveNumber(diceCombo, _player.RemainingCategories);
                }
                else
                {
                    stillRemoving = false;
                }
            }

            return diceCombo;
        }
        
        private bool MakeDecisionToRemoveNumber()
        {
            while (true)
            {
                _output.DisplayMessage("\nWhat would you like to do: (Please enter a number) " +
                                       "\nPick Scoring Category or Finish Removing = 0, " +
                                       "\nRemove Number = 1, " +
                                       "\nView Remaining Categories = 2");
                
                string responseString = _userInput.GetUserResponse();
                int response = EnsureNumberIsValid(responseString);

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
                    _output.DisplayRemainingCategories(_player.RemainingCategories);
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
            _output.DisplayRemainingCategories(_player.RemainingCategories);
            
            string response = _userInput.GetUserResponse();
            int category = EnsureNumberIsValid(response);
            
            bool doesExist = _player.RemainingCategories.Contains(category);
            
            while (!doesExist)
            {
                _output.DisplayMessage("That category is not available. Please try again:");
                response = _userInput.GetUserResponse();
                category = EnsureNumberIsValid(response);
                doesExist = _player.RemainingCategories.Contains(category);
            }
            
            return category;
        }

        public int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
                response = _userInput.GetUserResponse();
            }

            return Convert.ToInt32(response);
        }
    
    }
}