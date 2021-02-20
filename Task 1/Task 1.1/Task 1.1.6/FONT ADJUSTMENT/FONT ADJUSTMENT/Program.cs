using System;

namespace FONT_ADJUSTMENT
{
    class Program
    {
        private static bool bold = false;
        private static bool italic = false;
        private static bool underline = false;
        static void Main(string[] args)
        {
            while (true)
            {
                ShowSettings();
                bool correct = int.TryParse(Console.ReadLine(), out int input);
                if(!correct && input < 4 && input > 0)
                {
                    Console.WriteLine("Выберите цифру 1, 2 или 3");
                    continue;
                }
                SwitchFont(input);
            }
        }

        static void SwitchFont(int input)
        {
            switch(input)
            {
                case 1:
                    bold = !bold;
                    break;
                case 2:
                    italic = !italic;
                    break;
                case 3:
                    underline = !underline;
                    break;
                default:
                    break;
            }
        }

        static void ShowSettings()
        {
            Console.Write("Параметры надписи: ");
            Console.Write(!bold && !italic && !underline ? "None" : "");
            Console.Write(bold ? "Bold " : "");
            Console.Write(italic ? "Italic " : "");
            Console.Write(underline ? "Underline " : "");
            Console.WriteLine();
            Console.WriteLine("Введите:");
            Console.WriteLine("       1: bold");
            Console.WriteLine("       2: italic");
            Console.WriteLine("       3: underline");
        }
    }
}
