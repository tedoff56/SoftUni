using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbersQueue = new Queue<int>();

            for (var i = 0; i < tokens[0]; i++) numbersQueue.Enqueue(numbers[i]);

            for (var i = 0; i < tokens[1]; i++) numbersQueue.Dequeue();

            if (numbersQueue.Count == 0)
                Console.WriteLine(0);
            else if (numbersQueue.Contains(tokens[2]))
                Console.WriteLine("true");
            else
                Console.WriteLine(numbersQueue.Min());
        }
    }
}