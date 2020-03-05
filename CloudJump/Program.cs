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

    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c)
    {
        int numberofjumps = 0;
        numberofbestjumps(0,ref numberofjumps,c);
        return numberofjumps;
    }

     static void numberofbestjumps(int currentpath,ref int numofjums,int[] c)
    {
        
        if (currentpath+2 <= c.Length-1 && c[currentpath+2] != 1)
        {
            currentpath = currentpath + 2;
            numofjums++;
        }
        else if (currentpath + 1 <= c.Length-1)
        {
            currentpath = currentpath + 1;
            numofjums++;
        }
        if (currentpath < c.Length-1)
             numberofbestjumps(currentpath,ref numofjums, c);
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = jumpingOnClouds(c);
        Console.WriteLine(result);
        Console.Read();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
