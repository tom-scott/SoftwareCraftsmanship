namespace RomanNumbersKata
{
    public class RomanNumber
    {
        public string FromArabic(int arabic)
        {
            var romanNumeral = "I";
            if (arabic == 2)
            {
                romanNumeral += romanNumeral;
            }
            return romanNumeral;

        }
    }
}