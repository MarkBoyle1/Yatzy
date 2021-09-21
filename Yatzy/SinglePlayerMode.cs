using System.Collections.Generic;

namespace Yatzy
{
    public class SinglePlayerMode : IGameMode
    {
        public void StartGame(List<Player> playerList, Dealer dealer)
        {
            while (playerList[0].RemainingCategories.Count > 0)
            {
                dealer.PlayOneRound(playerList[0]);
            }
        }
    }
}