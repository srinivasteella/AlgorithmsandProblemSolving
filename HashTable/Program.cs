using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            int[] q = Array.ConvertAll(lines[1].Split(' '), qTemp => Convert.ToInt32(qTemp));
            calprice(q, Convert.ToInt32(lines[0]));
            Console.Read();
        }

        static void calprice(int[] arr, int value)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();            
            var flavours = new Hashtable(Enumerable.Range(1, arr.Count()).ToDictionary(x => x, x => arr[x - 1]));
            var sorted = flavours.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).ToList();

            sorted.ForEach(i =>
            {
                if (Convert.ToInt32(i.Value) < value)
                {
                    dict.Add(Convert.ToInt32(i.Key), Convert.ToInt32(i.Value));
                }
            });            

            int index = 0;
            int midpoint = dict.Values.ToArray()[dict.Count / 2];
            foreach (KeyValuePair<int, int> entry in dict)
            {                
                    int remainingamount = value - entry.Value;
                    index = binarysearch(dict.Where(k => k.Key != entry.Key).ToArray(), remainingamount);                    
                    if (index >= 0)
                    {
                    if (entry.Key < index)
                        Console.WriteLine(entry.Key + " " + index);
                    else
                        Console.WriteLine(index + " " + entry.Key);
                        break;
                    }
            }
                    
        }

        static int binarysearch(KeyValuePair<int,int>[] data, int value)
        {
            int left = 0;
            int right = data.Length-1;
            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (data[mid].Value == value)
                {
                    return data[mid].Key;
                }
                else if (value < data[mid].Value)
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
