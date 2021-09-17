
using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGameplay
    {
        public IUserInput _userInput;
        public IOutput _output;
        private List<IPlayer> playerList = new ();
        private Validations _validations;
        
        public YatzyGameplay(IUserInput userInput, IOutput output)
        {
            _userInput = userInput;
            _output = output;
            _validations = new Validations(_userInput, _output);
        }

        public void SetUpGame()
        {
            _output.DisplayWelcomeMessage();
            
            _output.DisplayMessage("Please select the number of players:");
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

            //Number of players selected has to be greater than 0. 
            while(numberOfPlayers < 1)
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
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
                playerList.Add(new HumanPlayer(playerName, _userInput, _output));
            }

            int numberOfComputerPlayers = numberOfPlayers - numberOfHumanPlayers;
            
            for (int i = 1; i <= numberOfComputerPlayers; i++)
            {
                playerList.Add(new ComputerPlayer($"ComputerPlayer {i}", _output));
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
                    IGameMode allRoundsInOneGo = new AllRoundsInOneGoMode(_output);
                    allRoundsInOneGo.StartGame(playerList);
                    break;
                }
                
                if (response == 1)
                {
                    IGameMode takingTurns = new TakingTurnsMode(_output);
                    takingTurns.StartGame(playerList);
                    break;
                }

                _output.DisplayMessage("Invalid response. Please enter 1 or 2:");
            }
        }
    }
}