using System;
using System.Linq;

namespace Magic_Sum_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == n && i != j)
                    {
                        Console.Write($"{numbers[i]} {numbers[j]}");
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}