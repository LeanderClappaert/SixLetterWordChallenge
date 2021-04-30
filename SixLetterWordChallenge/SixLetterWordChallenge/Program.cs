using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SixLetterWordChallenge.BL;
using SixLetterWordChallenge.DL;

namespace SixLetterWordChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the 6 letter word challenge program!");

                Console.WriteLine("Reading input.txt...");
                var inputReader = new InputReader();
                var inputData = inputReader.ReadFromFile("Resources\\input.txt")?.Split(Environment.NewLine).ToHashSet();
                Console.WriteLine("Successfully read input.txt.");

                Console.WriteLine("Calculating combinations...");
                var letterWords = new LetterWords();

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var allCombinations = letterWords.Generate2WordCombinations(inputData);
                stopWatch.Stop();

                Console.WriteLine($"Found {allCombinations.Count} 2-word combinations in {stopWatch.Elapsed}");

                stopWatch.Reset();
                stopWatch.Start();
                var allCombinationsV3 = letterWords.GenerateNWordCombinations(inputData);
                stopWatch.Stop();
                Console.WriteLine($"Found {allCombinationsV3.Count} n-word combinations in {stopWatch.Elapsed}");
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine(fnfEx);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"The file could not be read: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something unexpected happended during the execution of this program:{Environment.NewLine}{ex}");
            }

            Console.ReadLine();
        }
    }
}
