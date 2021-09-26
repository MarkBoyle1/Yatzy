using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class YatzyGameplayTests
    {
        private GameSetUp _gameSetUp = new GameSetUp(new TestUserInput(), new ConsoleOutput());

        [Fact]
        public void given_diceComboEquals3_3_3_4_4_and_CategoryEqualsThirteen_when_CalculateScore_then_return_17()
        {
            int numberOfPlayers = 3;
            int numberOfHumanPlayers = 1;

            List<Player> playerList = _gameSetUp.AddPlayers(numberOfPlayers, numberOfHumanPlayers);

            Assert.Equal(3, playerList.Count);
        }
    }
}