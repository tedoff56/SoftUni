using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumAndMinimumElement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbersStack = new Stack<int>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (tokens.Length == 2)
                {
                    numbersStack.Push(tokens[1]);
                    continue;
                    ;
                }

                if (numbersStack.Count == 0)
                    continue;
                if (tokens[0] == 2)
                    numbersStack.Pop();
                else if (tokens[0] == 3)
                    Console.WriteLine(numbersStack.Max());
                else if (tokens[0] == 4) Console.WriteLine(numbersStack.Min());
            }

            Console.WriteLine(string.Join(", ", numbersStack));
        }
    }
}