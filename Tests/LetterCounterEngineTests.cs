using LetterCounter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class LetterCounterEngineTests
    {
        private LetterCounterEngine letterCounterEngine;

        [SetUp]
        public void Setup()
        {
            letterCounterEngine = new LetterCounterEngine();
        }

        [Test]
        public void BlankString_ReturnsEmptyDictionary()
        {
            var letterCounts = letterCounterEngine.GetLetteCounts("");

            Assert.That(letterCounts.CountBreakdown, Is.Empty);
        }

        [Test]
        public void NullString_ReturnsEmptyDictionary()
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(null);

            Assert.That(letterCounts.CountBreakdown, Is.Empty);
        }

        [Test]
        public void ASingleLetterString_DictionartyWith1Entry()
        {
            var letterCounts = letterCounterEngine.GetLetteCounts("a");
            KeyValuePair<char, int> expectedResult = new KeyValuePair<char, int>('A', 1);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(1));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedResult));
        }

        [Test]
        public void NonLetterCharacters_DoNotGetCounted()
        {
            var letterCounts = letterCounterEngine.GetLetteCounts("a!!@@  #$%123<>`");
            KeyValuePair<char, int> expectedResult = new KeyValuePair<char, int>('A', 1);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(1));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedResult));
        }

        [TestCase("a")]
        [TestCase("b")]
        [TestCase("c")]
        [TestCase("d")]
        [TestCase("e")]
        [TestCase("abcde")]
        [TestCase("aBcDe")]
        public void LowerCaseInput_ResultIsAlwasUpperCase(string input)
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(input);

            foreach (var kvp in letterCounts.CountBreakdown)
            {
                Assert.That(char.IsUpper(kvp.Key) == true);
            }
        }

        [TestCase("a", 1, 'A')]
        [TestCase("aa", 2, 'A')]
        [TestCase("aaa", 3, 'A')]
        [TestCase("aaaa", 4, 'A')]
        [TestCase("bbbb", 4, 'B')]
        [TestCase("cccc", 4, 'C')]
        public void MultipleEntriesForASingleLetter_ReturnsDictionartyWith1Entry(string input, int resultCount, char resultChar)
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(input);

            KeyValuePair<char, int> expectedResult = new KeyValuePair<char, int>(resultChar, resultCount);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(1));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedResult));
        }

        [TestCase("a", 1)]
        [TestCase("ab", 2)]
        [TestCase("abc", 3)]
        [TestCase("abcd", 4)]
        [TestCase("aabbcccddddd", 4)]
        public void MultipleDistinceLetters_CreateEntryForEachInDictionary(string input, int resultSetsExpectedCount)
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(input);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(resultSetsExpectedCount));
        }

        [TestCase("aA", 2, 'A')]
        [TestCase("aa", 2, 'A')]
        [TestCase("AAA", 3, 'A')]
        [TestCase("aAaA", 4, 'A')]
        public void CountUppperAndLowerAsTheSame(string input, int expectedResultCount, char resultChar)
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(input);

            KeyValuePair<char, int> expectedResult = new KeyValuePair<char, int>(resultChar, expectedResultCount);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(1));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedResult));
        }

        [TestCase("****a", 1)]
        [TestCase("****ab", 2)]
        [TestCase("****abc", 3)]
        [TestCase("****abcd", 4)]
        public void TotalOnlyCountsLetters(string input, int expectedTotalLetters)
        {
            var letterCounts = letterCounterEngine.GetLetteCounts(input);

            Assert.That(letterCounts.TotalLetters, Is.EqualTo(expectedTotalLetters));
        }

        [Test]
        public void CanGetLetterCountsFromMixedString()
        {
            var letterCounts = letterCounterEngine.GetLetteCounts("!!!     aA bb ccc!!!! dDdd &&&& 1234 E");
            KeyValuePair<char, int> expectedAResult = new KeyValuePair<char, int>('A', 2);
            KeyValuePair<char, int> expectedBResult = new KeyValuePair<char, int>('B', 2);
            KeyValuePair<char, int> expectedCResult = new KeyValuePair<char, int>('C', 3);
            KeyValuePair<char, int> expectedDResult = new KeyValuePair<char, int>('D', 4);
            KeyValuePair<char, int> expectedEResult = new KeyValuePair<char, int>('E', 1);

            Assert.That(letterCounts.CountBreakdown.Count, Is.EqualTo(5));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedAResult));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedBResult));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedCResult));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedDResult));
            Assert.That(letterCounts.CountBreakdown, Contains.Item(expectedEResult));

            Assert.That(letterCounts.TotalLetters, Is.EqualTo(12));
        }
    }
}