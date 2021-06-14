using System;
using System.Collections.Generic;
using System.Linq;

namespace _05GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var elements = new List<string>();
            
            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                elements.Add(element);
            }

            string value = Console.ReadLine();

            Console.WriteLine(Compare(elements, value));
        }

        
        private static int Compare<T>(List<T> elements, T value) where T : IComparable<T>
        {
            return elements.Where(e => e.CompareTo(value) > 0).Count();
        }
    }
}