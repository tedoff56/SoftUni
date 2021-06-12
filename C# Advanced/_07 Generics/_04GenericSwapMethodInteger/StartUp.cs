using System;
using System.Linq;

namespace _04GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Swaper<int> swaper = new Swaper<int>();
            
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                swaper.Add(number);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            swaper.Swap(indexes[0], indexes[1]);

            Console.WriteLine(swaper);
        }
    }
}