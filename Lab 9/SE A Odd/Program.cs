using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_SE_A_Odd
{

    class Queue
    {
        private int[] numbers;
        private int front;
        private int rear;
        private int max;

        public Queue(int size)
        {
            numbers = new int[size];
            front = 0;
            rear = -1;
            max = size;
        }
        public void enqueue(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            else
            {
                numbers[++rear] = item;
            }

        }
        public void printQueue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {
                for (int i = rear; i >= front; i--)
                {
                    Console.WriteLine(numbers[i] );
                }
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
            Question2(root);
        }

        public void Question2(BNode n)
        {
            if (n == null)
            {
                return;
            }
            Question2(n.left);
            Console.WriteLine(n.data);
            Question2(n.right);

        }
    }

    class DNode
    {
        public DNode previous;
        public DNode next;
        public int data;
        public DNode(int e)
        {
            data = e;
            previous = null;
            next = null;
        }
    }
    class DList
    {
        DNode head;
        DNode tail;
       
        public DList()
        {
            head = null;
            tail = null;
        }
        public void AddFirst(int e)
        {
            DNode n = new DNode(e);
            if (head == null)
            {
                head = n;
                tail = n;
            }
            else
            {
                n.next = head;
                head.previous = n;
                head = n;
            }
        }
        public DNode Search(int e)
        {
            DNode x = head;
            while (x != null)
            {
                if (x.data == e)
                    return x;
                x = x.next;
            }
            return null;
        }
        public void Question3(int e)
        {
            DNode node = Search(e);
            if (node != null)
            {
                DNode t = node.previous;
                t.next = node.next;
                node.next.previous = t;
                node = null;
                Console.WriteLine("Element deleted");
            }
            else { Console.WriteLine("Not Found"); }

        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //Question1-----------
            Queue Q = new Queue(10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Number {0}",i+1);
                Q.enqueue(Convert.ToInt32(Console.ReadLine()));
            }

            Q.printQueue();

            //Question2-----------
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

            //Question3
            DList dl = new DList();
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("Enter Element {0}: ", i);
                dl.AddFirst(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine();
            Console.WriteLine("Enter number to delete: ");
            dl.Question3(int.Parse(Console.ReadLine()));
        }
    }
}
