using System;

namespace StringWorker
{
    public class StringManager
    {
        private string someWords;
        public char this[int i]
        {
            get { return someWords[i]; }
            set
            {
                string result = string.Empty;
                for (int n = 0; n < someWords.Length; n++)
                {
                    if(n != i)
                    {
                        result += someWords[n];
                    }
                    else
                    {
                        result += value;
                    }
                }
                someWords = result;
            }
        }        
        public bool Equals(string input)
        {
            if (someWords.Length != input.Length)
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (someWords[i] != input[i])
                    return false;
            }
            return true;
        }

        public void Concatinate(object text)
        {
            someWords += text.ToString();
        }

        public bool FindBySymbol(string text)
        {
            for (int i = 0; i < someWords.Length - text.Length; i++)
            {
                for (int n = 0; i < text.Length; n++)
                {
                    if (someWords[i + n] != text[n])
                    {
                        break;
                    }

                    if (text.Length == n + 1)
                        return true;
                }
            }
            return false;
        }

        public char[] ToArray()
        {
            char[] result = new char[someWords.Length];
            for (int i = 0; i < someWords.Length; i++)
            {
                result[i] = someWords[i];
            }
            return result;
        }

        public void FromArray(char[] chars)
        {
            someWords = string.Empty;
            for (int i = 0; i < chars.Length; i++)
            {
                someWords += chars[i];
            }
        }

        public void Reverse()
        {
            string result = string.Empty;
            for (int i = someWords.Length; i >= 0; i--)
            {
                result += someWords[i];
            }
            someWords = result;
        }

        public override string ToString()
        {
            return someWords;
        }
    }
}
