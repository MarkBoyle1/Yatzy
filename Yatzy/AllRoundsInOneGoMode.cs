using System.Collections.Generic;

namespace Yatzy
{
    public class AllRoundsInOneGoMode : IGameMode
    {
        private IOutput _output;

        public AllRoundsInOneGoMode(IOutput output)
        {
            _output = output;
        }
        
        public void StartGame(List<Player> playerList, Dealer dealer)
        {
            foreach (Player player in playerList)
            {
                string playerName = player.PlayerName;
                _output.CurrentPlayersTurnMessage(playerName);

                while (player.RemainingCategories.Count > 0)
                {
                    int roundScore = dealer.PlayOneRound(player);
                    player.TotalScore += roundScore;
                    _output.DisplayCurrentScore(player.TotalScore, roundScore);
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