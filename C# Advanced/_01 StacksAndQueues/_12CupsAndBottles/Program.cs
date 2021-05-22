using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cupsCapacityQueue = new Queue<int>(cupsCapacity);
            Stack<int> filledBottlesStack = new Stack<int>(filledBottles);

            while (true)
            {
                int filledBottleCapacity = filledBottlesStack.Peek();
                int cupCapacity = cupsCapacityQueue.Peek();

                cupCapacity -= filledBottleCapacity;
                
                if (filledBottleCapacity > cupCapacity)
                {
                    if (cupCapacity <= 0)
                    {
                        cupsCapacityQueue.Dequeue();
                    }
                }
                else
                {
                    filledBottlesStack.Pop();
                }
                

            }
        }
    }
}