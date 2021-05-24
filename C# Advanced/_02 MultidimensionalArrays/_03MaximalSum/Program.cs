using System;
using System.Linq;

namespace _03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = ReadMatrix();

            int maxSum = 0;
            int mxRow = 0;
            int mxCol = 0;
            
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    sum += matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    sum += matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        mxRow = row;
                        mxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = mxRow; i < mxRow + 3 ; i++)
            {
                for (int j = mxCol; j < mxCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix()
        {
            int[] data = ReadIntArray();

            int[,] matrix = new int[data[0], data[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = ReadIntArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}