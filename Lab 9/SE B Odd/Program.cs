using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_SE_B_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number Of Inputs: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Search obj = new Search();
            obj.Question1(N);

            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(6);
            bst.Add(9);
            bst.Add(4);
            bst.Add(2);
            bst.Add(8);
            bst.Add(5);

            Console.WriteLine("Height of the root node is: {0}", bst.Height());

           StackADT myStack = new StackADT();

           myStack.Push(10);
           myStack.Push(20);
           myStack.Push(30);
           myStack.Push(40);
           Console.WriteLine("Item popped from Stack : {0}", myStack.Pop());
           Console.WriteLine("If stack is empty? {0}", myStack.IsEmpty());
        }
    }
  public class Search
  {
      int lb , ub , mid ;
      public void Question1(int n)
      {
          int[] Array = new int[n];

          for (int i = 0; i < Array.Length ; i++)
          {
              Console.WriteLine("Enter Number {0}: ", i + 1);
              Array[i] = Convert.ToInt32(Console.ReadLine());
          }
          Console.WriteLine();
          Console.WriteLine("Enter Number To Search: ");
          int X = Convert.ToInt32(Console.ReadLine());
         
           BinarySearch(Array,  X);
      }
      public  void BinarySearch(int[] Array, int X)
      {
          lb = 0; ub = Array.Length - 1;

          while (lb <= ub)
          {
              mid = (lb + ub) / 2;
               if (X == Array[mid])
          {
              Console.WriteLine("Found");
          }
              else if (X < Array[mid])
              {
                 ub = mid-1;
              }
              else
              {
                 lb = mid+1;
              } 
          }
              Console.WriteLine("Not Found");    

      }
  }
       
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
         public int Height()
        {
            return Question2(root);
        }

        public int Question2(BNode node)
        {
            if (node == null)
                return -1;

            int l = Question2(node.left);
            int r = Question2(node.right);

            if (l > r)
                return l + 1;
            else
                return r + 1;
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

 class StackADT
 {
     static readonly int MAX = 1000;
     int top;
     int[] stack = new int[MAX];
     public StackADT()
     {
         top = -1;
     }
     public bool IsEmpty()
     {
         if (top < 0)
             return true;
         else
             return false;
     }
     public bool Push(int data)
     {
         if (top >= MAX)
         {
             Console.WriteLine("Stack Overflow");
             return false;
         }
         else
         {
             stack[++top] = data;
             return true;
         }
     }
     public int Pop()
     {
         if (top < 0)
         {
             Console.WriteLine("Stack Underflow");
             return 0;
         }
         else
         {
             int value = stack[top--];
             return value;
         }
     }
 }


    
}
