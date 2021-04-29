using System;
using System.Collections.Generic;
using System.Linq;
using SixLetterWordChallenge.IBL;

namespace SixLetterWordChallenge.BL
{
    public class LetterWords : ILetterWords
    {
        private const int MaxWordLength = 6;
        private const int NumberOfWords = 2;

        public Dictionary<string, string> GenerateCombinations(HashSet<string> inputData)
        {
            if (inputData == null || inputData.Count == 0)
            {
                return new Dictionary<string, string>();
            }

            inputData = inputData.Where(x => !string.IsNullOrWhiteSpace(x) && x.Length <= MaxWordLength).ToHashSet();
            var allSixLetterWords = inputData.Where(x => x.Length == MaxWordLength).ToHashSet();

            var allOtherLetterWords = inputData.Where(x => !allSixLetterWords.Contains(x)).ToHashSet();
            return GetAllCombinations(allOtherLetterWords, allSixLetterWords);
        }

        private static Dictionary<string, string> GetAllCombinations(IReadOnlyCollection<string> inputData, IReadOnlySet<string> allSixLetterWords)
        {
            var resultSet = new Dictionary<string, string>();

            foreach (var baseWord in inputData)
            {
                foreach (var otherWord in inputData)
                {
                    if (baseWord.Equals(otherWord, StringComparison.CurrentCultureIgnoreCase)) continue;
                    var tempCombination = $"{baseWord}+{otherWord}";
                    var tempResult = baseWord + otherWord;
                    if (tempResult.Length == MaxWordLength)
                    {
                        if (resultSet.ContainsKey(tempCombination)) continue;
                        if (!allSixLetterWords.Contains(tempResult)) continue;
                        resultSet.Add($"{baseWord}+{otherWord}", tempResult);
                    }
                }
            }

            return resultSet;
        }
    }
}
