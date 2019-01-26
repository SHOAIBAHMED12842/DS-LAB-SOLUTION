using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_SE_B_Even
{
    class QuickSort
    {
        public int pindex, Pivot;
        public void Question1(int n)
        {
            int start = 0,end = n-1;
            int[] array = new int[n];
            int[] Sorted_array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Element: {0}", i + 1);
                array[i] = Convert.ToInt16(Console.ReadLine());
            }
            Sorted_array = Quick_SortDesc(array, start, end);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Sorted_array[i]);
            }
        }
        public int[] Quick_SortDesc(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = PartitionDesc(arr, start, end);

                if (pivot > 1)
                {
                    arr = Quick_SortDesc(arr, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    arr = Quick_SortDesc(arr, pivot + 1, end);
                }
            }
            return arr;

        }
        private int PartitionDesc(int[] arr, int start, int end)
        {
            int pivot = arr[start];
            while (true)
            {

                while (arr[start] > pivot)
                {
                    start++;
                }

                while (arr[end] < pivot)
                {
                    end--;
                }

                if (start < end)
                {
                    if (arr[start] == arr[end])
                        return end;

                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                }
                else
                {
                    return end;
                }
            }
        }      
    }
   public class BNode
    {
        public int data;
        public BNode left;
        public BNode right;
        public BNode()
        {
            data = 0;
            left = null;
            right = null;
        }
        public BNode(int e)
        {
            data = e;
            left = null;
            right = null;
        }
    }
    public class BinarySeacrhTree
    {
        private BNode root;
        public BinarySeacrhTree()
        {
            Initailize();
        }
        public void Initailize()
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
        public int Size()
        {
            return Question2(root);
        }
        public int Question2(BNode node)
        {
            if (node == null)
                return 0;

            return 1 + Question2(node.left) + Question2(node.right);
        }
    }
    class Queue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;
        private int count;
        public Queue(int size)
        {
            ele = new int[size];
            front = 0;
            rear = -1;
            max = size;
            count = 0;
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
                ele[++rear] = item;
                count++;
            }

        }
        public int dequeue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine(ele[front] + " dequeued from queue");
                int p = ele[front++];
                Console.WriteLine("Front item is {0}", ele[front]);
                Console.WriteLine("Rear item is {0} ", ele[rear]);
                count--;
                return p;
            }
        }
        public int Count()
        {
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort obj = new QuickSort();
            Console.Write("Enter the number of elements in the array: ");
            obj.Question1(Convert.ToInt16(Console.ReadLine()));

            BinarySeacrhTree BST = new BinarySeacrhTree();
            BST.Add(6);
            BST.Add(9);
            BST.Add(2);
            BST.Add(4);
            BST.Add(5);
            BST.Add(8);

            Console.WriteLine(BST.Size());

            Console.WriteLine("Enter Size of the Queue: ");
            Queue Q = new Queue(int.Parse(Console.ReadLine()));
            Q.enqueue(10);
            Q.enqueue(20);
            Q.enqueue(30);
            Q.enqueue(40);
            Console.WriteLine("Count: {0}", Q.Count());
            Q.dequeue();
            Console.WriteLine("Count: {0}", Q.Count());
          
        }
    }
}
