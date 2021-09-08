
namespace Yatzy
{
    public class YatzyGameplay
    {
        public IUserInput _userInput;
        private Output _output = new Output();
        private HumanPlayer player1 = new HumanPlayer();
        private HumanPlayer player2 = new HumanPlayer();

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
            _output.CurrentPlayersTurnMessage("Player 1");
            player1.PlayAllRoundsInOneGo();
            
            _output.CurrentPlayersTurnMessage("Player 2");
            player2.PlayAllRoundsInOneGo();

            _output.DisplayEndResults(player1.totalScore, player2.totalScore);
        }

        public void TwoPlayersTakingTurnsGame()
        {
            for (int i = 0; i < 15; i++)
            {
                _output.CurrentPlayersTurnMessage("Player 1");
                player1.PlayOneRound();
                
                _output.CurrentPlayersTurnMessage("Player 2");
                player2.PlayOneRound();
            }
            
            _output.DisplayEndResults(player1.totalScore, player2.totalScore);
        }
    }
}