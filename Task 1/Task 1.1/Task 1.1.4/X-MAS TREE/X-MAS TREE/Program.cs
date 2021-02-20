using System;

namespace X_MAS_TREE
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите кол-во строк: ");
                bool correct = int.TryParse(Console.ReadLine(), out int height);
                if (!correct)
                {
                    Console.WriteLine("ОШИБКА ВВОДА!");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                for (int z = 0; z < height; z++)
                {
                    for (int i = 0; i < z + 1; i++)
                    {
                        for (int p = height - i - 1; p > 0; p--)
                        {
                            Console.Write(' ');
                        }

                        for (int y = 0; y <= i * 2; y++)
                        {
                            Console.Write('*');
                        }
                        Console.WriteLine();
                    }
                }
                Console.ResetColor();
            }
        }
    }
}
