using System.Collections.Generic;
using NUnit.Framework;
using SixLetterWordChallenge.BL;
using SixLetterWordChallenge.IBL;

namespace Tests
{
    public class BusinessLayerTests
    {
        private ILetterWords _letterWords;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _letterWords = new LetterWords();
        }

        [Test]
        public void CanFindAllCombinations()
        {
            var testData = new HashSet<string>
            {
                "a",
                "ppels",
                "ba",
                "kken",
                "appels",
                "bakken"
            };
            var allCombinations = _letterWords.GenerateCombinations(testData);
            Assert.That(allCombinations.Count, Is.EqualTo(2));
            Assert.That(allCombinations.ContainsValue("appels"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+ppels"), Is.True);
            Assert.That(allCombinations.ContainsValue("bakken"), Is.True);
            Assert.That(allCombinations.ContainsKey("ba+kken"), Is.True);
        }

        [Test]
        public void CanHandleNonExistingInputData()
        {
            var allCombinations = _letterWords.GenerateCombinations(null);
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void CanHandleEmptyInputData()
        {
            var allCombinations = _letterWords.GenerateCombinations(new HashSet<string>());
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanFindAllCombinationsOfSameWord()
        {
            var testData = new HashSet<string>
            {
                "a",
                "ppels",
                "ba",
                "kken",
                "appels",
                "bakken",
                "ap",
                "pels",
                "bak",
                "ken"
            };
            var allCombinations = _letterWords.GenerateCombinations(testData);
            Assert.That(allCombinations.Count, Is.EqualTo(4));
            Assert.That(allCombinations.ContainsValue("appels"), Is.True);
            Assert.That(allCombinations.ContainsKey("a+ppels"), Is.True);
            Assert.That(allCombinations.ContainsKey("ap+pels"), Is.True);
            Assert.That(allCombinations.ContainsValue("bakken"), Is.True);
            Assert.That(allCombinations.ContainsKey("ba+kken"), Is.True);
            Assert.That(allCombinations.ContainsKey("bak+ken"), Is.True);
        }
    }
}
