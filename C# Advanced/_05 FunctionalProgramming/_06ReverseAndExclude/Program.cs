using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            int divideBy = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (n, d) => n % d == 0;

            Console.WriteLine(string.Join(' ', numbers.Where(n => !isDivisible(n, divideBy)).Reverse()));

        }
    }
}