using AdventOfCode2023.Core;
using System.Linq;

namespace AdventCode2023
{
    public class GameCounter
    {
        public GameColorCount GetResult(string gameState)
        {
            var split = gameState.Split(":");
            var id = int.Parse(split.ElementAt(0).Split(" ").ElementAt(1));
            var rawTurnResults = split.ElementAt(1).Split(new[] { ";" }, StringSplitOptions.TrimEntries);
            var turns = ExtractColorCount(rawTurnResults);
            var minimalBag = GetMinimalBag(turns);

            return new (id, minimalBag, turns);
        }

        private TurnColorCount GetMinimalBag(IEnumerable<TurnColorCount> turnCounts)
        {
            var getMax = (string color) => turnCounts.Select(turn => turn[color]).Max();
            var minimalBag = new TurnColorCount();
            foreach (var color in new[] { "red", "green", "blue" })
            {
                minimalBag[color] = getMax(color);
            }
            return minimalBag;
        }

        public bool IsValidGame(GameColorCount gameColorCount)
        {
            foreach(var turn in gameColorCount.Turns)
            {
                var max = GetMaxColorCount();
                foreach (var key in new[] { "red", "green", "blue" })
                {
                    if (max[key] < turn[key])
                        return false;
                }
            }
            return true;
        }

        private TurnColorCount GetMaxColorCount()
        {
            var max = new TurnColorCount();
            max["red"] = 12;
            max["green"] = 13;
            max["blue"] = 14;
            return max;
        }

        private IEnumerable<TurnColorCount> ExtractColorCount(string[] rawTurnResults)
        {
            return rawTurnResults.Aggregate(
                new List<TurnColorCount>(),
                ParseColorResult
            );
        }

        private static List<TurnColorCount> ParseColorResult(List<TurnColorCount> seed, string turnResult)
        {
            var colorResults = turnResult.Split(new[] { "," }, StringSplitOptions.TrimEntries);
            seed.Add(AnaluzeTurn(colorResults));
            return seed;
        }

        private static TurnColorCount AnaluzeTurn(IEnumerable<string> colorResults)
        {
            var turn = new TurnColorCount();
            foreach (var colorResult in colorResults)
            {
                var split = colorResult.Trim().Split(" ");
                turn[split[1]] = int.Parse(split[0]);
            }
            return turn;
        }
    }
}
