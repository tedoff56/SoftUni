using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            string filter = Console.ReadLine();

            Predicate<int> predicate = n => filter?.ToLower() == "odd" ? n % 2 != 0 : n % 2 == 0;
            
            List<int> result = new List<int>();
            
            for (int i = nums[0]; i <= nums[1]; i++)
            {
                result.Add(i);
            }

            Console.WriteLine(string.Join(' ', result.Where(n => predicate(n))));
        }
    }
}