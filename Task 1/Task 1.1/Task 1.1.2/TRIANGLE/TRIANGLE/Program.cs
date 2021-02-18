using System;

namespace TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Введите кол-во строк: ");
                bool correct = int.TryParse(Console.ReadLine(), out int height);
                if (!correct)
                {
                    Console.WriteLine("ОШИБКА ВВОДА!");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y <= i; y++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
        }
    }
}
