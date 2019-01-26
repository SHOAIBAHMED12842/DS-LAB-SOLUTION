using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab3_Sorting
{
    class Program
    {
        static int[] data;
        static int[] GenerateRandom(int n)
        {
            data = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                data[i] = rand.Next(0, 100);
            }
            return data;
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
        static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }
            return arr;
        }
        static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
        static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0}", arr[i]);
            }
        }
        static void SortComparison(int[] arr)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            InsertionSort(arr);
            timer.Stop();
            Console.WriteLine("Insertion Sort: {0}", timer.Elapsed);

            timer.Start();
            BubbleSort(arr);
            timer.Stop();
            Console.WriteLine("Bubble Sort: {0}", timer.Elapsed);

            timer.Start();
            SelectionSort(arr);
            timer.Stop();
            Console.WriteLine("Selection Sort: {0}", timer.Elapsed);
        }
        static void Main(string[] args)
        {
            int[] data = GenerateRandom(5);
            data = InsertionSort(data);
            Console.WriteLine("Sorted array:");
            print(data);
            data = BubbleSort(data);
            print(data);
            data = SelectionSort(data);
            print(data);
            SortComparison(data);
        }
    }
}
