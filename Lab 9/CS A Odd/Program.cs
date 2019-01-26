using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_CSOdd
{
     public class BinarySearchTree
    {
        private BNode root;

        public BinarySearchTree()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.root = null;
        }

        public BNode Search(int e)
        {
            return Search(root, e);
        }

        private BNode Search(BNode node, int e)
        {
            if (node == null)
                return null;

            if (node.data == e)
                return node;

            if (e < node.data)
                return Search(node.left, e);
            else
                return Search(node.right, e);
        }
        public void Add(int e)
        {
            root = Add(root, e);
        }
        private BNode Add(BNode node, int e)
        {
            if (node == null)
            {
                node = new BNode(e);
                return node;
            }

            if (e < node.data)
                node.left = Add(node.left, e);
            else
                node.right = Add(node.right, e);

            return node;
        }
      }

     public class BNode
     {
         public int data;
         public BNode left;
         public BNode right;

         public BNode()
         {
             Initialize();
         }

         public BNode(int e)
         {
             this.data = e;
             Initialize();
         }

         private void Initialize()
         {
             left = null;
             right = null;
         }
     }
   //For Question3
    class DNode
     {
         public DNode previous;
         public DNode next;
         public int data;

         public DNode()
         {
             this.previous = null;
             this.next = null;
         }

         public DNode(int e)
         {
             this.data = e;
             this.previous = null;
             this.next = null;
         }
     } 
     public class DList
     {
         DNode head;
         DNode tail;

         public DList()
         {
             head = null;
             tail = null;
         }

         public void Add(int e)
         {
             DNode node = new DNode(e);
             node.next = head;
             node.previous = null;

             if (head != null)
                 head.previous = node;

             if (tail == null)
                 tail = node;

             head = node;
         }

         public int Search(int e)
         {
             DNode Head = head; int flag = -1; int i = 0;
             while (Head != null)
             {
                 if (e == Head.data)
                 {
                     flag = i;
                     return flag;
                 }
                 Head = Head.next; i++;
             }

             return flag;
         }
     } 

    class Program
    { 

        public static void Question1()
        {
            Console.WriteLine("Enter the size of the square matrix: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Enter Element {0},{1}: ", i + 1, j + 1);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }

                Console.WriteLine("Sum of Row {0}: {1}", i + 1, sum);
            }
        }
        static void Main(string[] args)
        {

            Question1();
            //---------------------------------Question2
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(20);
            bst.Add(10);
            bst.Add(30);
            bst.Add(5);
            bst.Add(2);
            bst.Add(15);
            bst.Add(17);
            BNode obj = new BNode();

            obj = bst.Search(2);
            Console.WriteLine(obj.data);
            //------------------------question3 
            DList list = new DList();           
            for (int i = 1; i < 11; i++ )
            {
                Console.WriteLine("Enter Number {0}:", i);
                list.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            Console.WriteLine("Enter number to search:");
            int num = int.Parse(Console.ReadLine());
            int loc = list.Search(num);

            if (loc != -1)
                Console.WriteLine("Found at location {0}", loc);
            else
                Console.WriteLine("Not Found");

        }
    }
}
