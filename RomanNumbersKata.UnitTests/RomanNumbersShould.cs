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
        [Test]
        public void Return_I_Given_1()
        {
            var romanNumeral = new RomanNumber().FromArabic(1);

            romanNumeral.Should().Be("I");
        }

        [Test]
        public void Return_II_Given_2()
        {
            var romanNumeral = new RomanNumber().FromArabic(2);

            romanNumeral.Should().Be("II");
        }


    }
}
