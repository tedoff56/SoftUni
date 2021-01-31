using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] realNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int i = 0; i < realNumbers.Length; i++)
            {
                Console.Write(Math.Round(realNumbers[i], MidpointRounding.AwayFromZero) + " ");
            }

        }
    }
}