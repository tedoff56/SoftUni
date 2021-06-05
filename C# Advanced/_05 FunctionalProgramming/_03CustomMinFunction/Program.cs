using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = n => n.Min();
            
            Console.WriteLine(minNumber(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()));

        }
    }
}