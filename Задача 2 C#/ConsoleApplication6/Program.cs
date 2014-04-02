using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class MyNode     // Узел для списка, стека, очереди
    {
        public double inf;
        public MyNode next;
        public MyNode(double inf, MyNode next)            // Конструктор
        {
            this.inf = inf;
            this.next = next;
        }
    }

    class MyList
    {
        public MyNode head;
        public double count;

        public MyList()
        {
            head = null;
            count = 0;
        }

        public void Add(double inf)   //Вставка последним элементом
        {
            if (head == null) head = new MyNode(inf, null);
            else
            {
                MyNode p = head;
                for (int i = 0; i < count - 1; i++)
                    p = p.next;
                p.next = new MyNode(inf, null);
            }
            count++;
        }

        public int IsSorted()     //(-1) - убывающий, 1 - возрастающий, 0 - неупорядоченный
        {
            if (head.next == null) return 1;
            int sign = Math.Sign(head.next.inf - head.inf);
            MyNode p = head.next;
            while (p.next != null)
            {
                int s = Math.Sign(p.next.inf - p.inf);
                if (sign == 0) sign = s;
                if (s != sign) return 0;
                p = p.next;
            }
            if (sign == 0) return 1;
            return sign;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n;
            MyList list = new MyList();
            Console.WriteLine("Введите кол-во чисел.");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите числа.");
            for (int i = 0; i < n; i++)
                list.Add(double.Parse(Console.ReadLine()));
            int k = list.IsSorted();
            switch (k)
            {
                case 1: Console.WriteLine("Список упорядочен по возрастанию");
                    Console.ReadLine();
                    break;
                case -1: Console.WriteLine("Список упорядочен по убыванию");
                    Console.ReadLine();
                    break;
                case 0: Console.WriteLine("Список не упорядочен");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
