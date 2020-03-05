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

    // Complete the rotLeft function below.
    static int[] rotLeft(int[] a, int d)
    {
        //var newarray = new int[a.Length];
        ////Array.Copy(a, 1, newarray, 0, a.Length - 1);
        //Buffer.BlockCopy(a, 0, newarray, 0, a.Length * sizeof(int));
        //newarray[newarray.Length - 1] = a[0];
        //d--;
        //if (d == 0)
        //    return newarray;
        //else return rotLeft(newarray,d);

        IEnumerable<int> newEnd = a.Take(d);
        IEnumerable<int> newBegin = a.Skip(d);
        return newBegin.Concat(newEnd).ToArray();
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");

        //string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(lines[0].Split(' ')[0]);

        int d = Convert.ToInt32(lines[0].Split(' ')[1]);

        int[] a = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] result = rotLeft(a, d);

        Console.WriteLine(result);
        Console.Read();
        //textWriter.WriteLine(string.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}