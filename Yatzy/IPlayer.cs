using System.Collections.Generic;

namespace Yatzy
{
    public interface IPlayer
    {
        void PlayAllRoundsInOneGo();
        void PlayOneRound();
        string PlayerName { get; }
        int TotalScore { get; }
        int GetNumberOfRemainingCategories();


    }
}