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
                {10, "X"}
            };
        }

        public string FromArabic(int arabic)
        {
            string romanNumeral = string.Empty;

            if (_arabicToRoman.TryGetValue(arabic, out romanNumeral))
            {
                return romanNumeral;
            }

            if (arabic > 5)
            {
                var remainderArabic = arabic - 5;
                romanNumeral = _arabicToRoman[5];
                romanNumeral += FromArabic(remainderArabic);
                return romanNumeral;
            }

            if (arabic > 1)
            {
                var remainderArabic = arabic - 1;
                romanNumeral = _arabicToRoman[1];
                romanNumeral += FromArabic(remainderArabic);
                return romanNumeral;
            }

            return romanNumeral;

        }
    }
}