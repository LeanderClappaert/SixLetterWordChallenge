using System.Collections.Generic;

namespace SixLetterWordChallenge.IBL
{
    public interface ILetterWords
    {
        Dictionary<string, string> Generate2WordCombinations(HashSet<string> inputData);
        Dictionary<string, string> GenerateNWordCombinations(HashSet<string> inputData);
    }
}