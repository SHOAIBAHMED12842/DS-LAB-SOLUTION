using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_DS
{
    class Program
    {
        public static int size;
        //Array Traversing
        static void Task1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0}",arr[i]);
            }
        }
        //Array Search
        static void Task2(int[] data, int X)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == X)
                {
                    Console.WriteLine("{0} is at location: {1}", X, i);
                }
            }
        }
        //Matrix Generator
        public static int[,] MatrixGen(int n)
        {
            size = n;
            int[,] matrix = new int[n,n];

            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    Console.WriteLine("Enter Element: [{0},{1}]", i, j);
                    matrix[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }
            return matrix;
        }
        //2D Traversing
        public static void Task3(int[,] matrix)
        {
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        //Matrix Multiplication
        public static void Task4(int[,] matrix1, int[,] matrix2)
        {
            int[,] Product = new int[2,2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j <2; j++)
                {
                    Product[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        Product[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            Console.WriteLine("Product Matrix: ");
            Task3(Product);
        }
        //Largest element
        public static void Task5(int[,] matrix)
        {
            int max = 0;
            for (int i = 0; i <size; i++)
            {
                for (int j = 0; j <size; j++)
                {
                   if(max< matrix[i,j])
                   { max = matrix[i, j]; }
                }
            }
            Console.WriteLine(max);
        }
        //Minimum element
        public static void Task6(int[,] matrix)
        {
            int min = 9999;
            for (int i = 0; i <size; i++)
            {
                for (int j = 0; j <size; j++)
                {
                    if (min > matrix[i, j])
                    { min = matrix[i, j]; }
                }
            }
            Console.WriteLine(min);
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 1 };
            Task1(array);
            Task2(array, 1);
            int[,] m1 = MatrixGen(2);
            int[,] m2 = MatrixGen(2);
            Task3(m1);
            Task4(m1, m2);
            Task5(m1);
            Task6(m1);

            
        }
    }
}
