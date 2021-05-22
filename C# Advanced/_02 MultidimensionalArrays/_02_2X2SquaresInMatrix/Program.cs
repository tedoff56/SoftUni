using System;
using System.Linq;

namespace _02_2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[rowsCols[0], rowsCols[1]];

            FillMatrix(matrix);
            
            int totalEqualSquares = GetTotalEqualSquares(matrix);

            Console.WriteLine(totalEqualSquares);
            
        }
        static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] chars = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
        }

        static int GetTotalEqualSquares(char[,] matrix)
        {
            int count = 0;
            
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    char currentChar = matrix[i, j];

                    if (matrix[i, j + 1] == currentChar && 
                        matrix[i + 1, j] == currentChar &&
                        matrix[i + 1, j + 1] == currentChar) 
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}