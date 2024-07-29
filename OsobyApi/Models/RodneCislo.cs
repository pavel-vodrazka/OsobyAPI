using System;

namespace OsobyApi.Models
{
    public class RodneCislo
    {
        public static (bool result, DateTime birthDate) IsValid(string input)
        {
            int inputLength = input.Length;
            decimal firstNine;
            decimal modulo;
            decimal last;
            int yearPart, monthPart, dayPart;
            int year, month, day;
            DateTime birthDate;

            (bool, DateTime) falseResult = (false, DateTime.MinValue);

            if (!decimal.TryParse(input, out decimal throwOut))
                return (false, DateTime.MinValue);

            if (inputLength < 9 && inputLength > 10)
                return falseResult;

            // Check digit for birth numbers since 1954
            if (inputLength == 10)
            {
                firstNine = decimal.Parse(input.Substring(0, 9));
                last = decimal.Parse(input.Substring(9));
                modulo = firstNine % 11;

                // Exception
                if (modulo == 10)
                {
                    if (last != 0)
                        return falseResult;
                }
                else
                {
                    if (modulo != last)
                        return falseResult;
                }
            }

            yearPart = int.Parse(input.Substring(0, 2));

            if (inputLength == 10)
            {
                if (yearPart < 54)
                    year = 2000 + yearPart;
                else
                    year = 1900 + yearPart;
            }
            else
            {
                if (yearPart < 54)
                    year = 1900 + yearPart;
                else
                    year = 1800 + yearPart;
            }

            monthPart = int.Parse(input.Substring(2, 2));

            if (monthPart > 70)
                month = monthPart - 70;
            else if (monthPart > 50)
                month = monthPart - 50;
            else if (monthPart > 20)
                month = monthPart - 20;
            else
                month = monthPart;

            dayPart = int.Parse(input.Substring(4, 2));

            day = dayPart;

            try
            {
                birthDate = new DateTime(year, month, day);
            }
            catch
            {
                return falseResult;
            }

            return (true, birthDate);
        }
    }
}