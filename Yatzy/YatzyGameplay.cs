
namespace Yatzy
{
    public class YatzyGameplay
    {
        public IUserInput _userInput;
        private Output _output = new Output();
        private HumanPlayer player1 = new HumanPlayer();
        private HumanPlayer player2 = new HumanPlayer();
        private string player1Name;
        private string player2Name;
        
        public YatzyGameplay(IUserInput userInput)
        {
            this._userInput = userInput;
        }

        public void PickGameMode()
        {
            _output.DisplayPickGameModeMessage();
                
            while (true)
            {
                int response = _userInput.GetUserResponse();

                if (response == 0)
                {
                    SinglePlayerGame();
                    break;
                }
            
                if (response == 1)
                {
                    TwoPlayersAllRoundsInOneGoGame();
                    break;
                }
                
                if (response == 2)
                {
                    TwoPlayersTakingTurnsGame();
                    break;
                }

                _output.InvalidGameModeSelectionMessage();
            }
        }

        public void SinglePlayerGame()
        {
            player1.PlayAllRoundsInOneGo();
        }
        
        public void TwoPlayersAllRoundsInOneGoGame()
        {
            GetPlayerNames();
            
            _output.CurrentPlayersTurnMessage(player1Name);
            player1.PlayAllRoundsInOneGo();
            
            _output.CurrentPlayersTurnMessage(player2Name);
            player2.PlayAllRoundsInOneGo();

            _output.DisplayEndResults(player1Name, player1.totalScore, player2Name, player2.totalScore);
        }

        public void TwoPlayersTakingTurnsGame()
        {
            GetPlayerNames();
            
            for (int i = 0; i < 15; i++)
            {
                _output.CurrentPlayersTurnMessage(player1Name);
                player1.PlayOneRound();
                
                _output.CurrentPlayersTurnMessage(player2Name);
                player2.PlayOneRound();
            }
            
            _output.DisplayEndResults(player1Name, player1.totalScore, player2Name, player2.totalScore);
        }
        
        public void GetPlayerNames()
        {
            _output.DisplayGetPlayerNameMessage("player 1");
            player1Name = _userInput.GetPlayerName();
            
            _output.DisplayGetPlayerNameMessage("player 2");
            player2Name = _userInput.GetPlayerName();
        }
    }
}