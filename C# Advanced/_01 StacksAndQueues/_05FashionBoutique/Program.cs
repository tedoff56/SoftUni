using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clothValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var rackCapacity = int.Parse(Console.ReadLine());

            var currentCapacity = rackCapacity;

            var neededRacks = 1;

            while (clothValues.Count > 0)
            {
                if (currentCapacity - clothValues.Peek() < 0)
                {
                    neededRacks++;
                    currentCapacity = rackCapacity;
                }

                currentCapacity -= clothValues.Pop();
            }

            Console.WriteLine(neededRacks);
        }
    }
}