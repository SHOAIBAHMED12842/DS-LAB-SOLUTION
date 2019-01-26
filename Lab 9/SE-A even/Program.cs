
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_SE_A_Even
{
    class stack
    {
        int[] arr;
        int l = 0;
        public stack(int size)
        {
            arr = new int[size];
        }
        public void push(int i)
        {
            if (isfull())
                throw new StackOverflowException();
            arr[l] = i;
            ++l;
        }
        public int pop()
        {
            if (isempty())
                throw new Exception("Stack Underflow");
            return arr[l = l - 1];
        }
        public bool isempty()
        {
            if (l == 0)
                return true;
            else 
                return false;
        }
        public bool isfull()
        {
            if (l == arr.Length)
                return true;
            else 
                return false;
        }
    }
    class Question1
    {
        public void Reverse(stack st)
        {

            while (!st.isempty())
            {
                Console.WriteLine(st.pop());
            }
        }
    }
    
    class Bnode
    {
        public int data;
        public Bnode left;
        public Bnode right;
        public Bnode()
        {
            left = null;
            right = null;
        }
        public Bnode(int i)
        {
            left = null;
            right = null;
            data = i;
        }
      
    }

    class BinarySearchTree
    {
        private Bnode root;
        public BinarySearchTree()
        {
            this.root = null;
        }
        public void add(int i)
        {
            root = add(i, root);
        }
        public Bnode add(int i, Bnode node)
        {
            if (node == null)
            {
                Bnode newnode = new Bnode(i);
                node = newnode;
                return node;
            }
            else if (i > node.data)
            {
                node.right = add(i, node.right);
                return node;
            }
            else
            {
                node.left = add(i, node.left);
                return node;
            }
        }
        public int maximum()
        {
            if (root == null)
                throw new Exception("Tree is empty");
            return maximum(root);
        }
        public int maximum(Bnode node)
        {
            if (root == null)
                throw new Exception("Tree is empty");
            while (node.right != null)
            {
                node = node.right;
            }
            return node.data;
        }
       
        public int minimum()
        {
            return minimum(root);
        }
        public int minimum(Bnode node)
        {
            if (node == null)
                throw new Exception("Tree is empty");
            while (node.left != null)
            {
                node = node.left;
            }
            return node.data;
        }

    }

    class DNODE
    {
        public int data;
        public DNODE next;
        public DNODE prev;

        public DNODE()
        {
            next = null;
            prev = null;
        }
        public DNODE(int i)
        {
            data = i;
            next = null;
            prev = null;
        }
       
    }

    class Dlist
    {
        int count = 0;
        public DNODE head;
        public DNODE tail;
        public Dlist()
        {
            head = new DNODE();
            tail = head;
        }
        public void add_last(int i)
        {
            DNODE node = new DNODE(i);
            tail.next = node;
            node.prev = tail;
            tail = node;
            ++count;
        }
        public void Question3(int loc)
        {
            DNODE temp = head;

            {
                if (loc <= count)
                {
                    for (int i = 1; i <= loc; i++)
                    {
                        temp = temp.next;

                        if (i == loc)
                        {
                            Console.WriteLine("Number at location {0} is: {1}", loc, temp.data);
                        }
                    }
                }

                else
                    Console.WriteLine("Not found");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            stack stk = new stack(10);

            for (int i = 1; i <= 10; i++)
            {
                Console.Write("Enter number {0}=", i);
                stk.push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine();
            Question1 q1 = new Question1();
            q1.Reverse(stk);

            BinarySearchTree bst = new BinarySearchTree();
            bst.add(8);
            bst.add(3);
            bst.add(1);
            bst.add(6);
            bst.add(4);
            bst.add(7);
            bst.add(10);
            bst.add(14);
            bst.add(13);
            Console.WriteLine("Maximum=" + bst.maximum());
            Console.WriteLine("Minimum=" + bst.minimum());

            Dlist list = new Dlist();
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("Enter number {0}:", i);
                list.add_last(int.Parse(Console.ReadLine()));
            }

            Console.Write("Enter number to search:");
            int loc = int.Parse(Console.ReadLine());
            list.Question3(loc);
        }
    }
}
