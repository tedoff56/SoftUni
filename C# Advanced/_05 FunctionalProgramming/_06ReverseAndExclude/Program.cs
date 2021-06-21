using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            Func<int, bool> predicate = num => num % n != 0;
            
            var result = numbers.Where(predicate).Reverse();

            Console.WriteLine(string.Join(' ', result));
            
        }
    }
}