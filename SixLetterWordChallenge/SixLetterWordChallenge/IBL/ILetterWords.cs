using System.Collections.Generic;
using SixLetterWordChallenge.Domain;

namespace SixLetterWordChallenge.IBL
{
    public interface ILetterWords
    {
        Dictionary<string, string> Generate2WordCombinations(HashSet<string> inputData);
        IEnumerable<WordCombination> GenerateNWordCombinations(HashSet<string> inputData);
    }
}