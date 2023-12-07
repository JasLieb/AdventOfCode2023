
using System.Text.RegularExpressions;

namespace AdventCode2023
{
    public class NumberReader
    {
        private const string BaseRegexPattern = "([0-9]|one|two|three|four|five|six|seven|eight|nine)";
        private string _regexFirstPattern = $"{BaseRegexPattern}";
        private string _regexLastPattern = $"{BaseRegexPattern}";

        public int Parse(string analyzed)
        {
            var (firstIntMatch, lastIntMatch) = ExtractFirstAndLast(analyzed);
            var parsedFirstInt = ConvertLitteral(firstIntMatch);
            var parsedLastInt = ConvertLitteral(lastIntMatch);

            return int.Parse($"{parsedFirstInt}{parsedLastInt}");
        }

        private string ConvertLitteral(string intMatch) =>
            intMatch switch
            {
                "one" => "1",
                "two" => "2",
                "three" => "3",
                "four" => "4",
                "five" => "5",
                "six" => "6",
                "seven" => "7",
                "eight" => "8",
                "nine" => "9",
                _ => intMatch
            };

        private (string firstIntMatch, string lastIntMatch) ExtractFirstAndLast(string analyzed) =>
            (
                Regex.Match(analyzed, _regexFirstPattern).Captures.First().Value,
                Regex.Match(analyzed, _regexLastPattern, RegexOptions.RightToLeft).Captures.First().Value
            );
    }
}
