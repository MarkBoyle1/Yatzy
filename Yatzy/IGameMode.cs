using System.Collections.Generic;

namespace Yatzy
{
    public interface IGameMode
    {
        void StartGame(List<IPlayer> playerList);
    }
}