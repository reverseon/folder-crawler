using System;
using System.Collections.Generic;
using System.IO;

namespace FolderCrawler
{
    class FolderFileDictionary
    {
        // Atribut Private
        private const int RootLevel = 0;
        private DirectoryInfo rootDirectory;
        
        // Atribut Public
        // Menyimpan path dengan menggunakan dictionary
        public Dictionary<string, List<string>> dir = new Dictionary<string, List<string>>();

        // Membuat Tree dari Directory dengan menggunakan Dictionary
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
            foreach (var file in directory.GetFiles())
            {
                container.Add(file.FullName);
            }
            foreach (var subDirectory in directory.GetDirectories())
            {
                container.Add(subDirectory.FullName);
                CreateDirectoryTree(subDirectory);
            }
            this.dir[directory.FullName] = container;
        }

        // Menampilkan Directory Tree di Console
        public void PrintDictionaryTree()
        {
            Console.WriteLine(this.rootDirectory.Name);
            PrintDictionaryTree(this.rootDirectory.FullName, RootLevel);
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
                Console.WriteLine($"{indentation}-{takeName(value)}");
                if (this.dir.ContainsKey(value))
                {
                    PrintDictionaryTree(value, currentLevel + 1);
                }
            }
        }

        //Mengambil nama File atau Folder pada path (setelah '\' terakhir)
        private string takeName(string path)
        {
            string name = "";
            int x = 1;
            if(path[path.Length-1] == '\\' || path[path.Length - 1] == '/')
            {
                x = 2;
            }
            for (int i = path.Length-x; i >=0; i--)
            {
                if (path[i] == '\\' || path[i] == '/')
                {
                    break;
                }
                name = path[i] + name;
            }
            return name;
        }


        public string BFS_OneFile(string target)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue(rootDirectory.FullName);
            foreach (string value in this.dir[rootDirectory.FullName])
            {
                q.Enqueue(value);
            }
            while (q.Count != 0)
            {
                string currentQueue = q.Dequeue();
                if (takeName(currentQueue) == target)
                {
                    return currentQueue;
                }
                else
                {
                    if (this.dir.ContainsKey(currentQueue))
                    {
                        foreach(string insideCurrentQueue in this.dir[currentQueue])
                        {
                            q.Enqueue(insideCurrentQueue);
                        }
                    }
                }
            }
            return null;
        }

        public string DFS_OneFile(string target)
        {
            Stack<string> s = new Stack<string>();
            s.Push(rootDirectory.FullName);

            while (s.Count != 0)
            {
                string currentStack = s.Pop();
                if (takeName(currentStack) == target)
                {
                    return currentStack;
                }
                else
                {
                    if (this.dir.ContainsKey(currentStack))
                    {
                        this.dir[currentStack].Reverse();
                        foreach (string value in (this.dir[currentStack]))
                        {
                            s.Push(value);
                        }
                    }
                }
            }
            return null;
        }

    }
}
