using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6_QuickSort
{
    class RecursiveOP
    {
        int[] arr;
        public int[] GenerateRandom(int n)
        {
            arr = new int[n];
            Random rand = new Random();
            for(int i = 0; i<n-1; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
            Console.WriteLine("Array Generated is: ");
            foreach(int i in arr)
            {
                Console.Write("{0} ",i);
            }
            return arr;
        }
        public int[] Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                  arr =   Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                  arr =  Quick_Sort(arr, pivot + 1, right);
                }
            }
            return arr;

        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right])
                        return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public int[] Quick_SortDesc(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = PartitionDesc(arr, left, right);

                if (pivot > 1)
                {
                    arr = Quick_SortDesc(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    arr = Quick_SortDesc(arr, pivot + 1, right);
                }
            }
            return arr;

        }
        private int PartitionDesc(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] > pivot)
                {
                    left++;
                }

                while (arr[right] < pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right])
                        return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public void Timer(int[] arr)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            Quick_Sort(arr, 0, arr.Length - 1);
            time.Stop();
            Console.WriteLine();
            Console.WriteLine("Quick Sort in Ascending oreder : {0} seconds", time.Elapsed);
            time.Start();
            Quick_SortDesc(arr, 0, arr.Length - 1);
            time.Stop();
            Console.WriteLine("Quick Sort in Descending oreder : {0} seconds", time.Elapsed);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveOP obj = new RecursiveOP();
            int[] data = obj.GenerateRandom(5);
            Console.WriteLine();

            data = obj.Quick_Sort(data, 0, data.Length - 1);

            Console.WriteLine();
            Console.WriteLine("Sorted array in Ascending Oreder: ");

            foreach (var item in data)
            {
                Console.Write(" " + item);
            }

            Console.WriteLine();
            data = obj.Quick_SortDesc(data, 0, data.Length - 1);
            Console.WriteLine("Sorted array in Descending Oreder: ");
            foreach (var item in data)
            {
                Console.Write(" " + item);
            }
            obj.Timer(data);

        }
    }
}
