using System;
using System.Collections.Generic;
using System.Linq;
using SixLetterWordChallenge.IBL;

namespace SixLetterWordChallenge.BL
{
    public class LetterWords : ILetterWords
    {
        private readonly int _maxWordLength;

        public LetterWords(int maxWordLength = 6)
        {
            _maxWordLength = maxWordLength;
        }

        public Dictionary<string, string> Generate2WordCombinations(HashSet<string> inputData)
        {
            if (inputData == null || inputData.Count == 0)
            {
                return new Dictionary<string, string>();
            }

            inputData = inputData.Where(x => !string.IsNullOrWhiteSpace(x) && x.Length <= _maxWordLength).ToHashSet();
            var allNLetterWords = inputData.Where(x => x.Length == _maxWordLength).ToHashSet();

            var allOtherLetterWords = inputData.Where(x => !allNLetterWords.Contains(x)).ToHashSet();
            return Get2WordCombinations(allOtherLetterWords, allNLetterWords);
        }

        private Dictionary<string, string> Get2WordCombinations(IReadOnlyCollection<string> inputData, IReadOnlySet<string> allNLetterWords)
        {
            var resultSet = new Dictionary<string, string>();

            foreach (var baseWord in inputData)
            {
                foreach (var otherWord in inputData)
                {
                    if (baseWord.Equals(otherWord, StringComparison.CurrentCultureIgnoreCase)) continue;
                    var tempCombination = $"{baseWord}+{otherWord}";
                    var tempResult = baseWord + otherWord;
                    if (tempResult.Length == _maxWordLength)
                    {
                        if (resultSet.ContainsKey(tempCombination)) continue;
                        if (!allNLetterWords.Contains(tempResult)) continue;
                        resultSet.Add($"{baseWord}+{otherWord}", tempResult);
                    }
                }
            }

            return resultSet;
        }

        public Dictionary<string, string> GenerateNWordCombinations(HashSet<string> inputData)
        {
            if (inputData == null || inputData.Count == 0)
            {
                return new Dictionary<string, string>();
            }

            inputData = inputData.Where(x => !string.IsNullOrWhiteSpace(x) && x.Length <= _maxWordLength).ToHashSet();
            var allNLetterWords = inputData.Where(x => x.Length == _maxWordLength).ToList();
            var allOtherLetterWords = inputData.Where(x => !allNLetterWords.Contains(x)).ToList();
            var result = GetAllNWordCombinations(allOtherLetterWords);
            return GetAllNWordMatches(allNLetterWords, result);
        }

        private static Dictionary<string, string> GetAllNWordMatches(IEnumerable<string> allNLetterWords, IEnumerable<string> combinations)
        {
            var resultSet = new Dictionary<string, string>();
            var partialCombinations = combinations.ToHashSet();
            foreach (var nLetterWord in allNLetterWords)
            {
                foreach (var combination in partialCombinations.Where(combination => !resultSet.ContainsKey(combination)).Where(combination => combination.Replace("+", "").Equals(nLetterWord)))
                {
                    resultSet.Add(combination, nLetterWord);
                }
            }

            return resultSet;
        }

        public IEnumerable<string> GetAllNWordCombinations(IReadOnlyList<string> allNLetterWords)
        {
            var combinations = new HashSet<string>();
            for (var i = 0; i < allNLetterWords.Count; i++)
            {
                combinations.UnionWith(GetCombinationsForWord(allNLetterWords, allNLetterWords[i], allNLetterWords[i], i));
            }

            return combinations;
        }

        private IEnumerable<string> GetCombinationsForWord(IReadOnlyList<string> allNLetterWords, string currentWord, string currentCombination, int pointer)
        {
            var combinations = new HashSet<string>();

            for (var i = 0; i < allNLetterWords.Count; i++)
            {
                if (i == pointer) continue;
                var combinationWord = allNLetterWords[i];
                var tempCombination = $"{currentCombination}+{combinationWord}";
                var tempResult = currentWord + combinationWord;

                if (tempResult.Length > _maxWordLength)
                {
                    continue;
                }
                else if (tempResult.Length == _maxWordLength)
                {
                    combinations.Add(tempCombination);
                }
                else
                {
                    combinations.UnionWith(GetCombinationsForWord(allNLetterWords, tempResult, tempCombination, i));
                }
            }

            return combinations;
        }
    }
}
