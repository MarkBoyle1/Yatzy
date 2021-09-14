
using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGameplay
    {
        public IUserInput _userInput;
        private Output _output = new Output();
        private List<IPlayer> playerList = new List<IPlayer>();
        private Validations _validations = new Validations();
        
        public YatzyGameplay(IUserInput userInput)
        {
            this._userInput = userInput;
        }

        public void SetUpGame()
        {
            _output.DisplayWelcomeMessage();
            
            _output.DisplayPlayerNumberSelectionMessage();
            int numberOfPlayers = GetNumberOfPlayers();

            _output.DisplayNumberOfHumanPlayersSelectionMessage(numberOfPlayers);
            int numberOfHumanPlayers = GetNumberOfPlayers();
            
            AddPlayers(numberOfPlayers, numberOfHumanPlayers);

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

        public int GetNumberOfPlayers()
        {
             string response = _userInput.GetUserResponse();
             int numberOfPlayers = _validations.EnsureNumberIsValid(response);

            while(numberOfPlayers < 1)
            {
                _output.InvalidResponseMessage();
                response = _userInput.GetUserResponse();
                numberOfPlayers = _validations.EnsureNumberIsValid(response);
            }

            return numberOfPlayers;
        }

        public void AddPlayers(int numberOfPlayers, int numberOfHumanPlayers)
        {
            for (int i = 1; i <= numberOfHumanPlayers; i++)
            {
                string playerName = GetPlayerName(i);
                playerList.Add(new HumanPlayer(playerName));
            }

            int numberOfComputerPlayers = numberOfPlayers - numberOfHumanPlayers;
            
            for (int i = 1; i <= numberOfComputerPlayers; i++)
            {
                playerList.Add(new ComputerPlayer($"ComputerPlayer {i}"));
            }
        }

        public string GetPlayerName(int playerNumber)
        {
            _output.GetPlayerNameMessage(playerNumber);
            string response = _userInput.GetUserResponse();
            return _validations.ValidatePlayerName(response);
        }

        public void SelectGameModeForMultiplePlayers()
        {
            _output.DisplayPickGameModeMessage();

            while (true)
            {
                string gameModeResponse = _userInput.GetUserResponse();
                int response = _validations.EnsureNumberIsValid(gameModeResponse);

                if (response == 0)
                {
                    IGameMode allRoundsInOneGo = new AllRoundsInOneGoMode();
                    allRoundsInOneGo.StartGame(playerList);
                    break;
                }
                
                if (response == 1)
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