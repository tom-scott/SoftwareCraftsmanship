using System;
using System.Linq;

namespace StringCalculatorTDD
{
    public class StringCalculator
    {
        public int Calculate(string input)
        {
            if (input == string.Empty)
                return 0;

            var arguments = input.Split(',', '\n');
            
            return arguments.Select(int.Parse).Sum();
        }
    }
}