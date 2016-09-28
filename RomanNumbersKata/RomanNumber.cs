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
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
                { 1000, "M" },
            };
        }

        public string FromArabic(int arabic)
        {
            var romanNumeral = string.Empty;

            var remainderArabic = arabic;
            while (remainderArabic > 0)
            {
                var keyForRoman = 0;
                foreach (var arabicKey in _arabicToRoman.Keys)
                {
                    if (remainderArabic >= arabicKey)
                    {
                        keyForRoman = arabicKey;
                    }
                }

                remainderArabic = remainderArabic - keyForRoman;
                romanNumeral = romanNumeral + _arabicToRoman[keyForRoman];
            }

            return romanNumeral;
        }
    }
}