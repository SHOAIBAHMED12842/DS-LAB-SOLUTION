using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SingleList
    {
        public SingleList next;
        public int data;
        public SingleList()
        {
            data = 0;
            next = null;
        }
        public SingleList(int i)
        {
            data = i;
            next = null;
        }
        public SingleList InsertNext(int value)
        {
            SingleList node = new SingleList(value);
            if (this.next == null)
            {
                this.next = node;
                node.next = null;
            }
            else
            {
                SingleList temp = this.next;
                node.next = temp;
                this.next = node;
            }
            return node;
        }
        public int DeleteNext()
        {
            if (next == null)
                return 0;
            else
            {
                SingleList node = this.next;
                this.next = this.next.next;
                node = null;
                return 1;
            }
        }
        public void Traverse(SingleList node)
        {
            if (node == null)
                node = this;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
        }
    }
     public class GroceryList
     {
         public GroceryList next;
         public string item;
         public GroceryList()
         {
             item = null;
             next = null;
         }
         public GroceryList(string i)
         {
             item = i;
             next = null;
         }
         public GroceryList InsertNext(string value)
         {
             GroceryList node = new GroceryList(value);
             if (this.next == null)
             {
                 this.next = node;
                 node.next = null;
             }
             else
             {
                 GroceryList temp = this.next;
                 node.next = temp;
                 this.next = node;
             }
             return node;
         }
         public int DeleteNext()
         {
             if (next == null)
                 return 0;
             else
             {
                 GroceryList node = this.next;
                 this.next = this.next.next;
                 node = null;
                 return 1;
             }
         }
         public void Traverse(GroceryList node)
         {
             if (node == null)
                 node = this;
             while (node != null)
             {
                 Console.WriteLine(node.item);
                 node = node.next;
             }
         }
     }

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
         public void Delete(int e)
         {            
             if (head.data== e)
             {
                 head = head.next;
                 head.previous  = null;
                 Console.WriteLine("Element Deleted!");
             }
             else
             {
                 Node n = head;
                 while (n != null)
                 {
                     if (n.data == e)
                     {
                         Console.WriteLine("Element Deleted!");
                         if (n.next != null)
                         {
                             n.next.previous = n.previous;
                         }
                         if (n.previous != null)
                         {
                             n.previous.next = n.next;
                         }
                     }
                     n = n.next;
                 }
             }
         }
         public void print()
         {
             Node x = null;
             if (head != null)
             {
                 x = head;
             }
             Console.WriteLine("Elements in Double Linked List:");
             while (x != null)
             {
                 Console.WriteLine(x.data);
                 x = x.next;
             }
         }
     }
     class Program
     {
        static void Main(string[] args)
        {
            SingleList n1 = new SingleList(1);
            SingleList n2 = n1.InsertNext(2);
            SingleList n3 = n2.InsertNext(3);
            SingleList n4 = n3.InsertNext(4);
            Console.WriteLine("Traverse");
            n1.Traverse(n1);
            Console.WriteLine("Deleting node 2");
            n1.DeleteNext();
            Console.WriteLine("Traverse");
            n1.Traverse(null);

            GroceryList i1 = new GroceryList("item1");
            GroceryList i2 = i1.InsertNext("item2");
            GroceryList i3 = i2.InsertNext("item3");
            GroceryList i4 = i3.InsertNext("item4");
            Console.WriteLine("Traverse");
            i1.Traverse(i1);
            Console.WriteLine("Deleting node 2");
            i1.DeleteNext();
            Console.WriteLine("Traverse");
            i1.Traverse(null);

            DList dl = new DList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Number " + (i + 1) + " ");
                dl.insert(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine();
            dl.print();
            dl.Delete(Convert.ToInt32(Console.ReadLine()));
            dl.print();
        }
    }
}
