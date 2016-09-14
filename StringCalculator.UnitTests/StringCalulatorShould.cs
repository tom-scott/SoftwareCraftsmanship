/*
 * String Calculator
1.	Create a simple String calculator with a method int Add(string numbers)
2.	The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
3.	Allow the Add method to handle an unknown amount of numbers
4.	Allow the Add method to handle new lines between numbers (instead of commas).
a.	the following input is ok:  “1\n2,3”  (will equal 6)
b.	the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)
5.	Support different delimiters
1.	to change a delimiter, the beginning of the string will contain a separate line that looks like this:   “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ . The first line is optional. all existing scenarios should still be supported
2.	Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.if there are multiple negatives, show all of them in the exception message
stop here if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes.
1.	Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2
2.	Delimiters can be of any length with the following format:  “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6
3.	Allow multiple delimiters like this:  “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6.
4.	make sure you can also handle multiple delimiters with length longer than one char

 */

using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorTDD.UnitTests
{
    [TestFixture]
    public class StringCalulatorShould
    {
        private StringCalculator _stringCalculator;


        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void return_0_given_empty_string()
        {
            int calculatedValue = _stringCalculator.Calculate(string.Empty);

            calculatedValue.Should().Be(0);
        }

        [Test]
        public void return_1_given_1_string()
        {
            int calculatedValue = _stringCalculator.Calculate("1");

            calculatedValue.Should().Be(1);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,2", 4)]
        [TestCase("11,14", 25)]
        public void return_sum_given_input_string_comma_seperated(string input, int expectedSum)
        {
            int calculatedValue = _stringCalculator.Calculate(input);

            calculatedValue.Should().Be(expectedSum);
        }
        
        [Test]
        public void return_36_given_30_and_2_and_4_comma_seperated_string()
        {
            int calculatedValue = _stringCalculator.Calculate("30,2,4");

            calculatedValue.Should().Be(36);
        }

        [Test]
        public void return_10_given_5_and_5_on_new_line_seperated_string()
        {
            int calculatedValue = _stringCalculator.Calculate("5\n5");

            calculatedValue.Should().Be(10);
        }

        [Test]
        public void return_25_given_5_newline_2_comma_18_seperated_string()
        {
            int calculatedValue = _stringCalculator.Calculate("5\n2,18");

            calculatedValue.Should().Be(25);
        }

        [Test]
        public void return_8_given_4_semi_colon_4_string()
        {
            int calculatedValue = _stringCalculator.Calculate("4;4");

            calculatedValue.Should().Be(8);
        }
    }
}
