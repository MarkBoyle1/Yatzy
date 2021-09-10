
using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGameplay
    {
        public IUserInput _userInput;
        private Output _output = new Output();
        private List<IPlayer> playerList = new List<IPlayer>();

        public YatzyGameplay(IUserInput userInput)
        {
            this._userInput = userInput;
        }

        public void AddPlayers()
        {
            playerList.Add(new HumanPlayer());
            playerList.Add(new HumanPlayer());
        }

        public void PickGameMode()
        {
            AddPlayers();
            _output.DisplayPickGameModeMessage();

            while (true)
            {
                int response = _userInput.GetUserResponse();

                if (response == 0)
                {
                    IGameMode singlePlayer = new SinglePlayerMode();
                    singlePlayer.StartGame(playerList);
                    break;
                }
            
                if (response == 1)
                {
                    IGameMode allRoundsInOneGo = new AllRoundsInOneGoMode();
                    allRoundsInOneGo.StartGame(playerList);
                    break;
                }
                
                if (response == 2)
                {
                    IGameMode takingTurns = new TakingTurnsMode();
                    takingTurns.StartGame(playerList);
                    break;
                }

                _output.InvalidGameModeSelectionMessage();
            }
        }
    }
}