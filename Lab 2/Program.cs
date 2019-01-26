using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Searching
{
 
    class Program
    {
        static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0}", arr[i]);
            }
        }
        static void LinearSearch(int[] data,int X)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i]==X)
                {
                    Console.WriteLine("{0} is at location: {1}",X,i);
                }
            }
        }
        static int BinarySearch(int[] data, int X, int min, int max)
        {
            if (min > max)
            {
                return 0;
            }
            else
            {
                int mid = (min + max) / 2;
                if (X == data[mid])
                {
                    return ++mid;
                }
                else if (X < data[mid])
                {
                    return BinarySearch(data, X, min, mid - 1);
                }
                else
                {
                    return BinarySearch(data, X, mid + 1, max);
                }
            }             
        }
        static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        j--;
                    }
                    else
                        break;
                }
            }
            return arr;
        }
        static void BinarySearchIns(int[] data, int X, int min, int max)
        {
            int mid = (min + max) / 2;
                while (min <= max)
                {
                    if (X < data[mid])
                    {
                        max = mid - 1;
                    }
                    else min = mid + 1;
                    mid = Convert.ToInt32((min + max) / 2);  
                }
                if (X == data[mid])
                {
                    Console.WriteLine("Element exists!");
                }
                else
                {
                    Console.WriteLine("");
                    Array.Resize(ref data, data.Length + 1);
                    max++;
                    data[max] = X;
                    data = InsertionSort(data);
                }
                print(data);
        }
        static void Replace(int[] data,int x, int y)
        {
            bool flag = false; ; int i;
            for ( i = 0; i < data.Length; i++)
            {
                if (data[i] == x)
                {
                    flag = true;
                    break;
                }
            }
            if (flag==false)
            {
                Console.WriteLine("Element not found!");
            }
            else
            {
                data[i] = y;
            }
            print(data);
        }
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 9, 6 };
            LinearSearch(data, 3);
            Console.WriteLine("Binary Search : {0}", BinarySearch(data, 9, 0, data.Length - 1));
            BinarySearchIns(data, 5, 0, data.Length - 1);
            Console.WriteLine();
            Replace(data, 3, 99);
        }
    }
}
