using System;
using System.Linq;

namespace _04MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();;

            string[,] matrix = ReadMatrix(dimensions);
            
            
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "END")
                {
                    return;
                }
                
                bool isValid = 
                    tokens.Length == 5 && tokens[0] == "swap" && 
                    int.Parse(tokens[1]) < matrix.GetLength(0) && 
                    int.Parse(tokens[2]) < matrix.GetLength(1);
                
                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);
                
                string oldValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = oldValue;
                
                PrintMatrix(matrix);
            }
        }

        private static string[,] ReadMatrix(int[] dimensions)
        {
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}