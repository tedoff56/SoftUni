using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            ReadMatrix(matrix);

            AnalyzingMatrix(matrix);

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    PrintMatrix(matrix);
                    return;
                }
                
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                bool indexesAreValid = row < rows && row >= 0 && col < matrix[row].Length && col >= 0;
                if(!indexesAreValid)
                {
                    continue;
                }
                
                switch (tokens[0])
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }
            }
        }

        private static void ReadMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
            }
        }

        static void AnalyzingMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            
            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }

                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }
            }
        }
        static void PrintMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }
    }
}