using System;
using System.Linq;

namespace SUPER_ARRAY
{
    public static class ArrayExtension
    {
        public static void UpadteMass<T>(this T[] mass, Func<T, T> func)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = func.Invoke(mass[i]);
            }
        }

        public static ushort SumAllElement(this ushort[] mass)
        {
            ushort sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static byte SumAllElement(this byte[] mass)
        {
            byte sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static uint SumAllElement(this uint[] mass)
        {
            uint sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static ulong SumAllElement(this ulong[] mass)
        {
            ulong sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static decimal SumAllElement(this decimal[] mass)
        {
            decimal sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static double SumAllElement(this double[] mass)
        {
            double sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static short SumAllElement(this short[] mass)
        {
            short sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static int SumAllElement(this int[] mass)
        {
            int sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static long SumAllElement(this long[] mass)
        {
            long sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static float SumAllElement(this float[] mass)
        {
            float sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static sbyte SumAllElement(this sbyte[] mass)
        {
            sbyte sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            return sum;
        }

        public static double FindAvgNumber<T>(this int[] mass)
        {
            return mass.SumAllElement() / mass.Length;
        }

        public static double FindAvgNumber<T>(this byte[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }

        public static double FindAvgNumber<T>(this sbyte[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }

        public static double FindAvgNumber<T>(this float[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this long[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this ushort[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this short[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this decimal[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this ulong[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }
        public static double FindAvgNumber<T>(this uint[] mass)
        {
            return (double)mass.SumAllElement() / mass.Length;
        }

        public static T MostRecurringItem<T>(this T[] mass)
        {
            return mass.GroupBy(item => item).OrderBy(n => n.Count()).Last().Key;
        }
    }
}
 