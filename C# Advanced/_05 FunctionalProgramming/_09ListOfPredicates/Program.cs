using System;
using System.Linq;


namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int, bool> divisible = (nums, d) =>
            {
                bool isDivisible = true;

                foreach (var num in nums)
                {
                    if (d % num != 0)
                    {
                        isDivisible = false;
                    }
                }
                
                return isDivisible;
            };


            var result = Enumerable.Range(1, n).Where(num => divisible(dividers, num));

            Console.WriteLine(string.Join(' ', result));


        }
    }
}