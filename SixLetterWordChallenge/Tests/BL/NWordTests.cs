using System.Collections.Generic;
using System.Linq;
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
            var allCombinations = _letterWords.GenerateNWordCombinations(null)?.ToList();
            Assert.That(allCombinations, Is.Not.Null);
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanHandleEmptyInputData()
        {
            var allCombinations = _letterWords.GenerateNWordCombinations(new HashSet<string>())?.ToList();
            Assert.That(allCombinations, Is.Not.Null);
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
            var allCombinations = _letterWords.GenerateNWordCombinations(testData)?.ToList();
            Assert.That(allCombinations, Is.Not.Null);
            Assert.That(allCombinations.Count, Is.EqualTo(2));
            Assert.That(allCombinations.Any(x => x.NWord.Equals("appels")), Is.True);
            Assert.That(allCombinations.Any(x => x.Combination.Equals("a+pp+e+l+s")), Is.True);
            Assert.That(allCombinations.Any(x => x.Combination.Equals("a+ppels")), Is.True);
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
            var allCombinations = _letterWords.GenerateNWordCombinations(testData)?.ToList();
            Assert.That(allCombinations, Is.Not.Null);
            Assert.That(allCombinations.Count, Is.EqualTo(2));
            Assert.That(allCombinations.Any(x => x.NWord.Equals("appels")), Is.True);
            Assert.That(allCombinations.Any(x => x.Combination.Equals("a+pp+e+l+s")), Is.True);
            Assert.That(allCombinations.Any(x => x.Combination.Equals("a+ppels")), Is.True);
        }
    }
}
