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
                player.PlayAllRoundsInOneGo();
            }

            foreach (IPlayer player in playerList)
            {
                string playerName = player.GetPlayerName();
                int playerScore = player.GetTotalScore();
                _output.DisplayEndResults(playerName, playerScore);
            }
        }
    }
}