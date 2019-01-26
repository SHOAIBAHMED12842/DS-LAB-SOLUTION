using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_MatrixHandling
{
    class Program
    {
        public static int[,] matrix;
        public static int row, Col;
       public static int[,] GetElements(int r, int c)
        {
            row = r; Col = c;
            matrix = new int[row, Col];
           
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.WriteLine("Enter Element [{0},{1}]:",i,j);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return matrix;
        }
        public static int[,] AddMatrix(int[,] mat1, int[,] mat2)
       {
           for (int i = 0; i < row; i++)
           {
               for (int j = 0; j < Col; j++)
               {
                   matrix[i, j] = mat1[i, j] + mat2[i, j];
               }
           }
           return matrix;
       }
        public static int[,] Transpose(int[,] mat)
        {         
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    matrix[i, j] = mat[j, i];
                }
            }
            return matrix;
        }
        public static bool IsIdentity(int[,] mat)
        {
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    if (i == j && mat[i, j] != 1)
                        return false;
                    else if (i != j && mat[i, j] != 0)
                        return false;                   
                }
            }
            return true;
        }
        public static void Print(int[,] mat)
        {            
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    Console.Write("{0}\t",matrix[i, j]);  
                }
                Console.WriteLine();
            }
        }
        public static void SumRow(int[,] mat)
        {
            int[] sum = new int[mat.GetUpperBound(0)+1];
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                sum[i] = 0;
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    sum[i] += mat[i, j];
                }                
            }
            for (int i = 0; i < sum.Length; i++)
            {
                Console.WriteLine("Sum of the row {0}: {1}", i, sum[i]);
            }
        }
        public static void SumCol(int[,] mat)
        {
            int[] sum = new int[mat.GetUpperBound(0) + 1];
            for (int i = 0; i <= mat.GetUpperBound(0); i++)
            {
                sum[i] = 0;
                for (int j = 0; j <= mat.GetUpperBound(1); j++)
                {
                    sum[i] += mat[j, i];
                }
            }
            for (int i = 0; i < sum.Length; i++)
            {
                Console.WriteLine("Sum of the column {0}: {1}", i, sum[i]);
            }
        }
        static void Main(string[] args)
        {
            int[,] matrix1 = GetElements(2, 2);
            int[,] matrix2 = GetElements(2, 2);
            int[,] sum = AddMatrix(matrix1, matrix2);
            Print(sum);
            int[,] trans = Transpose(matrix1);
            Print(trans);
            Console.WriteLine(IsIdentity(matrix1));
            SumRow(matrix1);
            SumCol(matrix1);


        }
    }
}
