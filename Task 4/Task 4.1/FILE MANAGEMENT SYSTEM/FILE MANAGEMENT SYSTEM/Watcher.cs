using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FILE_MANAGEMENT_SYSTEM
{
    class Watcher
    {
        private string _pathToBackup;
        public string path = @"C:\Users\scout\Desktop\fortask";
        public string PathToBackup { get => _pathToBackup; }
        public FileSystemWatcher watcher;
        public Dictionary<int, string> backupFolder = new Dictionary<int, string>();
        public Dictionary<int, string> fullnameBackupFolder = new Dictionary<int, string>();

        public Watcher(string pathToFolder, string pathToBackupFolder)
        {
            watcher = new FileSystemWatcher(pathToFolder, "*.txt");
            _pathToBackup = pathToBackupFolder;
        }

        public void Activate()
        {
            watcher.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite;

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            string newfolder = _pathToBackup + "\\" + DateTime.Now.ToString("Дата dd-MM-yy Время hh-mm-ss");
            Directory.CreateDirectory(newfolder);
            CopyFiles(watcher.Path, newfolder);
        }

        public void CopyFiles(string path, string copyto)
        {
            if (path == _pathToBackup)
                return;

            string[] directorys = Directory.GetDirectories(path);
            foreach (var item in Directory.GetFiles(path))
            {

                string resultPath = item.Substring(item.LastIndexOf(@"\"));
                File.Copy(item, copyto + resultPath, true);

            }
            foreach (var item in directorys)
            {
                string resultPath = item.Substring(item.LastIndexOf(@"\"));
                CopyFiles(item, copyto + resultPath);
            }
        }

        public void DelFolder(string DelFileFolder)
        {
            Directory.CreateDirectory(DelFileFolder);
            string[] files = Directory.GetFiles(DelFileFolder);
            foreach (string file in files)
                File.Delete(file);
        }

        public void RefreshFolders()
        {
            string[] directorys = Directory.GetDirectories(_pathToBackup);
            for (int i = 1; i < directorys.Length + 1; i++)
            {
                fullnameBackupFolder.Add(i, directorys[i - 1]);
                string resultName = directorys[i - 1].Substring(directorys[i - 1].LastIndexOf(@"\"));
                backupFolder.Add(i, resultName);
            }
            foreach (var item in backupFolder)
            {
                Console.WriteLine(item.Key + "." + item.Value);
            }
        }
    }
}