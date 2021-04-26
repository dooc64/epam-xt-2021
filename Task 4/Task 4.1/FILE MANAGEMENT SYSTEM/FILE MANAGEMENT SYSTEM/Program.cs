using System;
using System.Collections.Generic;
using System.IO;

namespace FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        private static string mainPath = @"C:\Users\scout\Desktop\fortask";
        private static string backupFolder = @"C:\Users\scout\Desktop\fortask\backup";
        

        static void Main(string[] args)
        {
            Watcher watcher = new Watcher(mainPath, backupFolder);
            Console.WriteLine("Выберите режим" + 
                Environment.NewLine + "1. Наблюдать" + 
                Environment.NewLine + "2. Откатить изменения");
            bool choice = int.TryParse(Console.ReadLine(), out int userChoice); 
            switch(userChoice)
            {
                case 1:
                    watcher.Activate();
                    Console.ReadLine();
                    break;
                case 2:
                    watcher.StartBackup();
                    break;

            }



        }
    }
}
