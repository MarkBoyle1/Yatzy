using System.Collections.Generic;

namespace Yatzy
{
    public class TakingTurnsMode : IGameMode
    {
        private IOutput _output;

        public TakingTurnsMode(IOutput output)
        {
            _output = output;
        }
        
        public void StartGame(List<Player> playerList, Dealer dealer)
        {
            while(playerList[0].RemainingCategories.Count > 0)
            {
                foreach (Player player in playerList)
                {
                    string playerName = player.PlayerName;
                    _output.CurrentPlayersTurnMessage(playerName);
                    dealer.PlayOneRound(player);
                }
            }

            foreach (Player player in playerList)
            {
                string playerName = player.PlayerName;
                int playerScore = player.TotalScore;
                _output.DisplayEndResults(playerName, playerScore);
            }
        }
    }
}