using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int wreathsCount = 0;

            int storedFlowers = 0;
            
            while (lilies.Count != 0 && roses.Count != 0)
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum == 15)
                {
                    wreathsCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            wreathsCount += storedFlowers / 15;
            
            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }
        }
    }
}