using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbersStack = new Stack<int>();

            for (var i = 0; i < tokens[0]; i++) numbersStack.Push(numbers[i]);

            for (var i = 0; i < tokens[1]; i++) numbersStack.Pop();

            if (numbersStack.Count == 0)
                Console.WriteLine(0);
            else if (numbersStack.Contains(tokens[2]))
                Console.WriteLine("true");
            else
                Console.WriteLine(numbersStack.Min());
        }
    }
}