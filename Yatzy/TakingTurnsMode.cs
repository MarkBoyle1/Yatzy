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
                _output.CurrentPlayersTurnMessage("Player 1");
                playerList[0].PlayOneRound();
                
                _output.CurrentPlayersTurnMessage("Player 2");
                playerList[1].PlayOneRound();
            }

            int player1Score = playerList[0].GetTotalScore();
            int player2Score = playerList[1].GetTotalScore();

            _output.DisplayEndResults("PLayer 1", player1Score, "Player 2", player2Score);
        }
    }
}