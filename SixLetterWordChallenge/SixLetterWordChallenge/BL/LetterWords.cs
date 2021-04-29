using System;
using System.Collections.Generic;
using System.Linq;

namespace SixLetterWordChallenge.BL
{
    public class LetterWords : ILetterWords
    {
        private const int MaxWordLength = 6;
        private const int NumberOfWords = 2;

        public Dictionary<string, string> GenerateCombinations(List<string> inputData)
        {
            if (inputData == null || inputData.Count == 0)
            {
                return new Dictionary<string, string>();
            }

            inputData = inputData.Where(x => !string.IsNullOrWhiteSpace(x) && x.Length <= MaxWordLength).ToList();
            var allSixLetterWords = inputData.Where(x => x.Length == MaxWordLength).ToList();

            var allOtherLetterWords = inputData.Where(x => !allSixLetterWords.Contains(x)).ToList();
            return GetAllCombinations(allOtherLetterWords, allSixLetterWords);
        }

        private static Dictionary<string, string> GetAllCombinations(List<string> inputData, List<string> allSixLetterWords)
        {
            var resultSet = new Dictionary<string, string>();

            foreach (var baseWord in inputData)
            {
                foreach (var otherWord in inputData)
                {
                    if (baseWord.Equals(otherWord, StringComparison.CurrentCultureIgnoreCase)) continue;
                    var tempResult = baseWord + otherWord;
                    if (tempResult.Length == MaxWordLength)
                    {
                        if (resultSet.ContainsKey(tempResult)) continue;
                        if (!allSixLetterWords.Contains(tempResult)) continue;
                        resultSet.Add(tempResult, $"{baseWord}+{otherWord}");
                    }
                }
            }

            return resultSet;
        }
    }

    public interface ILetterWords
    {
        Dictionary<string, string> GenerateCombinations(List<string> inputData);
    }
}
