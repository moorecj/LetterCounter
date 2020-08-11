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
    public class InputValidationTests
    {
        [Test]
        public void InputOf0Strings_ReturnsFalse()
        {
            string output = "";
            Assert.That(InputValidation.IsValidInput(new string[0], ref output), Is.False);
        }

        [Test]
        public void InputOf0Strings_SetsOutputTo_TooFewError()
        {
            string output = "";
            InputValidation.IsValidInput(new string[0], ref output);

            Assert.That(output, Is.EqualTo(DisplayText.TooFewArgsFormattedError));
        }

        [Test]
        public void InputOfMoreThen1Strings_ReturnsFalse()
        {
            string output = "";
            Assert.That(InputValidation.IsValidInput(new string[2], ref output), Is.False);
        }

        [Test]
        public void InputOfMoreThen1Strings_SetsOutputTo_TooManyError()
        {
            string output = "";
            InputValidation.IsValidInput(new string[2], ref output);

            Assert.That(output, Is.EqualTo(DisplayText.TooManyArgsFormattedError));
        }

        [Test]
        public void InputOf1String_ReturnsTrue()
        {
            string output = "";
            Assert.That(InputValidation.IsValidInput(new string[1], ref output), Is.True);
        }
    }
}