using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_StringOP
{
    class Program
    {
        public static int StrLen(string str)
        {
            int len = 0;
            foreach(char  c in str)
            {
                len++;
            }
            return len;
        }
        public static  StringBuilder StrConcat(string str1, string str2)
        {
            StringBuilder str = new StringBuilder(str1);
            int i = StrLen(str1);
            int j = str2.Length;
            for(int c=0; c<j; c++)
            {
                i++;
                str.Append(str2[c]);
            }
            return str;
        }
      
        public static StringBuilder substring(string data, int start, int end)
        {
            StringBuilder str = new StringBuilder();
            for (int i = start; i <= end; i++ )
            {
                str.Append(data[i]);
            }
            return str;
        }
        public static string InsertStr(string t, string p, int pos)
        {
            StringBuilder t1 = new StringBuilder();
            t1 = substring(t, 0, pos - 1);
            StringBuilder t2 = substring(t, pos, t.Length - 1);
            t1 = StrConcat(t1.ToString(), p);
            t1 = StrConcat(t1.ToString(), t2.ToString());
            return t1.ToString();
        }

        public static string DeleteStr(string data, int i, int len)
        {
            StringBuilder str = new StringBuilder();
            str.Append(substring(data, 0, i - 1));
            Console.WriteLine(str);
            StringBuilder str2 = substring(data, i + len, data.Length - 1);
            Console.WriteLine(str2);
            str.Append( str2);
            return str.ToString();
        }
 
        public static void Naive(string T, string P)
        {
            int n = T.Length;
            int m = P.Length; 
            int s;
            int i;
            for (s = 0; s <= (n - m); s++)
            {
                 for (i = 0; i < m; i++)
                    {
                        if (P[i] != T[s + i])
                            break;
                    }

                if (i == m)
                    Console.WriteLine("Pattern Found at S= {0}", s);
            }
        }

        public static void RabinKarp(string T, string P, int d, int q)
        {
            int n = T.Length;
            int m = P.Length;
             int h=1;
            int p = 0;
            int t = 0;
            int s,i;
            
           for (i = 0; i < m-1; i++) 
            h = (h * d) % q;
            Console.WriteLine(h);

            for ( i = 0; i < m; i++) //PreProcessing
            {
                p = (d * p + P[i]) % q;
                t = (d * t + T[i]) % q;
            }
            Console.WriteLine(p);
            Console.WriteLine(t);

            for (s = 0; s <= (n - m); s++) //matching
            {
                if (p == t)
                {
                    for (i = 0; i < m; i++)
                    {
                        if (P[i] != T[s + i])
                            break;
                    }

                    if (i == m)
                        Console.WriteLine("Pattern Found at S= {0}", s);
                }

                if (s < n - m)  //Assigning new hash
                {
                    t = (d * (t - (int)T[s] * h) + (int)T[s + m]) % q;
                 
                    if (t < 0)
                        t = (t + q);
                    Console.WriteLine(t);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StrConcat("Hello ", "World!").ToString());

            Console.WriteLine("{0}", substring("Hello", 1, 3));
            Console.WriteLine("{0}", InsertStr("Hello dear!", "Sana ", 10));
            Console.WriteLine("{0}", DeleteStr("My name is Khan!", 10, 4));
            Naive("acaabc", "aab");
            Console.WriteLine();
            RabinKarp("Today is Monday", "Monday", 256, 101);
        }
    }
}
