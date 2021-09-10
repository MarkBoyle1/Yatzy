
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

        public int GetNumberOfPlayers()
        {
            _output.DisplayPlayerNumberSelectionMessage();
            int numberOfPlayers = _userInput.GetUserResponse();

            while(numberOfPlayers < 1)
            {
                _output.PleaseEnterValidNumberMessage();
                numberOfPlayers = _userInput.GetUserResponse();
            }

            return numberOfPlayers;
        }
        
        public void AddPlayers(int numberOfPlayers)
        {
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                string playerName = GetPlayerName(i);
                playerList.Add(new HumanPlayer(playerName));
            }
        }

        public string GetPlayerName(int playerNumber)
        {
            _output.GetPlayerNameMessage(playerNumber);
            return _userInput.GetPlayerName();
        }

        public void SetUpGame()
        {
            int numberOfPlayers = GetNumberOfPlayers();
            AddPlayers(numberOfPlayers);

            if (numberOfPlayers == 1)
            {
                IGameMode singlePlayer = new SinglePlayerMode();
                singlePlayer.StartGame(playerList);
            }
            else
            {
                SelectGameModeForMultiplePlayers();
            }
        }

        public void SelectGameModeForMultiplePlayers()
        {
            _output.DisplayPickGameModeMessage();

            while (true)
            {
                int response = _userInput.GetUserResponse();

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