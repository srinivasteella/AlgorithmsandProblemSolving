using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input0.txt");
            int[] q = Array.ConvertAll(lines[0].Split(' '), qTemp => Convert.ToInt32(qTemp));
            int index = binarysearch(q,17);
            Console.WriteLine("Found at:"+index);
            Console.Read();
        }

        static int binarysearch(int[] arr,int value)
        {
            int left = 0;
            int right = arr.Length - 1;
            while(left <= right)
            {
                int mid = left + ((right - left) / 2);
                if(arr[mid] == value)
                {
                    return mid;
                }
                else if(value < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
