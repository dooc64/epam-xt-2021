using System;
using System.Text.RegularExpressions;

namespace SUPER_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public static class StringChecker
    {
        public static Language LanguageChecker(this string words)
        {
            if (!Regex.IsMatch(words, @"^[а-я][ё]$", RegexOptions.IgnoreCase))
            {
                return Language.Russian;
            }
            else if (Regex.IsMatch(words, @"^[a-z]", RegexOptions.IgnoreCase))
            {
                return Language.English;
            }
            else if (Regex.IsMatch(words, @"^\d+$"))
            {
                return Language.Number;
            }
            else
            {
                return Language.Mixed;
            }
        }
    }

    public enum Language
    {
        Russian,
        English,
        Number,
        Mixed
    }
}
