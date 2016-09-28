using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RomanNumbersKata.UnitTests
{
    [TestFixture]
    public class RomanNumbersShould
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        public void Return_ExpectedRomanNumeral_Given_Arabic(string expectedRomanNumeral, int arabic)
        {
            var romanNumeral = new RomanNumber().FromArabic(arabic);

            romanNumeral.Should().Be(expectedRomanNumeral);
        }

        [Test]
        public void Return_IV_Given_4()
        {
            var romanNumeral = new RomanNumber().FromArabic(4);

            romanNumeral.Should().Be("IV");
        }
    }
}
