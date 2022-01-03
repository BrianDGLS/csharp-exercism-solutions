using System;
using System.Collections.Generic;
using System.Linq;

public static class Say
{
    private static IDictionary<long, string> namedNumbers = new Dictionary<long, string>()
    {
        { 0, "zero" },
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" },
        { 10, "ten" },
        { 11, "eleven" },
        { 12, "twelve" },
        { 20, "twenty" },
        { 30, "thirty" },
        { 40, "forty" },
        { 50, "fifty" },
        { 60, "sixty" },
        { 70, "seventy" },
        { 80, "eighty" },
        { 90, "ninety" },
    };

    private static string[] numberSuffixes = new string[]
    {
        "",
        "",
        "thousand",
        "million",
        "billion",
        "trillion"
    };

    public static string InEnglish(long number)
    {
        if(number < 0 || number > 999_999_999_999)
        {
            throw new ArgumentOutOfRangeException(nameof(number));
        }
        
        List<int> groups = GetNumberGroups(number);
        if (groups.Count == 1)
        {
            return GetNumberString(groups.First());
        }

        List<string> english = new List<string>();

        for (int i = 0; i < groups.Count; i++)
        {
            int group = groups[i];
            if (group > 0)
            {
                if (i == groups.Count - 1)
                {
                    english.Add(GetNumberString(group));

                }
                else
                {
                    english.Add(GetNumberString(group) + " " + numberSuffixes[groups.Count - i]);
                }

            }
        }

        return string.Join(" ", english);
    }

    private static string GetNumberString(int number)
    {
        if (namedNumbers.ContainsKey(number))
        {
            return namedNumbers[number];
        }

        if (number > 12 && number < 20)
        {
            return namedNumbers[GetLastDigit(number)] + "teen";
        }

        if (number > 19 && number < 100)
        {
            for (int j = 0; j < namedNumbers.Keys.Count; j++)
            {
                long highestKey = namedNumbers.Keys.Reverse().ElementAt(j);
                if (number > highestKey)
                {
                    return namedNumbers[highestKey] + '-' + namedNumbers[GetLastDigit(number)];
                }

                if (number > namedNumbers.Keys.Last())
                {
                    return namedNumbers[namedNumbers.Keys.Last()] + '-' + namedNumbers[GetLastDigit(number)];
                }
            }
        }

        if (number > 99 && number < 1000)
        {
            string prefix = namedNumbers[GetFirstDigit(number)] + " hundred";
            if (number % 100 == 0)
            {
                return prefix;
            }
            else
            {
                return prefix + " " + GetNumberString(int.Parse(number.ToString().Substring(1)));
            }
        }

        return "";
    }

    private static string GetCommaSeparatedNumber(long number)
    {
        return string.Format("{0:n0}", number);
    }

    private static List<int> GetNumberGroups(long number)
    {
        return GetCommaSeparatedNumber(number).Split(',').Select(n => int.Parse(n)).ToList();
    }

    private static int GetLastDigit(int number)
    {
        return number % 10;
    }

    private static int GetFirstDigit(int number)
    {
        return number.ToString()[0] - 48;
    }
}