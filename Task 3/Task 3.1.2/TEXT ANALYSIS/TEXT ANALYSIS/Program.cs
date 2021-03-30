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

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            Console.WriteLine();

            TextHandler worker = new TextHandler(text);
            string[] cleanText = worker.Separator();
            Dictionary<string, int> integerOfWords = worker.WordsCount(cleanText);
            worker.ShowReult(integerOfWords, cleanText);
            Console.ReadLine();
        }
    }


    
    public class TextHandler
    {
        private char[] separators = new char[] { ' ', ';', ',', ':', '.', '!', '?', '-', '"' };
        private Dictionary<string, int> _popularWords = new Dictionary<string, int>(); 
        private string currentString;

        public TextHandler(string text)
        {
            currentString = text;
        }

        public string[] Separator()
        {
           var lowerText = currentString.ToLower();
           return lowerText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Show(string[] text)
        {
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowReult(Dictionary<string, int> numberOfWords, string[] fullText)
        {
            numberOfWords.OrderBy(x => x.Value);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Наиболее повторяющиеся слова");
            Console.WriteLine("----------------------------");

            foreach (var item in numberOfWords)
            {
                if(item.Value >= 5)
                    Console.WriteLine($"Слово {item.Key} встречается {item.Value} раз");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Менее встречающиеся слова");
            Console.WriteLine("----------------------------");

            foreach (var item in numberOfWords)
            {
                if (item.Value <= 2)
                    Console.WriteLine($"Слово {item.Key} встречается {item.Value} раз");
            }
            Console.WriteLine("----------------------------");

            int uniqueWords = numberOfWords.Where(x => x.Value == 1).Count();

            if (uniqueWords >= fullText.Length * 0.3)
            {
                Console.WriteLine($"Вы использовали {uniqueWords} уникальных слов, вы молодец!");
            }
            else if(uniqueWords < fullText.Length* 0.3)
            {
                Console.WriteLine("Слишком часто повторяетесь, сударь.");
            }

        }

        public Dictionary<string, int> WordsCount(string[] text)
        {
            for (int word = 0; word < text.Length; word++)
            {
                if (_popularWords.ContainsKey(text[word]))
                {
                    _popularWords[text[word]]++;
                }
                else
                {
                    _popularWords.Add(text[word], 1);
                }
            }
            return _popularWords;
        }
    }
}