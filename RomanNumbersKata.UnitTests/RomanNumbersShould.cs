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
        [TestCase("XX", 20)]
        [TestCase("XXX", 30)]
        [TestCase("XL", 40)]
        [TestCase("L", 50)]
        [TestCase("LX", 60)]
        [TestCase("LXX", 70)]
        [TestCase("LXXX", 80)]
        [TestCase("XC", 90)]
        [TestCase("C", 100)]
        [TestCase("CC", 200)]
        [TestCase("CCC", 300)]
        [TestCase("CD", 400)]
        [TestCase("D", 500)]
        [TestCase("DC", 600)]
        [TestCase("DCC", 700)]
        [TestCase("DCCC", 800)]
        [TestCase("CM", 900)]
        [TestCase("M", 1000)]
        [TestCase("DCCCXLVI", 846)]
        [TestCase("MCMXCIX", 1999)]
        [TestCase("MMVIII", 2008)]
        public void Return_ExpectedRomanNumeral_Given_Arabic(string expectedRomanNumeral, int arabic)
        {
            var romanNumeral = new RomanNumber().FromArabic(arabic);

            romanNumeral.Should().Be(expectedRomanNumeral);
        }
    }
}
