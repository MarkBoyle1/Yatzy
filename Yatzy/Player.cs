using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Player
    {
        public List<int> RemainingCategories { get; set; }
        public int TotalScore { get; set; }
        public string PlayerName { get; }
        public string PlayerType { get; }
        
        public Player(string playerName, string playerType)
        {
            PlayerName = playerName;
            PlayerType = playerType;
            RemainingCategories = new List<int>(Enumerable.Range(0,15).ToList());
        }
    }
}