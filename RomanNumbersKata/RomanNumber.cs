using System.Collections.Generic;

namespace RomanNumbersKata
{
    public class RomanNumber
    {
        private readonly IDictionary<int, string> _arabicToRoman;

        public RomanNumber()
        {
            _arabicToRoman = new Dictionary<int, string>
            {
                {1, "I"},
                {2, "II"},
                {3, "III"},
                {4, "IV"},
                {5, "V"},
            };
        }

        public string FromArabic(int arabic)
        {
            string romanNumeral;
            
            _arabicToRoman.TryGetValue(arabic, out romanNumeral);
            return romanNumeral;

        }
    }
}