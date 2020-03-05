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



static class LinqExtensions
{
    public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(this IEnumerable<T> items, int ofLength)
    {
        return (ofLength == 1) ?
            items.Select(item => new[] { item }) :
            items.SelectMany((item, i) => {
                //var test = items.Skip(i + 1).CombinationsWithoutRepetition(ofLength - 1).Select(result => new T[] { item }.Concat(result));
                return items.Skip(i + 1)
                                                   .CombinationsWithoutRepetition(ofLength - 1)
                                                   .Select(result => new T[] { item }.Concat(result));
                                               });
    }
    public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(this IEnumerable<T> items, int ofLength, int upToLength)
    {
        return Enumerable.Range(ofLength, Math.Max(0, upToLength - ofLength + 1))
                         .SelectMany(len => items.CombinationsWithoutRepetition(ofLength: len));
        //return Enumerable.Range(ofLength, Math.Max(0, upToLength - ofLength + 1))
        //                 .SelectMany(len => {
        //                     Console.WriteLine(len);
        //                     return items.CombinationsWithoutRepetition(ofLength: len);
        //                     });
    }

    

}


class Result
{

    /*
     * Complete the 'buildSubsequences' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING s as parameter.
     */

    public static List<string> buildSubsequences(string s)
    {
        var output = SortString(s).ToList();
        List<string> finalOutput = new List<string>();
        foreach (var c in output.CombinationsWithoutRepetition(ofLength: 1, upToLength: output.Count))
        {
            finalOutput.Add(string.Concat(c));
        }
        finalOutput.Sort();
        return finalOutput;
    }

    static IEnumerable<string> SortString(string input)
    {
        var inputList = Regex.Replace(input, @"\s+", "").Select(c => c.ToString()).ToList();
        inputList.Sort();
        return inputList;
    }


}

class Solution
{
    public static void Main(string[] args)
    {

        string s = Console.ReadLine();

        List<string> result = Result.buildSubsequences(s);

        foreach(var v in result)
        Console.WriteLine(v);
        Console.Read();
    }
}
