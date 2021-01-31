using System;
using System.Linq;

namespace Top_Integers_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTopNumber = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isTopNumber = false;
                        break;
                    }
                }
                if(isTopNumber)
                    Console.Write($"{numbers[i]} ");
            }
        }
    }
}