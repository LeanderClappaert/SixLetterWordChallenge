namespace SixLetterWordChallenge.Domain
{
    public class WordCombination
    {
        public string NWord { get; set; }
        public string Combination { get; set; }

        public WordCombination(string nWord, string combination)
        {
            NWord = nWord;
            Combination = combination;
        }

        public override string ToString()
        {
            return $"{Combination}={NWord}";
        }
    }
}
