using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TEXT_ANALYSIS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день, для анализа текста напишите его ниже");
            string text = Console.ReadLine();
            Console.Clear();
            Console.Write("Ваш текст анализируется, пожалуйста подождите");

            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");

            Console.WriteLine();

            TextHandler worker = new TextHandler(text);
            worker.Separator(worker.current);
            worker.WordsCount();
            worker.ShowReult();
            Console.ReadLine();
        }
    }


    
    public class TextHandler
    {
        private char[] separators = new char[] { ' ', ';', ',', ':', '.', '!', '?', '-', '"' };
        private Dictionary<string, int> _popularWords = new Dictionary<string, int>();
        
        string[] result;
        public string current;

        public TextHandler(string text)
        {
            current = text;
        }

        public void Separator(string text)
        {
           var lowerText = text.ToLower();
           result  = lowerText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Show(string[] text)
        {
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowReult()
        {
            _popularWords.OrderBy(x => x.Value);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Наиболее повторяющиеся слова");
            Console.WriteLine("----------------------------");

            foreach (var item in _popularWords)
            {
                if(item.Value >= 5)
                    Console.WriteLine($"Слово {item.Key} встречается {item.Value} раз");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Менее встречающиеся слова");
            Console.WriteLine("----------------------------");

            foreach (var item in _popularWords)
            {
                if (item.Value <= 2)
                    Console.WriteLine($"Слово {item.Key} встречается {item.Value} раз");
            }
            Console.WriteLine("----------------------------");

            int uniqueWords = _popularWords.Where(x => x.Value == 1).Count();

            if (uniqueWords > result.Length * 0.3)
            {
                Console.WriteLine($"Вы использовали {uniqueWords} уникальных слов, вы молодец!");
            }
            else if(uniqueWords < result.Length* 0.3)
            {
                Console.WriteLine("Слишком часто повторяетесь, сударь.");
            }

        }

        public void WordsCount()
        {
            for (int word = 0; word < result.Length; word++)
            {
                if (_popularWords.ContainsKey(result[word]))
                {
                    _popularWords[result[word]]++;
                }
                else
                {
                    _popularWords.Add(result[word], 1);
                }
            }
        }
    }
}