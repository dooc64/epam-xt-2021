using System;


namespace _2D_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mass = new int[10, 10];
            Randomaize(mass);
            Console.WriteLine("Сумма элементов массива, стоящих на чётных позициях: " + SumEvenInteger(mass));
            Console.WriteLine(OptimaizedSumEvenInteger(mass));
            Console.ReadLine();
        }

        static void Randomaize(int[,] mass)
        {
            Random rnd = new Random();
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                for (int second = 0; second < mass.GetLength(1); second++)
                {
                    mass[first, second] = rnd.Next(0, 10);
                }

            }
        }

        static int SumEvenInteger(int[,] mass)
        {
            int sum = 0;
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                for (int second = 0; second < mass.GetLength(1); second++)
                {
                    if((first + second)%2 == 0)
                    {
                        sum += mass[first, second];
                    }
                }
            }
            return sum;
        }

        static int OptimaizedSumEvenInteger(int[,] mass)
        {
            int sum = 0;
            for (int first = 0; first < mass.GetLength(0); first++)
            {
                for (int second = first%2; second < mass.GetLength(1); second+=2)
                {
                        sum += mass[first, second];
                }
            }
            return sum;
        }
    }
}
