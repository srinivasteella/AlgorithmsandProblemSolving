//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MarkandToys
//{
//    //class Program
//    //{
//    //    static void Main(string[] args)
//    //    {
//    //        string[] lines = System.IO.File.ReadAllLines(@"input.txt");
//    //        int n = Convert.ToInt32(lines[0].Split(' ')[0]);
//    //        int k = Convert.ToInt32(lines[0].Split(' ')[1]);

//    //        int[] prices = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp));

//    //        var sorterarray = CalMaxToys(prices,k);
//    //        Console.WriteLine();

//    //        Console.Read();
//    //    }

//    //    static int CalMaxToys(int[] prices, int amount)
//    //    {
//    //        var left = prices.Take(prices.Length / 2).ToArray();
//    //        var right = prices.Skip(prices.Length / 2).ToArray();
//    //        BubbleSort(ref left);
//    //        BubbleSort(ref right);
//    //        var finalarray = MergeArray(left,right);
//    //        return 0;
//    //    }

//    //static int[] MergeArray(int[] left, int[] right)
//    //{
//    //    int[] finalarray = new int[left.Length + right.Length];
//    //    int i = 0;
//    //    int j = 0;
//    //    int k = 0;

//    //    while (i < left.Length && j < right.Length)
//    //    {
//    //        if (left[i] <= right[j])
//    //        {
//    //            finalarray[k] = left[i];
//    //            k++;
//    //            i++;
//    //        }
//    //        else
//    //        {
//    //            finalarray[k] = right[j];
//    //            k++;
//    //            j++;
//    //        }
//    //    }

//    //    while (i < left.Length)
//    //    {
//    //        finalarray[k] = left[i];
//    //        k++;
//    //        i++;
//    //    }

//    //    while (j < right.Length)
//    //    {
//    //        finalarray[k] = right[j];
//    //        k++;
//    //        j++;
//    //    }

//    //    return finalarray;
//    //}

//    //    static void BubbleSort(ref int[] arr)
//    //    {
//    //        for (int i = 0; i < arr.Length - 1; i++)
//    //        {
//    //            for (int j = 0; j < arr.Length - 1 - i; j++)
//    //            {
//    //                if (arr.ElementAt(j) > arr.ElementAt(j + 1))
//    //                {
//    //                    arr.Swap(j, j + 1);
//    //                }
//    //            }
//    //        }
//    //    }
//    //}

//    //public static class SwapExtension
//    //{
//    //    public static void Swap<T>(this T[] a, int i1, int i2)
//    //    {
//    //        T t = a[i1];
//    //        a[i1] = a[i2];
//    //        a[i2] = t;
//    //    }
//    //}

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
//            int n = Convert.ToInt32(lines[0].Split(' ')[0]);
//            int k = Convert.ToInt32(lines[0].Split(' ')[1]);

//            int[] prices = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp));
//            var affordableitemsprices = getonlyaffordablepricelist(prices,k);
//            int[] finalarray = new int[affordableitemsprices.Length];
//            var sorterarray = mergesort(affordableitemsprices, finalarray,0, affordableitemsprices.Length-1);
//            int output = calculatenumberofitemsagainstbudget(sorterarray,k);

//            Console.WriteLine(output);

//            Console.Read();
//        }

//        static int[] getonlyaffordablepricelist(int[] prices,int budget)
//        {
//            return prices.ToList().FindAll(a => a <= budget).ToArray();

//        }

//        static int calculatenumberofitemsagainstbudget(int[] pricelist,int budget)
//        {
//            int totalprice = 0; int nooftoyscanbuy = 0;
//            pricelist.ToList().ForEach(i => {
//                if (totalprice+i <= budget)
//                {
//                    totalprice = totalprice + i;
//                    nooftoyscanbuy++;
//                }
//            });
//            return nooftoyscanbuy;
//        }

//        static int[] mergesort(int[] array,int[] temp,int leftstart,int rightend)
//        {
//            if (leftstart >= rightend)
//            {
//                return null;
//            }
//            int middle = (leftstart + rightend) / 2;
//            mergesort(array,temp,leftstart,middle);
//            mergesort(array, temp, middle+1, rightend);
//            mergehalves(array,temp,leftstart,rightend);
//            return temp;
//        }

//        static void mergehalves(int[] array,int[] temp, int leftstart,int rightend)
//        {
//            int leftend = (rightend + leftstart) / 2;
//            int rightstart = leftend + 1;
//            int size = rightend - leftstart + 1;

//            int left = leftstart;
//            int right = rightstart;
//            int index = leftstart;

//            while (left <= leftend && right <= rightend)
//            {
//                if (array[left] <= array[right])
//                {
//                    temp[index] = array[left];
//                    left++;
//                }
//                else
//                {
//                    temp[index] = array[right];
//                    right++;
//                }
//                index++;
//            }

//            Array.Copy(array, left, temp, index, leftend - left + 1);
//            Array.Copy(array, right, temp, index, rightend - right + 1);
//            Array.Copy(temp, leftstart, array, leftstart, size);


//        }
//    }
//}
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    static int calculatenumberofitemsagainstbudget(int[] pricelist, int budget)
    {
        int totalprice = 0; int nooftoyscanbuy = 0;

        for(int p = 0;p < pricelist.Length;p++)
        {
            if(totalprice+pricelist[p] <= budget)
            {
                totalprice = totalprice + pricelist[p];
                nooftoyscanbuy++;
            }
            else
            {
                break;
            }
        }
        //pricelist.ToList().ForEach(i => {
        //    if (totalprice + i <= budget)
        //    {
        //        totalprice = totalprice + i;
        //        nooftoyscanbuy++;
        //    }
        //});
        return nooftoyscanbuy;
    }

    static int[] mergesort(int[] array, int[] temp, int leftstart, int rightend)
    {
        if (leftstart >= rightend)
        {
            return null;
        }
        int middle = (leftstart + rightend) / 2;
        mergesort(array, temp, leftstart, middle);
        mergesort(array, temp, middle + 1, rightend);
        mergehalves(array, temp, leftstart, rightend);
        return temp;
    }

    static void mergehalves(int[] array, int[] temp, int leftstart, int rightend)
    {
        int leftend = (rightend + leftstart) / 2;
        int rightstart = leftend + 1;
        int size = rightend - leftstart + 1;

        int left = leftstart;
        int right = rightstart;
        int index = leftstart;

        while (left <= leftend && right <= rightend)
        {
            if (array[left] <= array[right])
            {
                temp[index] = array[left];
                left++;
            }
            else
            {
                temp[index] = array[right];
                right++;
            }
            index++;
        }

        Array.Copy(array, left, temp, index, leftend - left + 1);
        Array.Copy(array, right, temp, index, rightend - right + 1);
        Array.Copy(temp, leftstart, array, leftstart, size);


    }
    // Complete the maximumToys function below.
    static int maximumToys(int[] prices, int k)
    {
        int noofitems = 0;
        var affordableitemsprices = prices.ToList().FindAll(a => a <= k).ToArray();
        int[] finalarray = new int[affordableitemsprices.Length];
        if (finalarray.Length == 0 || finalarray.Length == 1)
        {
            noofitems = finalarray.Length;
        }
        else
        {
            var sorterarray = mergesort(affordableitemsprices, finalarray, 0, affordableitemsprices.Length - 1);
            noofitems = calculatenumberofitemsagainstbudget(sorterarray, k);
        }
        return noofitems;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");
        int n = Convert.ToInt32(lines[0].Split(' ')[0]);
        int k = Convert.ToInt32(lines[0].Split(' ')[1]);

        int[] prices = Array.ConvertAll(lines[1].Split(' '), pricesTemp => Convert.ToInt32(pricesTemp));

        int result = maximumToys(prices, k);

        Console.WriteLine(result);
        Console.Read();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
