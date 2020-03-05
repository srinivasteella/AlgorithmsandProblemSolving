using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[]  { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] arr1 = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };
        int[] arr2 = new int[8];

        int item = arr[4];
        int index = 2;
        // Copy the first twenty bytes from arr1 to arr2
        Buffer.BlockCopy(arr, 8, arr, 12, 8);
        arr[2] = item;
        Buffer.BlockCopy(arr, 8, arr2, 12, (arr.Length-3) * sizeof(int));
        

        Display(arr2);
    }

    static void Display(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
        Console.Read();
    }
}
