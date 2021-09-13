using System.Collections.Generic;

namespace Yatzy
{
    public class TakingTurnsMode : IGameMode
    {
        private Output _output = new Output();
        
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