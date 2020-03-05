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
    static void minimumBribes(int[] q)
    {
        int noofshifts = 0;

        int[] actualarray = new int[q.Length];
        for (int i = 0; i < q.Length; i++)
        {
            actualarray[i] = i + 1;
        }

        int noofits = iterator(q,actualarray,ref noofshifts,0);

        if(noofits == -1)
        {
            Console.WriteLine("Too chaotic");
        }
        else
        {
            Console.WriteLine(noofits);

        }


    }


    static int search(int[] arr, int n, int x)
    {
        // 1st comparison 
        if (arr[n - 1] == x)
            return n-1;

        int backup = arr[n - 1];
        arr[n - 1] = x;
        
        // no termination condition and thus 
        // no comparison 
        for (int i = 0; ; i++)
        {
            
            // this would be executed at-most n times 
            // and therefore at-most n comparisons 
            if (arr[i] == x)
            {

                // replace arr[n-1] with its actual element 
                // as in original 'arr[]' 
                arr[n - 1] = backup;

                // if 'x' is found before the '(n-1)th' 
                // index, then it is present in the array 
                // final comparison 
                if (i < n - 1)
                    return i;

                // else not present in the array 
                return -1;
            }
        }
    }

    public static int FindIndex(IReadOnlyCollection<int> source, int value)
    {
        int index = 0;
        var comparer = EqualityComparer<int>.Default; // or pass in as a parameter
        foreach (int item in source)
        {
            if (comparer.Equals(item, value)) return index;
            index++;
        }
        return -1;
    }

    static int iterator(int[] final, int[] start,ref int noofshifts,int currentpointer)
    {
        bool shiftoccured = false;
        try
        {
            for (int i = currentpointer; i < final.Length; i++)
            {
                int index = FindIndex(start,final[i]);
                //int index = search(start,start.Length,final[i]);
                //int index = start.ToList().FindIndex(a => a == final[i]);
                //Console.WriteLine("Custom:"+ indexb);
                Console.WriteLine("General:" + index);
                if (index - i > 2)
                {
                    noofshifts = -1;
                    break;
                }
                ShiftElement(ref start, index, i, ref shiftoccured, ref noofshifts);
                if (shiftoccured)
                {
                    currentpointer = i + 1;
                    return iterator(final, start, ref noofshifts, currentpointer);
                }
            }
        }
        catch(Exception e)
        {

        }
        return noofshifts;
    }
    static void ShiftElement(ref int[] array, int oldIndex, int newIndex,ref bool shiftoccured,ref int noofshifts)
    {
        // TODO: Argument validation
        if (oldIndex == newIndex)
        {
            return; // No-op
        }
        int tmp = array[oldIndex];
        if (newIndex < oldIndex)
        {            
            noofshifts = noofshifts + (oldIndex - newIndex);
            shiftoccured = true;
            // Need to move part of the array "up" to make room
            //Array.Copy(array, newIndex, array, newIndex + 1, oldIndex - newIndex);
            Buffer.BlockCopy(array, newIndex*sizeof(int), array, (newIndex + 1) * sizeof(int), (oldIndex - newIndex) * sizeof(int));

        }
        else
        {           
            noofshifts = noofshifts + (newIndex - oldIndex);

            shiftoccured = true;
            // Need to move part of the array "down" to fill the gap
            //Array.Copy(array, oldIndex + 1, array, oldIndex, newIndex - oldIndex);
            Buffer.BlockCopy(array, (oldIndex + 1) * sizeof(int), array, oldIndex * sizeof(int), (newIndex - oldIndex) * sizeof(int));

        }
        array[newIndex] = tmp;
    }
    static void Main(string[] args)
    {



        //int t = Convert.ToInt32(Console.ReadLine());

        //for (int tItr = 0; tItr < t; tItr++)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());

        //    int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
        //    ;
        //    minimumBribes(q);
        //}

        // int t = Convert.ToInt32(Console.ReadLine());
        string[] lines = System.IO.File.ReadAllLines(@"input5.txt");
        //int n = Convert.ToInt32(lines[1]);
        int[] q = Array.ConvertAll(lines[1].Split(' '), qTemp => Convert.ToInt32(qTemp));
        minimumBribes(q);

        //for (int tItr = 0; tItr < lines[0].Length; tItr++)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());

        //    int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
        //    ;
        //    minimumBribes(q);
        //}

        Console.Read();
    }
}
