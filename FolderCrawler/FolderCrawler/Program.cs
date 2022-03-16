using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FolderCrawler
{
	class Tree {
        // member variables
        public Tree parent; // Pointer to parent
        public Tree[] child; // Array of pointer to children
        public string content; // Isi dari Tree, berbentuk string
        public int children_count; // Jumlah child yang dimiliki suatu pohon

        // Default Constructor
        public Tree(){
            children_count = 0;
            child = null;
            content = "-";
        }
        // User-Defined Constructor
        public Tree(string name, int num_of_children){
            content = name;
            children_count = num_of_children;
            if (children_count > 0) child = new Tree[children_count];
        }
        
        // Check Index utk array child valid atau enggak
        private bool validChildIndex(int index){
            return (index < children_count && index >= 0);
        }
        // Print content string dari Tree
        public void printContent(){
            Console.WriteLine(content);
        }
        // Nambah child sesuai index
        public void AddChild(int index, Tree c){
            if (validChildIndex(index)){
                if (this.child != null) this.child[index] = c;
                c.parent = this;
            }
        }
        
        // Return string path dari Tree
        public string get_path(){
            if (this.parent != null){
                return (parent.get_path() + "/" + this.content);
            } else {
                return this.content;
            }
        }
        // Menuliskan path dari Tree
        public void WritePath(){
            Console.WriteLine(this.get_path());
        }
    }
	
    class Program
    {

        public static void Main()
        {
            string path = "D:\\Kuliah\\Tingkat 2\\Semester 4\\IF2230 - Sistem Operasi\\Soal"; // Posisi Directory Awal
            string target = "Quiz-3.pdf"; // file yang dicari
            FolderFileDictionary x = new FolderFileDictionary();
            x.CreateDirectoryTree(path);
            //x.PrintDictionaryTree();
            string resultBFS = x.BFS_OneFile(target);
            string resultDFS = x.DFS_OneFile(target);
            if(resultBFS != null)
            {
                Console.WriteLine(resultBFS);
            }
            else
            {
                Console.WriteLine("Null :(");
            }
            if (resultDFS != null)
            {
                Console.WriteLine(resultBFS);
            }
            else
            {
                Console.WriteLine("Null :(");
            }
        }
    }
}
