using System;

namespace NON_NEGATIVE_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[10];
            Randomaize(mass);
            Show(mass);
            Console.WriteLine("====");
            Console.WriteLine("Сумма положительных элементов массива: " + PositiveSum(mass));
            Console.ReadLine();
        }

        static void Randomaize(int[] mass)
        {
            Random rnd = new Random();
            for (int i = 0; i < mass.Length-1; i++)
            {
                mass[i] = rnd.Next(-10, 10);
            }
        }

        static int PositiveSum(int[] mass)
        {
            int sum = 0;
            for (int i = 0; i < mass.Length-1; i++)
            {
                if (mass[i] > 0)
                    sum += mass[i];
            }
            return sum;
        }

        static void Show(int[] mass)
        {
            for (int i = 0; i < mass.Length-1; i++)
            {
                Console.WriteLine(mass[i]);
            }
        }
    }
}
