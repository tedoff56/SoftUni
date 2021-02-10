using System;
using System.Linq;

namespace Array_Manipulator_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        static void exchange(int[] arr)
        {
            int index = int.Parse(Console.ReadLine());

        }
        
    }
}