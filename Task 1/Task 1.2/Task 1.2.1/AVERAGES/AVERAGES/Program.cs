using System;


namespace AVERAGES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку...");
            string text = Console.ReadLine();
            string[] ClearText = ClearWords(text);
            Console.WriteLine("Средняя длина слов составила: " + AvgLengthWords(ClearText));
            Console.ReadLine();
        }

        static string[] ClearWords(string words)
        {
            char[] tresh = new char[] { ' ', ';', ',', ':', '.', '!', '?', '-' };
            string[] inputData = words.Split(tresh, StringSplitOptions.RemoveEmptyEntries);
            return inputData;
        }
        
        static int AvgLengthWords(string[] words)
        {
            int sum = 0;

            foreach (var item in words)
            {
                sum += item.Length;
            }

            //Rounding a number
            int average = sum / words.Length;

            return average;
        }
    }
}
