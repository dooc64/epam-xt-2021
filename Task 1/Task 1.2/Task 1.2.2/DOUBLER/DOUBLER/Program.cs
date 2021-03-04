using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUBLER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку...");
            string input = Console.ReadLine();
            Console.WriteLine("А теперь вторую...");
            string inputSecond = Console.ReadLine();
            Console.WriteLine(Doubler(input, inputSecond));
            Console.ReadLine();
        }

        static string Doubler(string firstInput, string secondInput)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < firstInput.Length; i++)
            {
                if (firstInput[i] == ' ')
                    break;

                result.Append(firstInput[i]);

                if (secondInput.Contains(firstInput[i]))
                    result.Append(firstInput[i]);
            }
            return result.ToString();
        }
    }
}
