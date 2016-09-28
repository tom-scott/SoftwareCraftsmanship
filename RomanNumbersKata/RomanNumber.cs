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
                {4, "IV"},
                {5, "V"},
                {9, "IX"},
                {10, "X"},
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
            };
        }

        public string FromArabic(int arabic)
        {
            string romanNumeral = string.Empty;

            if (_arabicToRoman.TryGetValue(arabic, out romanNumeral))
            {
                return romanNumeral;
            }


            int keyForRoman = 10;

            foreach (var arabicKey in _arabicToRoman.Keys)
            {
                if (arabic > arabicKey)
                {
                    keyForRoman = arabicKey;
                }
            }
            

            var remainderArabic = arabic - keyForRoman;
            romanNumeral = _arabicToRoman[keyForRoman];
            romanNumeral += FromArabic(remainderArabic);
            return romanNumeral;
        }
    }
}