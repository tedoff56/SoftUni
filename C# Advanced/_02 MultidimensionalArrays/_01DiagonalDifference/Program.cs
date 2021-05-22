using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);
            
            int firstDiagonalSum = GetFirstDiagonal(n, matrix);
            int secondDiagonalSum = GetSecondDiagonal(n, matrix);
            
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }

        static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] rowNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }
        }
        static int GetFirstDiagonal(int n, int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                sum += matrix[row, row];
            }

            return sum;
        }
        
        static int GetSecondDiagonal(int n, int[,] matrix)
        {
            int sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int j = Math.Abs(i - n + 1);
                sum += matrix[i, j];
            }
            
            return sum;
        }
    }
}