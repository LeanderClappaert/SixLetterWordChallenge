using System.Collections.Generic;
using NUnit.Framework;
using SixLetterWordChallenge.BL;

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
            var testData = new List<string>
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
            Assert.That(allCombinations.ContainsKey("appels"), Is.True);
            Assert.That(allCombinations.ContainsValue("a+ppels"), Is.True);
            Assert.That(allCombinations.ContainsKey("bakken"), Is.True);
            Assert.That(allCombinations.ContainsValue("ba+kken"), Is.True);
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
            var allCombinations = _letterWords.GenerateCombinations(new List<string>());
            Assert.That(allCombinations.Count, Is.EqualTo(0));
        }
    }
}
