using System;
using System.Linq;

namespace Zig_Zag_Arrays_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (var i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                
                        if(i % 2 == 0)
                        {
                            firstArr[i] = numbers[0];
                            secondArr[i] = numbers[1];
                        }
                        else
                        {
                            firstArr[i] = numbers[1];
                            secondArr[i] = numbers[0];
                        }
                
            }
            
            for (var i = 0; i < firstArr.Length; i++)
            {
                Console.Write($"{firstArr[i]} ");
            }
                Console.WriteLine("");
            for (var i = 0; i < firstArr.Length; i++)
            {
                Console.Write($"{secondArr[i]} ");
            }
            
        }
    }
}