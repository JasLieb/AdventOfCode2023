using AdventOfCore2023.Tests;
using FluentAssertions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class GameCounterTests
    {
        private GameCounter _gameCounter = new();

        [TestMethod]
        public void ShouldCountEachColor()
        {
            var game = _gameCounter.GetResult("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
            game.Id.Should().Be(1);

            var turnColorCount = game.Turns.ElementAt(0);
            turnColorCount["red"].Should().Be(4);
            turnColorCount["green"].Should().Be(0);
            turnColorCount["blue"].Should().Be(3);

            turnColorCount = game.Turns.ElementAt(1);
            turnColorCount["red"].Should().Be(1);
            turnColorCount["green"].Should().Be(2);
            turnColorCount["blue"].Should().Be(6);

            turnColorCount = game.Turns.ElementAt(2);
            turnColorCount["red"].Should().Be(0);
            turnColorCount["green"].Should().Be(2);
            turnColorCount["blue"].Should().Be(0);
        }

        [TestMethod]
        public void ShouldCountMinimalBag()
        {
            var minimalBag = _gameCounter.GetResult("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green").MinimalBag;
            minimalBag["red"].Should().Be(6);
            minimalBag["green"].Should().Be(3);
            minimalBag["blue"].Should().Be(2);

            minimalBag.Power.Should().Be(36);
        }

        [TestMethod]
        public void ShouldBeValid()
        {
            var game = _gameCounter.GetResult("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
            _gameCounter.IsValidGame(game).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldBeValidIfAllTurnsAreValids()
        {
            var game = _gameCounter.GetResult("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 10 green, 10 blue, 10 red");
            _gameCounter.IsValidGame(game).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldBeInvalid()
        {
            var game = _gameCounter.GetResult("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
            _gameCounter.IsValidGame(game).Should().BeFalse();
        }

        [TestMethod]
        [Ignore("no spoil")]
        public void ShouldAnswerTheQuestionPartOne() 
        {
            var sumIdValidGames = 0;
            foreach(var rawGame in GamesResults.RawGamesResults)
            {
                var game = _gameCounter.GetResult(rawGame);
                if (_gameCounter.IsValidGame(game))
                    sumIdValidGames += game.Id;
            }
            sumIdValidGames.Should().Be(0);
        }

        [TestMethod]
        public void ShouldAnswerTheQuestionPartTwo()
        {
            var sumPowerGames = 0;
            foreach (var rawGame in GamesResults.RawGamesResults)
            {
                var game = _gameCounter.GetResult(rawGame);
                sumPowerGames += game.MinimalBag.Power;
            }
            sumPowerGames.Should().Be(0);
        }
    }
}
