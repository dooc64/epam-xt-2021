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
        public static void LanguageChecker(this string words)
        {
            if (!Regex.IsMatch(words, @"^[а-я][ё]$", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Текст написан только на кирилице");
            }
            else if (Regex.IsMatch(words, @"^[a-z]", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("В строке только латинские буквы");
            }
            else if (Regex.IsMatch(words, @"^\d+$"))
            {
                Console.WriteLine("В строке только цифры");
            }
            else
            {
                Console.WriteLine("Текст имеет разные символы и языки");
            }
        }
    }
}
