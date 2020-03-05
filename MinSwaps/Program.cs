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

public static class SwapExtension
{
    public static void Swap<T>(this T[] a, int i1, int i2)
    {
        T t = a[i1];
        a[i1] = a[i2];
        a[i2] = t;
    }
}
class Solution
{
    
    static int recursive(int[] arr,int swapcount)
    {
        int leftindex = -1, rightindex = -1;

        for (int i = 0; i < arr.Length-1; i++)
        {
            if (arr[i] > arr[i+1])
            {
                leftindex = i;
                rightindex = i + 1;

                for(int j= i + 1; j < arr.Length - 1; j++)
                {
                    if(arr[j] > arr[j+1] && arr[leftindex] > arr[j+1])
                    {
                        rightindex = j + 1;
                        break;
                    }
                }

                arr.Swap(leftindex, rightindex);
                swapcount++;
                break;               
            }            
        }

        if(leftindex == -1 && rightindex == -1)
        {
            return swapcount;
        }
        else
        {
            return recursive(arr,swapcount);
        }
    }
    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr)
    {
        int result = recursive(arr, 0);
        return result;
    }

    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");

        int n = Convert.ToInt32(lines[0]);

        int[] arr = Array.ConvertAll(lines[1].Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);
        Console.WriteLine(res);
        Console.Read();

    }
}
