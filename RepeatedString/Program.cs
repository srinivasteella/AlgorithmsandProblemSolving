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

    // Complete the repeatedString function below.
    static long repeatedString(string s, long n)
    {
        var quotient = n / s.Length;
        var allAsfromQuotient = s.ToCharArray().ToList().FindAll(a => a == 'a').Count * quotient;
        var AsfromReminder = s.Substring(0, Convert.ToInt32(n % s.Length)).ToCharArray().ToList().FindAll(a => a == 'a').Count;
        return allAsfromQuotient + AsfromReminder;
    }

    static void Main(string[] args)
    {
       // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);
        Console.WriteLine(result);
        Console.Read();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}