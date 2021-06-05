using System;
using System.Linq;

namespace _01ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> newLine = s => Console.WriteLine(s);
            
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(newLine);
        }
    }
}