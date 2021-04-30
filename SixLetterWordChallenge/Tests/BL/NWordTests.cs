using System.Collections.Generic;
using NUnit.Framework;
using SixLetterWordChallenge.BL;
using SixLetterWordChallenge.IBL;

namespace Tests.BL
{
    public class NWordTests
    {
        private ILetterWords _letterWords;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _letterWords = new LetterWords();
        }

        [Test]
        public void CanHandleNonExistingInputData()
        {
            var allCombinations = _letterWords.GenerateNWordCombinations(null);
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanHandleEmptyInputData()
        {
            var allCombinations = _letterWords.GenerateNWordCombinations(new HashSet<string>());
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanTakeMaxWordLengthIntoAccount()
        {
            var testData = new HashSet<string>
            {
                "waytoolong",
                "ppels",
                "a",
                "pp",
                "e",
                "l",
                "s",
                "appels",
                "toolong"
            };
            var allCombinations = _letterWords.GenerateNWordCombinations(testData);
            Assert.That(allCombinations.Count, Is.EqualTo(2));
            Assert.That(allCombinations.ContainsValue("appels"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+pp+e+l+s"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+ppels"), Is.True);
        }

        [Test]
        public void CanFindAllCombinationsOfSameWord()
        {
            var testData = new HashSet<string>
            {
                "ppels",
                "a",
                "pp",
                "e",
                "l",
                "s",
                "appels"
            };
            var allCombinations = _letterWords.GenerateNWordCombinations(testData);
            Assert.That(allCombinations.Count, Is.EqualTo(2));
            Assert.That(allCombinations.ContainsValue("appels"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+pp+e+l+s"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+ppels"), Is.True);
        }
    }
}
