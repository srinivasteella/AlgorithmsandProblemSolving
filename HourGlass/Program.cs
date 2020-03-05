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

    // Complete the hourglassSum function below.
    static int hourglassSum(int[,] arr)
    {
        Console.WriteLine(arr[5,1]);

        return 0;
    }

    static void Main(string[] args)
    {

        int[,] arr = new int[,] { { 1,1,1,0,0,0 }, { 0,1,0,0,0,0 },
            {1,1,1,0,0,0}, {0,0,0,0,0,0}, {0,0,0,0,0,0}, {0,10,0,0,0,0} };

        //for (int i = 0; i < 6; i++)
        //{
        //    arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        //}

        int result = hourglassSum(arr);


        //int[] array = new int[] { 1, 2, 3, 4 };
        //Console.WriteLine(array.GetLength(0));

        //// Two-dimensional array.
        //int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        //Console.WriteLine(array2D.GetLength(0));
        //// The same array with dimensions specified.
        //int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        //// A similar array with string elements.
        //string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
        //                                { "five", "six" } };

        
        //// The same array with dimensions specified.
        //int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
        //                               { { 7, 8, 9 }, { 10, 11, 12 } } };

        //// Accessing array elements.
        ////System.Console.WriteLine(array2D[0, 0]);
        ////System.Console.WriteLine(array2D[0, 1]);
        ////System.Console.WriteLine(array2D[1, 0]);
        ////System.Console.WriteLine(array2D[1, 1]);
        ////System.Console.WriteLine(array2D[3, 0]);
        ////System.Console.WriteLine(array2Db[1, 0]);
        ////System.Console.WriteLine(array3Da[1, 0, 1]);
        ////System.Console.WriteLine(array3D[1, 1, 2]);

        //// Getting the total count of elements or the length of a given dimension.

        //// Three-dimensional array.
        //int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
        //                         { { 7, 8, 9 }, { 10, 11, 12 } } };

      

        //var allLength = array3D.Length;
        //var total = 1;
        //for (int i = 0; i < array3D.Rank; i++)
        //{
        //    total *= array3D.GetLength(i);
        //}
        //System.Console.WriteLine("{0} equals {1}", allLength, total);
        Console.Read();
    }
}
