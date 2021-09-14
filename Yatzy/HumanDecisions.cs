using System.Collections.Generic;

namespace Yatzy
{
    public class HumanDecisions
    {
        private IOutput _output = new ConsoleOutput();
        private UserInput _userInput = new UserInput();
        private Validations _validations = new Validations();
        private DiceRoll _diceRoll = new DiceRoll();

        public bool MakeDecisionToRemoveNumber(List<int> remainingCategories)
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
        
        public List<int> RemoveChosenNumbers(List<int> diceCombo, List<int> remainingCategories)
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
    }
}