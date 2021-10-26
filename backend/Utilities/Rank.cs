using System;
using System.Linq;
using System.Text;

namespace BrewController.Utilities
{
    public static class Rank
    {
        private const int StartCharCode = 32;
        private const int EndCharCode = 126;
        private const char FirstRank = '/';

        public static string Generate(string? previousRank, string? nextRank) =>
            previousRank switch
            {
                // first rank
                null when nextRank == null => FirstRank.ToString(),
                // starting rank
                null => nextRank.GetPreviousRank(),
                // ending rank or in-between rank
                _ => nextRank == null ? previousRank.GetNextRank() : GetInBetweenRank(previousRank, nextRank),
            };

        private static string GetPreviousRank(this string nextRank)
        {
            var count = nextRank.Length - 1;

            foreach (var (character, index) in nextRank.Reverse().Select((character, index) => (character, index)))
            {
                var charCode = (int)character;

                if (charCode > StartCharCode + 1)
                {
                    return $"{nextRank[..(count - index)]}{(char)(charCode - 1)}";
                }
            }

            return $"{nextRank[..(count - 1)]}{(char)StartCharCode}{(char)EndCharCode}";
        }

        private static string GetNextRank(this string previousRank)
        {
            var count = previousRank.Length - 1;

            foreach (var (character, index) in previousRank.Reverse().Select((character, index) => (character, index)))
            {
                var charCode = (int)character;

                if (charCode < EndCharCode)
                {
                    return $"{previousRank[..(count - index)]}{(char)(charCode + 1)}";
                }
            }

            return $"{previousRank}{(char)(StartCharCode + 1)}";
        }

        private static string GetInBetweenRank(string first, string second)
        {
            var flagged = false;
            var rankBuilder = new StringBuilder();

            var maxLength = Math.Max(first.Length, second.Length);

            foreach (var index in Enumerable.Range(0, maxLength))
            {
                var lower = index < first.Length ? first[index] : StartCharCode;
                var upper = index < second.Length && !flagged ? second[index] : EndCharCode;

                if (lower == upper)
                {
                    rankBuilder.Append((char)lower);
                }
                else if (upper - lower > 1)
                {
                    rankBuilder.Append((char)GetAverage(lower, upper));
                    flagged = false;
                    break;
                }
                else
                {
                    rankBuilder.Append((char)lower);
                    flagged = true;
                }
            }

            if (flagged)
            {
                rankBuilder.Append((char)GetAverage(StartCharCode, EndCharCode));
            }

            return rankBuilder.ToString();
        }

        private static int GetAverage(int first, int second) => (first + second) / 2;
    }
}
