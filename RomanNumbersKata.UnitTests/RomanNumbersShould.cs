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
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        public void Return_ExpectedRomanNumeral_Given_Arabic(string expectedRomanNumeral, int arabic)
        {
            var romanNumeral = new RomanNumber().FromArabic(arabic);

            romanNumeral.Should().Be(expectedRomanNumeral);
        }
    }
}
