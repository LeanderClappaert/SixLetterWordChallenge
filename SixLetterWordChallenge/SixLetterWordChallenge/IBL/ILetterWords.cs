using System.Collections.Generic;

namespace SixLetterWordChallenge.IBL
{
    public interface ILetterWords
    {
        Dictionary<string, string> GenerateCombinations(HashSet<string> inputData);
    }
}