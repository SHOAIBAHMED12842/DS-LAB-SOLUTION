using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_StackQueue
{
   
    class Queue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;

        public Queue(int size)
        {
            ele = new int[size];
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
                ele[++rear] = item;
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
                Console.WriteLine();
                Console.WriteLine("Front item is {0}", ele[front]);
                Console.WriteLine("Rear item is {0} ", ele[rear]);
                return p;
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
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine(ele[i] + " enqueued to queue");
                }
            }
        }
    } 
    class Stack
    {
         static readonly int MAX = 1000; 
        int top; 
        int[] stack = new int[MAX]; 
  
        bool IsEmpty() 
        { if(top < 0)
            return true ;
        else
            return false;
        } 
        public Stack() 
        { 
            top = -1; 
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
  
        public void Peek() 
        { 
            if (top < 0) 
            { 
                Console.WriteLine("Stack Underflow"); 
                return; 
            } 
            else
                Console.WriteLine("The topmost element of Stack is : {0}", stack[top]); 
        }   
        public void PrintStack() 
        { 
            if (top < 0) 
            { 
                Console.WriteLine("Stack Underflow"); 
                return; 
            } 
            else
            { 
                Console.WriteLine("Items in the Stack are :"); 
                for (int i = top; i >= 0; i--) 
                { 
                    Console.WriteLine(stack[i]); 
                } 
            } 
        } 
        public bool BracketMatcher(string exp)
        {
             Stack<string> paran = new Stack<string>();
            int len = 0;
            for (len = 0; len < exp.Length; len++ )
            {
                if (exp[len] == '[' || exp[len] == '{' || exp[len] == '(')
                    paran.Push(exp[len].ToString());
                else
                {
                    string a = paran.Pop();
                    switch (exp[len])
                    {
                        case ')':
                            {
                                if (a == "{" || a == "[")
                                {
                                    Console.WriteLine("Unbalanced");
                                    return false;
                                }
                                break;
                            }
                        case '}':
                            {
                                if (a == "(" || a == "[")
                                {
                                    Console.WriteLine("Unbalanced");
                                    return false;
                                }
                                break;
                            }
                        case ']':
                            {
                                if (a == "{" || a == "(")
                                {
                                    Console.WriteLine("Unbalanced");
                                    return false;
                                }
                                break;
                            }                        
                    }
                } 
            }           
            Console.WriteLine("Balanced");           
            return true;
        }

        public int PostFix(int[] exp)
        {
            Stack<int> expr = new Stack<int>();
            int num1, num2, Result=0;
            for (int len = 0; len < exp.Length; len++)
            {
                if (exp[len] != '+' && exp[len] != '-' && exp[len] != '*' && exp[len] != '/')
                {
                    expr.Push(exp[len]);
                    Console.WriteLine(exp[len]);
                }
                else
                {
                   
                    switch (exp[len])
                    {
                        case '+':
                            {
                                num1 = expr.Pop();
                                num2 = expr.Pop();
                                Result = num1 + num2;
                                expr.Push(Result);
                                break;
                            }
                        case '-':
                            {
                                num1 = expr.Pop();
                                num2 = expr.Pop();
                                Result = num1 - num2;
                                expr.Push(Result);
                                break;
                            }
                        case '*':
                            {
                                num1 = expr.Pop();
                                num2 = expr.Pop();
                                Result = num1 * num2;
                                expr.Push(Result);
                                break;
                            }
                        case '/':
                            {
                                num1 = expr.Pop();
                                num2 = expr.Pop();
                                Result = num1 / num2;
                                expr.Push(Result);
                                break;
                            }
                    }
                }
            }
            int res = expr.Pop();
            return res;
        }
    } 

    
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(40);
            myStack.PrintStack();
            myStack.Peek();
            Console.WriteLine("Item popped from Stack : {0}", myStack.Pop());
            myStack.PrintStack();
            myStack.BracketMatcher("{(})");
            int[] str = { 12, 8, '+' };
            Console.WriteLine("{0}",myStack.PostFix(str));


            Queue Q = new Queue(5);
            Console.WriteLine();
            Q.enqueue(10);
            Q.enqueue(20);
            Q.enqueue(30);
            Q.enqueue(40);
            Q.printQueue();
            Q.dequeue();
            Console.ReadLine();
        }
    }
}
