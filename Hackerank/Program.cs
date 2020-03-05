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
    static void getStepsinNumeric(ref int level,char step)
    {
        if (step == 'U') {
            level++;
                 }
        else {
            level--;
        }
    }

    static int[] SubArray(int[] values,
    int start_index, int end_index)
    {
        int num_items = end_index - start_index + 1;
        int[] result = new int[num_items];
        Array.Copy(values, start_index, result, 0, num_items);
        return result;
    }

    // Complete the countingValleys function below.
    static int countingValleys(int n, string s)
    {
        int level = 0;
        int[] stepsinnumeric = new int[n+1];
        int i = 0;
        stepsinnumeric[0] = i;
        
        foreach (char c in s)
        {
            getStepsinNumeric(ref level, c);
            stepsinnumeric[i+1] = level;
            i++;
        }

        var totalSeaLevels = Enumerable.Range(0, stepsinnumeric.Length).Where(z => stepsinnumeric[z] == 0).ToList();
        int totalvalley = 0;
        for(int j=0;j< totalSeaLevels.Count-1; j++)
        {
            var subarray = SubArray(stepsinnumeric, totalSeaLevels[j]+1, totalSeaLevels[j + 1]-1);
            if (subarray.Any(a => a < 0))
                totalvalley++;
        }
        
        return totalvalley;

    }

    static void Main(string[] args)
    {
       // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");

        //string s = "DDUUDDUUUUDD";//lines[0];// Console.ReadLine();
        string s = lines[0];// Console.ReadLine();

        int result = countingValleys(n, s);
        Console.WriteLine(result);
        Console.Read();

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
