using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash
{
    public class HashTable<TType>
    {
        private class Node
            //класс узла
        { 
            public string key;
            public TType data;
            public Node next;

            public Node(string key, TType data, Node next)
            {
                this.data = data;
                this.key = key;
                this.next = next;
            }
        }

        private Node[] array;
        private int m;

        public HashTable(int size)
            //конструктор
        {
            this.m = size;
            this.array = new Node[m];
        }

        public HashTable()
        {
            this.m = 850;
            this.array = new Node[m];
        }

        private int HashKey(string key)
        {
            int h = 0, L = key.Length;
            for (int i = 0; i < L; i++)
            {
                h += i * (int)key[i];
                h %= m;
            }
            return h;
        }

        public void Add(string key, TType value)
            //вставка
        {
            int h = HashKey(key);
            Node p = array[h];

            bool f = false;
            while ((p != null) && (!f))
                if (p.key == key)
                {
                    f = true;
                    p.data = value;
                }
                else p = p.next;

            if (!f)
            {
                if (array[h] == null)
                    array[h] = new Node(key, value, null);
                else
                    array[h] = new Node(key, value, array[h]);
            }
        }

        public void Delete(string key)
            //удаление элемента
        {
            int h = HashKey(key);
            if (array[h] == null) throw new IndexOutOfRangeException();
            if (array[h].key == key)
                array[h] = array[h].next;
            else
            {
                Node p = array[h];
                bool f = false;
                while ((p.next != null) && (!f))
                    if (p.next.key == key)
                        f = true;
                    else p = p.next;
                if (f)
                    p.next = p.next.next;
            }
        }

        public TType Find(string key)
            //поиск элемента по ключу
        {
            int h = HashKey(key);
            Node p = array[h];
            TType res = default(TType);
            bool f = false;
            while ((p != null) && (!f))
                if (p.key == key)
                {
                    f = true;
                    res = p.data;
                }
                else 
                    p = p.next;
                    return res;
        }
        public TType  this[string key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                Add(key, value);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> ht = new HashTable<int>();
            ht.Add("lol", 300);
            ht.Add("abd", 100);
            ht.Add("ddd", 1);
            ht.Add("ccc", 2);
            ht.Add("aaa", 25);
            ht.Delete("aaa");
            Console.WriteLine(ht["lol"]);
            Console.WriteLine(ht["abd"]);
            Console.WriteLine(ht["ddd"]);
            Console.WriteLine(ht["ccc"]);
            Console.WriteLine(ht["aaa"]);
            Console.ReadKey();
        }
    }
}