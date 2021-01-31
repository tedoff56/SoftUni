using System;
using System.Linq;

namespace Array_Rotation_04
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            
            for (int j = 0; j < n; j++)
            {
                int firstNumber = numbers[0];
            
                for (int i = 1; i < numbers.Length; i++)
                {
                    numbers[i - 1] = numbers[i];
                }
                numbers[numbers.Length - 1] = firstNumber;
            }
            Console.WriteLine(string.Join(" ", numbers));
            
        }
    }
}
