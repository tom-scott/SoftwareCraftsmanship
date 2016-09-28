namespace RomanNumbersKata
{
    public class RomanNumber
    {
        public string FromArabic(int arabic)
        {
            var romanNumeral = "I";
            if (arabic >= 2)
            {
                romanNumeral += "I";
            }
            if (arabic >= 3)
            {
                romanNumeral += "I";
            }
            return romanNumeral;

        }
    }
}