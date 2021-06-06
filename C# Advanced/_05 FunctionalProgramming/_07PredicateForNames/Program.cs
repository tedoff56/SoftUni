using System;
using System.Linq;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> filter = name => name.Length <= maxLength;
            
            Action<string[]> printResult = n => n.ToList().ForEach(n => Console.WriteLine(n));
            
            names = GetNames(names, filter);

            printResult(names);
        }

        public static string[] GetNames(string[] names, Func<string, bool> filter)
            => names.Where(filter).ToArray();
    }
}