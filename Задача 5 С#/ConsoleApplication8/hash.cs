using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashdict
{
    public class HashTable
    {
        private class Node
            //класс узла
        { 
            public string key;
            public object data;
            public Node next;

            public Node(string key, object data, Node next)
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

        public void Add(string key, object value)
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

        public object Find(string key)
            //поиск элемента по ключу
        {
            int h = HashKey(key);
            Node p = array[h];
            Object res = default(Object);
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
        public object this[string key]
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
}