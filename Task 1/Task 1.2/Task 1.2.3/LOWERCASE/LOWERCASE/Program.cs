using System;
using System.Linq;

namespace LOWERCASE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваш текст...");
            string input = Console.ReadLine();
            string[] cleanresult = TextCleaner(input);
            int count = LowerCaseCounter(cleanresult);
            Console.WriteLine($"Кол-во слов с маленькой буквы: {count}");
            Console.ReadLine();
        }

        static string[] TextCleaner(string input)
        {
            char[] separator = new char[] { ' ', ',', '.', ':', ';', '!', '?' };
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        static int LowerCaseCounter(string[] text)
        {
            int count = 0;
            foreach (var item in text)
            {
                if (char.IsLower(item[0]))
                    count++;
            }
            return count;
        }

        static int LowerCaseCounterLinq(string[] input)
        {
            return input.Where(x => char.IsLower(x[0])).Count();
        }
    }
}
