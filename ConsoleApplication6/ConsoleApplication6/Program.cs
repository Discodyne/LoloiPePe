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

        public int IsSorted()  // Метод,выполняющий основную задачу
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
        public void delete(int index) 
        {
            if (index == 0)
                head = head.next;
            else 
            {
                MyNode p = head;
                for (int i = 0; i < index-1; i++)
                    p = p.next;
                if (p.next != null)
                    p.next = p.next.next;
            }
            count--;
        }
        public void Printer()
        {
            MyNode p = head;
            do
            {
                Console.Write("{0} ", p.inf);
                p = p.next;
            }
            while (p != null);
            Console.WriteLine();
        }
        public void Insert(double value, int index)
        {
            if (index == 0) head = new MyNode(value, null);
            else
            {
                MyNode p = head;
                for (int i = 0; i < index - 1; i++)
                    p = p.next;
                p.next = new MyNode(value, p.next);
                count++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n,s,x,y;
            MyList list = new MyList();
            Console.WriteLine("Введите кол-во чисел.");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите индекс элемента,который нужно удалить");
            s=int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число и позицию");
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите числа.");
            for (int i = 0; i < n; i++)
                list.Add(double.Parse(Console.ReadLine()));
            int k = list.IsSorted();  // Стоит обратить внимание на то ,что функция IsSorted(выполняющия основную задачу)срабатывает раньше,поэтому на результат ,который она выводит,методы delete и Insert не влияют.
            list.delete(s);
            list.Insert(x, y);
            list.Printer();
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
