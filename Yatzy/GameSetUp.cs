using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class GameSetUp
    {
        public IUserInput _userInput;
        public IOutput _output;
        private List<Player> playerList = new ();
        private Dealer _dealer;
        
        public GameSetUp(IUserInput userInput, IOutput output)
        {
            _userInput = userInput;
            _output = output;
            _dealer = new Dealer(_output, userInput);
        }

        public void SetUpGame()
        {
            _output.DisplayWelcomeMessage();
            
            _output.DisplayMessage("Please select the number of players:");
            int numberOfPlayers = GetNumberOfPlayers();

            _output.DisplayNumberOfHumanPlayersSelectionMessage(numberOfPlayers);
            int numberOfHumanPlayers = GetNumberOfPlayers();

            while (numberOfHumanPlayers > numberOfPlayers)
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
                numberOfHumanPlayers = GetNumberOfPlayers();
            }
            
            AddPlayers(numberOfPlayers, numberOfHumanPlayers);
            

            if (numberOfPlayers == 1)
            {
                IGameMode singlePlayer = new SinglePlayerMode();
                singlePlayer.StartGame(playerList, _dealer);
            }
            else
            {
                SelectGameModeForMultiplePlayers();
            }
        }

        public int GetNumberOfPlayers()
        {
             string response = _userInput.GetUserResponse();
             int numberOfPlayers = EnsureNumberIsValid(response);

            //Number of players selected has to be greater than 0. 
            while(numberOfPlayers < 1)
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
                response = _userInput.GetUserResponse();
                numberOfPlayers = EnsureNumberIsValid(response);
            }

            return numberOfPlayers;
        }

        public void AddPlayers(int numberOfPlayers, int numberOfHumanPlayers)
        {
            for (int i = 1; i <= numberOfHumanPlayers; i++)
            {
                string playerName = GetPlayerName(i);
                playerList.Add(new Player(playerName, "human"));
            }

            int numberOfComputerPlayers = numberOfPlayers - numberOfHumanPlayers;
            
            for (int i = 1; i <= numberOfComputerPlayers; i++)
            {
                playerList.Add(new Player($"ComputerPlayer {i}", "computer"));
            }
        }

        public string GetPlayerName(int playerNumber)
        {
            _output.GetPlayerNameMessage(playerNumber);
            string response = _userInput.GetUserResponse();
            
            while(String.IsNullOrWhiteSpace(response))
            {
                _output.DisplayMessage("Please enter a response:");
                response = Console.ReadLine();
            }
            
            return response;
        }

        public void SelectGameModeForMultiplePlayers()
        {
            _output.DisplayPickGameModeMessage();

            while (true)
            {
                string gameModeResponse = _userInput.GetUserResponse();
                int response = EnsureNumberIsValid(gameModeResponse);

                if (response == 0)
                {
                    IGameMode allRoundsInOneGo = new AllRoundsInOneGoMode(_output);
                    allRoundsInOneGo.StartGame(playerList, _dealer);
                    break;
                }
                
                if (response == 1)
                {
                    IGameMode takingTurns = new TakingTurnsMode(_output);
                    takingTurns.StartGame(playerList, _dealer);
                    break;
                }

                _output.DisplayMessage("Invalid response. Please enter 1 or 2:");
            }
        }
        
        private int EnsureNumberIsValid(string response)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                _output.DisplayMessage("Invalid response. Please enter a valid number:");
                response = _userInput.GetUserResponse();
            }

            return Convert.ToInt32(response);
        }
    }
}