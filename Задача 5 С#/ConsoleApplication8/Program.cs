using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashdict
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HashTable<int> h = new HashTable<int>();
            h.Add("3", 300);
            h.Add("abd", 100);
            h.Add("ddd", 1);
            h.Add("ccc", 2);
            h.Add("aaa", 25);
            h.Delete("aaa");
            Console.WriteLine(h["3"]);
            Console.WriteLine(h["abd"]);
            Console.WriteLine(h["ddd"]);
            Console.WriteLine(h["ccc"]);
            Console.ReadKey();
             /*
            Dict<string,int> h = new Dict<string,int>();
            h.Add("3", 300);
            h.Add("abd", 100);
            h.Add("ddd", 1);
            h.Add("ccc", 2);
            h.Add("aaa", 25);
            h.Delete("aaa");
            Console.WriteLine(h["3"]);
            Console.WriteLine(h["abd"]);
            Console.WriteLine(h["ddd"]);
            Console.WriteLine(h["ccc"]);
            Console.ReadKey();
            */
        }
    }
}
