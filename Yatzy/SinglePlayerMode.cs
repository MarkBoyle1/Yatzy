using System.Collections.Generic;

namespace Yatzy
{
    public class SinglePlayerMode : IGameMode
    {
        private IOutput _output;

        public SinglePlayerMode(IOutput output)
        {
            _output = output;
        }
        public void StartGame(List<Player> playerList, Dealer dealer)
        {
            while (playerList[0].RemainingCategories.Count > 0)
            {
                int roundScore = dealer.PlayOneRound(playerList[0]);
                playerList[0].TotalScore += roundScore;
                _output.DisplayCurrentScore(playerList[0].TotalScore, roundScore);
            }
        }
    }
}