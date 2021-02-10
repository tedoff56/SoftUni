using System;

namespace TriangleNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            for (int i = 0; i < dimension; i++)
            {
                PrintNumbers(i);
            }

            for (int i = dimension; i > 0; i--)
            {
                PrintNumbers(i);
            }
        }

        static void PrintNumbers(int limit)
        {
            for (int i = 1; i <= limit; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}