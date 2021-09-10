using System.Collections.Generic;

namespace Yatzy
{
    public class AllRoundsInOneGoMode : IGameMode
    {
        private Output _output = new Output();
        
        public void StartGame(List<IPlayer> playerList)
        {
            
            _output.CurrentPlayersTurnMessage("Player 1");
            playerList[0].PlayAllRoundsInOneGo();
            
            _output.CurrentPlayersTurnMessage("Player 2");
            playerList[1].PlayAllRoundsInOneGo();

            int player1Score = playerList[0].GetTotalScore();
            int player2Score = playerList[1].GetTotalScore();

            _output.DisplayEndResults("PLayer 1", player1Score, "Player 2", player2Score);
        }
    }
}