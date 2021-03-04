using StringWorker;
using System;
using System.Text;

namespace CUSTOM_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            StringManager stringManager = new StringManager();
            StringBuilder sb = new StringBuilder();
            stringManager.Concatinate("asd");
            Console.WriteLine(stringManager);
            Console.WriteLine(stringManager.ToString());
            Console.WriteLine(stringManager[0] = 'v');
            Console.WriteLine(stringManager);
            Console.ReadLine();
        }
    }
}
