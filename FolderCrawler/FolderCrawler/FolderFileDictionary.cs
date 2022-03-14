using System;
using System.Collections.Generic;
using System.IO;

namespace FolderCrawler
{
    class FolderFileDictionary
    {
        private const int RootLevel = 0;
        private DirectoryInfo rootDirectory;
        public Dictionary<string, List<string>> dir = new Dictionary<string, List<string>>();

        public void CreateDirectoryTree(string rootDirectoryPath)
        {
            try
            {
                if (!Directory.Exists(rootDirectoryPath))
                {
                    throw new DirectoryNotFoundException(
                        $"Directory '{rootDirectoryPath}' not found.");
                }

                this.rootDirectory = new DirectoryInfo(rootDirectoryPath);
                CreateDirectoryTree(rootDirectory);

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void CreateDirectoryTree(DirectoryInfo directory)
        {
            List<string> container = new List<string>();
            foreach (var subDirectory in directory.GetDirectories())
            {
                container.Add(subDirectory.Name);
                CreateDirectoryTree(subDirectory);
            }
            foreach (var file in directory.GetFiles())
            {
                container.Add(file.Name);
            }
            this.dir[directory.Name] = container;
        }
        public void PrintDictionaryTree()
        {
            Console.WriteLine(this.dir[this.rootDirectory.Name]);
            PrintDictionaryTree(this.rootDirectory.Name, RootLevel);
        }

        private void PrintDictionaryTree(string directoryName, int currentLevel)
        {
            var indentation = string.Empty;
            char Tab = '\t';
            for (var i = RootLevel; i < currentLevel; i++)
            {
                indentation += Tab;
            }

            foreach (string value in this.dir[directoryName])
            {
                Console.WriteLine($"{indentation}-{value}");
                if (this.dir.ContainsKey(value))
                {
                    PrintDictionaryTree(value, currentLevel + 1);
                }
            }
        }
    }
}
