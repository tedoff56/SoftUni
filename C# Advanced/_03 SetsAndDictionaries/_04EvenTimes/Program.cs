using System;
using System.Collections.Generic;

namespace _04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }
                
                numbersCount[number]++;
            }

            foreach (var kvp in numbersCount)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    return;
                }
            }
            
        }
    }
}