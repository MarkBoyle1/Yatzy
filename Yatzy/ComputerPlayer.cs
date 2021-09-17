using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Yatzy
{
    public class ComputerPlayer : IPlayer
    {
        private DiceRoll _diceRoll = new ();
        public List<int> remainingCategories = new(Enumerable.Range(0, 15).ToList());
        private ScoringCalculator _calculator = new ();
        List<int> diceCombo = new ();
        private IOutput _output;
        public int TotalScore { get; set; } = 0;
        public string PlayerName { get; }

        public ComputerPlayer(string playerName, IOutput output)
        {
            PlayerName = playerName;
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
                if (CheckForFullHouseOrTwoPairs(diceCombo, remainingCategories))
                {
                    diceCombo = RemoveSingleNumber(diceCombo);
                }
                else if (CheckForThreeOfAKindOrMore(diceCombo))
                {
                    diceCombo = RemoveOtherNumbers(diceCombo);
                }
                else if (diceCombo.Contains(6))
                {
                    diceCombo = TryForLargeStraight(diceCombo);
                }
                else
                {
                    diceCombo = TryForSmallStraight(diceCombo);
                }
                
                diceCombo = _diceRoll.RollDice(diceCombo);
                _output.DisplayDiceRoll(diceCombo);
                rollsRemaining--;
            }

            return diceCombo;
        }
        
        private int PickCategory()
        {
            int maxScore = 0;
            int winningCategory = remainingCategories[0];

            foreach (int category in remainingCategories)
            {
                int score = _calculator.CalculateScore(diceCombo, (ScoringCategories) category);

                if (score >= maxScore)
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
        
        public bool CheckForFullHouseOrTwoPairs(List<int> diceCombo, List<int> remainingCategories)
        {
            int twoPairsScore = _calculator.CalculateScore(diceCombo, ScoringCategories.TwoPairs);

            bool fullHouseCategoryExists = remainingCategories.Contains((int) ScoringCategories.FullHouse);
            bool twoPairsCategoryExists = remainingCategories.Contains((int) ScoringCategories.TwoPairs);

            return (twoPairsScore > 0 && (fullHouseCategoryExists || twoPairsCategoryExists));
        }

        public bool CheckForThreeOfAKindOrMore(List<int> diceCombo)
        {
            int numbersOccuringThreeOrMoreTimes = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() >= 3)
                .Count();
            
            return numbersOccuringThreeOrMoreTimes > 0;
        }

        public List<int> RemoveSingleNumber(List<int> diceCombo)
        {
            List<int> numberToRemove = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() == 1)
                .Select(number => number.Key)
                .ToList();

            return diceCombo.Where(number => number != numberToRemove[0]).ToList();
        }
        
        //Removes all numbers that are not 3 of a kind or more.
        public List<int> RemoveOtherNumbers(List<int> diceCombo)
        {
            List<int> numberToKeep = diceCombo.GroupBy(number => number)
                .Where(group => group.Count() >= 3)
                .Select(number => number.Key)
                .ToList();
            
            return diceCombo.Where(number => number == numberToKeep[0]).ToList();
        }

        public List<int> TryForLargeStraight(List<int> diceCombo)
        {
             return diceCombo.GroupBy(number => number)
                .Where(number => number.Key != 1)
                .Select(number => number.Key)
                .ToList();
        }
        
        public List<int> TryForSmallStraight(List<int> diceCombo)
        {
            return diceCombo.GroupBy(number => number)
                .Select(number => number.Key)
                .ToList();
        }
    }
}