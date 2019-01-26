using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_csEven
{
    class Node
    {
        public int data;
        public Node next;
        public Node previous;
        public Node()
        {
            data = 0;
            next = null;
            previous = null;
        }
        public Node(int e)
        {
            data = e;
            next = null;
            previous = null;
        }
    }
    class DList
    {
        Node head;
        Node tail;
        public DList()
        {
            head = null;
            tail = null;
        }
        public void insert(int e)
        {
            Node n = new Node(e);
            if (head == null)
            {
                n.next = null;
                n.previous = null;
                head = n;
                tail = n;
            }
            else
            {
                tail.next = n;
                n.previous = tail;
                n.next = null;
                tail = n;
            }
        }
        public void print()
        {
            Node x = null;
            if (head != null)
            {
                x = tail;
            }
            Console.WriteLine("Elements in Double Linked List in Reverse Order:");
            while (x != null)
            {
                Console.WriteLine(x.data);
                x = x.previous;
            }
        }
    }
    class BNode
{
    public BNode left;
    public BNode right;
    public int data;

    public BNode(int e)
    {
        data = e;
    }

}
    class BinarySearchTree
    {
        private BNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void add(int e)
        {
            root = add(root, e);
        }

        public BNode add(BNode n, int e)
        {           
            if (n == null)
            {
                n = new BNode(e);
                return n;
            }
            if (e < n.data)
            {
                n.left = add(n.left, e);
            }
            else
            {
                n.right = add(n.right, e);
            }
            return n;
        }

        public void Inorder()
        {
            Question3(root);
        }

        public void Question3(BNode n)
        {
            if (n == null)
            {
                return;
            }
            Question3(n.left);
            Console.WriteLine(n.data);
            Question3(n.right);

        }
    }
    class Program
    {
 
        static public void Question2()
        {
            Console.WriteLine("Enter the rows and columns of matrix :");
            int n = Convert.ToInt16(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Enter the element " + (i + 1) + "," + (j + 1) + ":");
                    a[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }
            Console.WriteLine("Transpose of matrix is:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[j, i]);
                    Console.Write("  ");
                }
                Console.WriteLine(" ");
            }

        }
        static void Main(string[] args)
        {

            //Question1
            DList dl = new DList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Number " + (i + 1) + " ");
                dl.insert(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine();
            dl.print();
            //Question 2
            Question2();
            //Question 3
            BinarySearchTree b = new BinarySearchTree();
            b.add(8);
            b.add(3);
            b.add(1);
            b.add(6);
            b.add(4);
            b.add(7);
            b.add(10);
            b.add(14);
            b.add(13);
            b.Inorder();
        }
    }
}
