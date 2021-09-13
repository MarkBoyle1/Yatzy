using System.Collections.Generic;

namespace Yatzy
{
    public class AllRoundsInOneGoMode : IGameMode
    {
        private Output _output = new Output();
        
        public void StartGame(List<IPlayer> playerList)
        {
            foreach (IPlayer player in playerList)
            {
                string playerName = player.PlayerName;
                _output.CurrentPlayersTurnMessage(playerName);
                player.PlayAllRoundsInOneGo();
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