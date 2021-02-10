using System;

namespace NxN_Matrix_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            NxNMatrix(matrixSize);
        }

        static void NxNMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{size} ");
                }

                Console.WriteLine();
            }
        }
    }
}