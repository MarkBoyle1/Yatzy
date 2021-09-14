using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Yatzy
{
    public class ComputerPlayer : IPlayer
    {
        private DiceRoll _diceRoll = new DiceRoll();
        public List<int> remainingCategories = new List<int>(Enumerable.Range(0,15).ToList());
        private ScoringCalculator _calculator = new ScoringCalculator();
        private ComputerDecisions _computer = new ComputerDecisions();
        private IOutput _output = new ConsoleOutput();
        List<int> diceCombo = new List<int>();
        public int TotalScore { get; set; } = 0;
        public string PlayerName { get; }

        public ComputerPlayer(string playerName)
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
                if(_computer.CheckForFullHouse(diceCombo, remainingCategories))
                {
                    return diceCombo;
                }
                
                if (_computer.CheckForTwoPairs(diceCombo, remainingCategories))
                {
                    diceCombo = _computer.RemoveSingleNumber(diceCombo);
                }
                else if (_computer.CheckForThreeOfAKindOrMore(diceCombo))
                {
                    diceCombo = _computer.RemoveOtherNumbers(diceCombo);
                }
                else if (diceCombo.Contains(6))
                {
                    diceCombo = _computer.TryForLargeStraight(diceCombo);
                }
                else
                {
                    diceCombo = _computer.TryForSmallStraight(diceCombo);
                }
                
                diceCombo = _diceRoll.RollDice(diceCombo);
                _output.DisplayDiceRoll(diceCombo);
                rollsRemaining--;
            }

            return diceCombo;
        }
        
        public int PickCategory()
        {
            int maxScore = 0;
            int winningCategory = remainingCategories[0];

            foreach (int category in remainingCategories)
            {
                int score = _calculator.CalculateScore(diceCombo, (ScoringCategories) category);

                if (score > maxScore)
                {
                    maxScore = score;
                    winningCategory = category;
                }
            }

            _output.DisplayCategorySelected(winningCategory);
            remainingCategories.Remove(winningCategory);
            return winningCategory;
        }
        

        public int GetNumberOfRemainingCategories()
        {
            return remainingCategories.Count;
        }
    }
}