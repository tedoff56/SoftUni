using System;
using System.Linq;

namespace _03GenericSwapMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Swaper<string> swaper = new Swaper<string>();
            
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                swaper.Add(str);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            swaper.Swap(indexes[0], indexes[1]);

            Console.WriteLine(swaper);
        }
    }
}