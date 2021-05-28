using System;
using System.Linq;


namespace _08Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = ReadIntMatrix(n);

            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string indexes in bombs)
            {
                int[] bombIndexes = indexes.Split(',').Select(int.Parse).ToArray();

                int bombRow = bombIndexes[0];
                int bombCol = bombIndexes[1];

                int bombPower = matrix[bombRow, bombCol];
                if (bombPower <= 0)
                {
                    continue;
                }

                ExplodeIfValid(bombRow - 1, bombCol - 1, bombPower, matrix);
                ExplodeIfValid(bombRow - 1, bombCol, bombPower, matrix);
                ExplodeIfValid(bombRow - 1, bombCol + 1, bombPower, matrix);

                ExplodeIfValid(bombRow, bombCol - 1, bombPower, matrix);
                matrix[bombRow, bombCol] = 0;
                ExplodeIfValid(bombRow , bombCol + 1, bombPower, matrix);

                ExplodeIfValid(bombRow + 1, bombCol - 1, bombPower, matrix);
                ExplodeIfValid(bombRow + 1, bombCol, bombPower, matrix);
                ExplodeIfValid(bombRow + 1, bombCol + 1, bombPower, matrix);
                
            }

            int sumOfCells = 0;
            int aliveCells = 0;

            foreach (var cell in matrix)
            {
                if(cell > 0)
                {
                    aliveCells++;
                    sumOfCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            PrintMatrix(matrix);
        }

        private static int[,] ReadIntMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            
            for (int i = 0; i < n; i++)
            {
                int[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            return matrix;
        }

        static void ExplodeIfValid(int row, int col,int bombPower, int[,] matrix)
        {
            bool isValid = row >= 0 && row < matrix.GetLength(0) && 
                           col >= 0 && col < matrix.GetLength(1) && 
                           matrix[row, col] > 0;
            
            if(isValid)
            {
                matrix[row, col] -= bombPower;
            }
        }

        static void PrintMatrix(int[,] matrix)
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