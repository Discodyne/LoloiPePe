using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
                t.Insert(rnd.Next(20));
            t.WriteTree("output.txt");
            Console.WriteLine(t.Sum(5));
            Console.ReadKey();
        }
    }
}
