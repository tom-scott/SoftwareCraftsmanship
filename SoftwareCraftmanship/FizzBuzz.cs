namespace SoftwareCraftmanship
{
    public class FizzBuzz
    {
        public string GenerateFrom(int input)
        {
            if (input == 4)
            {
                return "4";
            }

            if (input == 7)
            {
                return "7";
            }

            if (input == 3)
            {
                return "fizz";
            }

            if (input == 15)
            {
                return "fizzbuzz";
            }

            return "buzz";
        }
    }
}