using System.Collections.Generic;

namespace Yatzy
{
    public interface IGameMode
    {
        void StartGame(List<Player> playerList, Dealer dealer);
    }
}