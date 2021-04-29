using System.IO;
using SixLetterWordChallenge.IDL;

namespace SixLetterWordChallenge.DL
{
    public class InputReader : IInputReader
    {
        public string ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File cannot be found.");
            }

            using var sr = new StreamReader(filePath);
            var inputFile = sr.ReadToEnd();
            return inputFile;
        }
    }
}
