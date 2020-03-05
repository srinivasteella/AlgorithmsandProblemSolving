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

namespace _1Test1
{
    class Result
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            int arrCount = Convert.ToInt32(lines[0]);

            List<int> arr = new List<int>();

            for (int i = 1; i < arrCount+1; i++)
            {
                int arrItem = Convert.ToInt32(lines[i]);
                arr.Add(arrItem);
            }

            List<int> result = getDistanceMetrics(arr);
            foreach(var item in result)
            Console.WriteLine(item);
            Console.Read();
        }

        static List<int> getDistanceMetrics(List<int> arr)
        {
            //create a hashtable to maintain index and value 
            var hasharr = new Hashtable(Enumerable.Range(1, arr.Count()).ToDictionary(x => x-1, x => arr[x - 1]));

            //get distict values
            var dist = arr.Distinct().ToArray();
            var newhasharr = new Hashtable(Enumerable.Range(1, arr.Count()).ToDictionary(x => x - 1, x => 0)); 
            for(int i = 0; i < dist.Length; i++)
            {
                var result = hasharr.Cast<DictionaryEntry>().Where(e => Convert.ToInt32(e.Value) == dist[i]).ToArray();
                int index = result.Length-1;
                calindex(result, ref newhasharr,ref index);             
                   
            }
            
            return newhasharr.Values.Cast<int>().ToList();
        }

        static void calindex(DictionaryEntry[] array,ref Hashtable tbl,ref int index)
        {
            int startindex = Convert.ToInt32(array[index].Key);
            int localindex = index - 1;
            while (localindex >= 0)
            {
                if (startindex > Convert.ToInt32(array[localindex].Key))
                {
                    tbl[startindex] = Convert.ToInt32(tbl[startindex]) + (startindex - Convert.ToInt32(array[localindex].Key));
                    tbl[array[localindex].Key] = Convert.ToInt32(tbl[array[localindex].Key]) + (startindex - Convert.ToInt32(array[localindex].Key));
                }
                else
                {
                    tbl[startindex] = Convert.ToInt32(tbl[startindex]) + (Convert.ToInt32(array[localindex].Key) - startindex);
                    tbl[array[localindex].Key] = Convert.ToInt32(tbl[array[localindex].Key]) + (Convert.ToInt32(array[localindex].Key) - startindex);
                }

                localindex--;
            }

            index = index - 1;
            if (index > 0)
                calindex(array, ref tbl, ref index);
        }
    }
}
