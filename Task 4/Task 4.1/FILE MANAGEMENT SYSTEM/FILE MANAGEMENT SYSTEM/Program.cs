using System;
using System.Collections.Generic;
using System.IO;

namespace FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Выберите режим" + 
                Environment.NewLine + "1. Наблюдать" + 
                Environment.NewLine + "2. Откатить изменения");
            bool choice = int.TryParse(Console.ReadLine(), out int userChoice); 
            switch(userChoice)
            {
                case 1:
                    Watcher watcher = new Watcher(@"C:\Users\scout\Desktop\fortask", @"C:\Users\scout\Desktop\fortask\backup");
                    watcher.Activate();
                    Console.ReadLine();
                    break;
                case 2:
                    Watcher switcher = new Watcher(@"C:\Users\scout\Desktop\fortask", @"C:\Users\scout\Desktop\fortask\backup");
                    Dictionary<int, string> folders = new Dictionary<int, string>();
                    switcher.RefreshFolders();
                    folders = switcher.backupFolder;
                    int versionChoice = int.Parse(Console.ReadLine());
                    switcher.DelFolder(switcher.path);
                    foreach (var item in switcher.fullnameBackupFolder)
                    {
                        if (versionChoice == item.Key)
                            switcher.CopyFiles(item.Value, switcher.path);
                    }
                    break;

            }



        }
    }
}
