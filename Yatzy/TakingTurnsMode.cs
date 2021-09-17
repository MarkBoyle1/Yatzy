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
        
        public void StartGame(List<IPlayer> playerList)
        {
            while(playerList[0].GetNumberOfRemainingCategories() > 0)
            {
                foreach (IPlayer player in playerList)
                {
                    string playerName = player.PlayerName;
                    _output.CurrentPlayersTurnMessage(playerName);
                    player.PlayOneRound();
                }
            }

            foreach (IPlayer player in playerList)
            {
                string playerName = player.PlayerName;
                int playerScore = player.TotalScore;
                _output.DisplayEndResults(playerName, playerScore);
            }
        }
    }
}