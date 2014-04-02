using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        public static int arifm(int a, int d, int k) 
        {
            
            if (k == 1)
                return a;
            else
                return arifm(a, d, k - 1)+d;
        }
        static void Main(string[] args)
        {
            int x, y, z,res;
            Console.WriteLine("Введите первый элемент прогрессии");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите разность прогрессии");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер элемента");
            z = int.Parse(Console.ReadLine());
            res= arifm(x, y,z);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
