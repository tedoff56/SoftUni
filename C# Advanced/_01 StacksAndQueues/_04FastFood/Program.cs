using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var quantity = int.Parse(Console.ReadLine());

            var orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (true)
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }

                if (quantity - orders.Peek() < 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }

                quantity -= orders.Dequeue();
            }
        }
    }
}