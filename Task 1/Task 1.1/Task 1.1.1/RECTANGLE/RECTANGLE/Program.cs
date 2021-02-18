using System;

namespace RECTANGLE
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true)
            { 
                Console.WriteLine("Программа для определения площади прямоугольника запущена...");
                Console.Write("Введите длину: ");
                int a = ReadLineConverter();
                Console.WriteLine();
                if (a <= 0)
                {
                    Console.WriteLine("Вводите числа больше 0");
                    continue;
                }
                Console.Write("Введите ширину: ");
                int b = ReadLineConverter();
                Console.WriteLine();
                if (b <= 0)
                {
                    Console.WriteLine("Вводите числа больше 0");
                    continue;
                }
                int S = a * b;
                Console.WriteLine("Площадь прямоугольника равна: " + S);
                Console.ReadLine();
                return;
            }
        }

        public static int ReadLineConverter()
        {
            string result = "";
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    if (result.Length > 0)
                        return int.Parse(result);
                    else
                        return 0;
                }

                if (Char.IsNumber(cki.KeyChar))
                {
                    Console.Write(cki.KeyChar);
                    result += cki.KeyChar;
                }
                if(cki.KeyChar == '-' && result.Length == 0)
                {
                    Console.Write('-');
                    result += '-';
                }
                if(cki.Key == ConsoleKey.Backspace)
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1, 1);
                        Console.Write(cki.KeyChar + " " + cki.KeyChar);
                    }
                }
            }
        }
    }
}
