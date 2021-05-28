using System;
using System.Collections.Generic;

namespace _03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueElements = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', uniqueElements));
        }
    }
}