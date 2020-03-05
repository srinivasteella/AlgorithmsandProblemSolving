using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input00.txt");
            int d = Convert.ToInt32(lines[0]);
            int swapcount = 0;
            int[] a = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp));
            Console.WriteLine("Input Array::::");
            a.ToList().ForEach(v => Console.Write(v+" "));
            Console.WriteLine();
            var sorterarray = BubbleSort(a,ref swapcount);
            Console.WriteLine("Output Array::::");
            sorterarray.ToList().ForEach(v => Console.Write(v + " "));
            Console.WriteLine();
            Console.WriteLine("No of swaps :"+ swapcount);
            Console.WriteLine("Min Value :" + sorterarray[0]);
            Console.WriteLine("Max Value :" + sorterarray[sorterarray.Length-1]);
            Console.Read();
        }

        static int[] BubbleSort(int[] arr,ref int swapcount)
        {
            for (int i =0;i < arr.Length-1;i++)
            {
                for(int j=0;j < arr.Length-1-i;j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        arr.Swap(j, j + 1);
                        swapcount++;
                    }
                }
                
            }
            return arr;
        }
    }

    public static class SwapExtension
    {
        public static void Swap<T>(this T[] a, int i1, int i2)
        {
            T t = a[i1];
            a[i1] = a[i2];
            a[i2] = t;
        }
    }
}
