using System;
using System.Linq;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> append = s => Console.WriteLine($"Sir {s}");
            
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(append);
        }
    }
}