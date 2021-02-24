using System;

namespace ARRAY_PROCESSING
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] mass = new int[10];

            for (int i = 0; i < mass.Length-1; i++)
            {
                mass[i] = rnd.Next(0, 10);
            }

            for (int i = 0; i < mass.Length-1; i++)
            {
                Console.WriteLine(mass[i]);
            }

            BubbleSort(mass);
            Console.WriteLine();
            for (int i = 0; i < mass.Length - 1; i++)
            {
                Console.WriteLine(mass[i]);
            }

            Console.ReadLine();
        }

        static void BubbleSort(int[] mass)
        {
            int temp;

            for (int i = 0; i < mass.Length-1; i++)
            {
                if(mass[i] > mass[i + 1])
                {
                    temp = mass[i + 1];

                    mass[i + 1] = mass[i];
                    mass[i] = temp;

                    i = 0;
                }
            }
        }
    }
}
