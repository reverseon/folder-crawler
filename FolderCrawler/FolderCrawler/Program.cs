using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FolderCrawler
{
    class Program
    {
        public static void Main()
        {
            //Console.WriteLine("Enter the path of the root directory:");
            var rootDirectorypath = "D:\\Kuliah\\Tingkat 2\\Semester 4\\IF2230 - Sistem Operasi\\Soal";

            Console.WriteLine($"Getting directory tree of '{rootDirectorypath}'");
            FolderCrawler.FolderFileDictionary d = new FolderFileDictionary();
            d.CreateDirectoryTree(rootDirectorypath);
            d.PrintDictionaryTree();
        }

    }
}
