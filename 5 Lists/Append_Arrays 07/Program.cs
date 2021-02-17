using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays_07
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrays = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            
            List<string> finalList = new List<string>();
            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                string[] pieces = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                finalList.AddRange(pieces);
            }

            Console.WriteLine(string.Join(" ", finalList));

        }
    }
}