using System;
using System.Linq;

namespace _12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> charSum = (name, number) => name.ToCharArray().Sum(c => c) >= number;

            if(names.Length > 0)
            {
                Console.WriteLine(Action(names, charSum, n)[0]);
            }

        }
        private static string[] Action(string[] names, Func<string, int, bool> func, int num)
        {
            return names.Where(name => func(name, num)).ToArray();
        }
    }
}