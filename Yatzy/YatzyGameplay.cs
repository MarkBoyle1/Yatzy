using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGameplay
    {
        private DiceRoll diceRoll = new DiceRoll();
        public IUserInput _userInput;
        private Output _output = new Output();

        public YatzyGameplay(IUserInput userInput)
        {
            this._userInput = userInput;
        }

        public void StartGame()
        {
            
        }

        public void UserAction()
        {
            List<int> diceCombo = new List<int>();
            diceCombo = diceRoll.RollDice(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

            diceCombo = GetFinalDiceCombo(diceCombo);
            _output.DisplayDiceRoll(diceCombo);

        }

        public List<int> GetFinalDiceCombo(List<int> diceCombo)
        {
            int rollsRemaining = 2;

            while (rollsRemaining > 0)
            {
                bool userWantsToRemoveNumbers = _userInput.GetDecisionToRemoveNumber();

                //User will choose numbers which will be removed and the dice will be rolled to replace those values.
                if (userWantsToRemoveNumbers)
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
    }
}