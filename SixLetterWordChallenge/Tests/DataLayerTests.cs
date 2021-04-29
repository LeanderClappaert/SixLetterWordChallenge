using System.IO;
using NUnit.Framework;
using SixLetterWordChallenge.DL;
using SixLetterWordChallenge.IDL;

namespace Tests
{
    public class DataLayerTests
    {
        private IInputReader _inputReader;
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _inputReader = new InputReader();
        }

        [Test]
        public void CanReadFile()
        {
            var fileContent = _inputReader.ReadFromFile("Resources\\input.txt");
            Assert.That(string.IsNullOrEmpty(fileContent), Is.False);
        }

        [Test]
        public void CanHandleNonExistinFile()
        {
            Assert.Throws<FileNotFoundException>(() => _inputReader.ReadFromFile("Resources\\pear.txt"));
        }
    }
}