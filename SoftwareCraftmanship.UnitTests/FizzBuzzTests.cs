using NUnit.Framework;

namespace SoftwareCraftmanship.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzbuzz;

        [SetUp]
        public void Setup()
        {
            _fizzbuzz = new FizzBuzz();
        }

        [Test]
        public void Print_Fizz_Given_Input_Is_3()
        {
            var input = 3;

            var output = _fizzbuzz.GenerateFrom(input);

            Assert.That(output, Is.EqualTo("fizz"));
        }

        [Test]
        public void Print_Buzz_Given_Input_Is_5()
        {
            var input = 5;

            var output = _fizzbuzz.GenerateFrom(input);

            Assert.That(output, Is.EqualTo("buzz"));
        }

        [Test]
        public void Print_FizzBuzz_Given_Input_Is_15()
        {
            var input = 15;

            var output = _fizzbuzz.GenerateFrom(input);

            Assert.That(output, Is.EqualTo("fizzbuzz"));
        }

        [Test]
        public void Print_Fizz_Given_Input_Is_9()
        {
            var input = 9;

            var output = _fizzbuzz.GenerateFrom(input);

            Assert.That(output, Is.EqualTo("fizz"));
        }

        [TestCase(4, "4")]
        [TestCase(7, "7")]
        public void Print_StringRepresentation_Given_Non_FizzBuzz_Input(int input, string expectedOutput)
        {
            var output = _fizzbuzz.GenerateFrom(input);

            Assert.That(output, Is.EqualTo(expectedOutput));
        }
    }
}
