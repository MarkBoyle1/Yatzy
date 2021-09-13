using System.Collections.Generic;

namespace Yatzy
{
    public class SinglePlayerMode : IGameMode
    {
        public void StartGame(List<IPlayer> playerList)
        {
            playerList[0].PlayAllRoundsInOneGo();
        }
    }
}