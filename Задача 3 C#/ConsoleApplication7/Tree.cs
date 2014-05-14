﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tree
{
    class Tree
    {
        public class Node
        {
            public int data;
            public bool visited;
            public Node parent;
            public Node left;
            public Node right;
            public Node(int data, Node parent, Node left, Node right)
            {
                this.data = data;
                this.parent = parent;
                this.left = left;
                this.right = right;
                this.visited = false;
            }

            public int Sum(int k)
            {
                if (k == 0)
                    return data;
                else
                {
                    int s = 0;
                    if (left != null) s += left.Sum(k - 1);
                    if (right != null) s += right.Sum(k - 1);
                    return s;
                }
            }
        }

        private Node root;
        public Tree()
        {
            root = null;
        }

        //Сумма на k-m уровне
        public int Sum(int k)
        {
            return root.Sum(k - 1);
        }

        //Вставка в дерево
        public void Insert(int data)
        {
            if (root == null)
                root = new Node(data, null, null, null);
            else
            {
                Node p = root;
                bool ok = false;
                while (!ok)
                {
                    if (data > p.data)
                        if (p.right == null)
                        {
                            p.right = new Node(data, p, null, null);
                            ok = true;
                        }
                        else p = p.right;
                    else
                        if (data < p.data)
                            if (p.left == null)
                            {
                                p.left = new Node(data, p, null, null);
                                ok = true;
                            }
                            else p = p.left;
                        else
                            ok = true;
                }
            }
        }

        //Печать дерева
        private void WriteNode(Node p, StreamWriter w)
        {
            if (p != null)
            {
                if (p.visited)
                {
                    w.WriteLine(Convert.ToString(p.data) + " [color = yellow, style = filled];");
                }
                if (p.left != null)
                {
                    w.WriteLine(Convert.ToString(p.data) + "->" + Convert.ToString(p.left.data) + ";");
                    WriteNode(p.left, w);
                }
                if (p.right != null)
                {
                    w.WriteLine(Convert.ToString(p.data) + "->" + Convert.ToString(p.right.data) + ";");
                    WriteNode(p.right, w);
                }
            }
        }
        public void WriteTree(string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("digraph G {");
            WriteNode(root, w);
            w.WriteLine("}");
            w.Close();
            f.Close();
        }
        public void WriteTree()
        {
            WriteTree("graph.gv");
        }

        //Удаление элемента из дерева
        Node q = new Node(0, null, null, null);
        private void Delete(ref Node r)
        {
            if (r.right != null)
                Delete(ref r.right);
            else
            {
                q.data = r.data;
                q = r;
                r = r.left;
            }
        }
        private void DeleteNode(int data, ref Node p)
        {
            if (p != null)
                if (data < p.data)
                    DeleteNode(data, ref p.left);
                else
                    if (data > p.data)
                        DeleteNode(data, ref p.right);
                    else
                    {
                        q = p;
                        if (q.right == null)
                            p = q.left;
                        else
                            if (q.left == null)
                                p = q.right;
                            else
                                Delete(ref q.left);
                    }
        }
        public void Remove(int data)
        {
            DeleteNode(data, ref root);
        }

        //Поиск элемента в дереве
        public Node Find(int data)
        {
            if (root != null)
                return FindNode(root, data);
            else
                return null;
        }
        private Node FindNode(Node p, int data)
        {
            if (p.data == data)
            {
                p.visited = true;
                return p;
            }
            else
            {
                Node result = null;
                if (p.left != null)
                    result = FindNode(p.left, data);
                if ((result == null) && (p.right != null))
                    result = FindNode(p.right, data);
                return result;
            }
        }
    }
}
