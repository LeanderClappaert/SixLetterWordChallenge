using System;
using System.IO;
using System.Linq;
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

                Console.WriteLine("Reading input.txt");
                var inputReader = new InputReader();
                var inputData = inputReader.ReadFromFile("Resources\\input.txt")?.Split(Environment.NewLine).ToList();
                Console.WriteLine("Successfully read input.txt");
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
