namespace RomanNumbersKata
{
    public class RomanNumber
    {
        public string FromArabic(int arabic)
        {
            if (arabic == 2)
            {
                return "II";
            }

            return "I";

        }
    }
}