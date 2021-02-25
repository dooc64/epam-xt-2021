using System;

namespace NO_POSITIVE
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,,] mass = new int[4, 3, 5];
            Randomaize(mass);
            Show(mass);
            NoPositive(mass);
            Console.WriteLine();
            Console.WriteLine("===================");
            Show(mass);
            Console.ReadLine();
        }

        static void Show(int[ , , ] mass)
        {
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                Console.WriteLine("------------");
                for (int second = 0; second < mass.GetLength(1); second++)
                {
                    for (int third = 0; third < mass.GetLength(2); third++)
                    {
                        Console.Write(mass[first, second, third] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void NoPositive(int[,,] mass)
        {
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                for (int second = 0; second < mass.GetLength(1); second++)
                {
                    for (int third = 0; third < mass.GetLength(2); third++)
                    {
                        if (mass[first, second, third] > 0)
                        {
                            mass[first, second, third] = 0;
                        }
                    }
                }
            }
        }

        static void Randomaize(int[ , , ] mass)
        {
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                for (int second = 0; second < mass.GetLength(1); second++)
                {
                    for (int third = 0; third < mass.GetLength(2); third++)
                    {
                        mass[first, second, third] = rnd.Next(-10, 10);
                    }
                }
            }
        }
    }
}
