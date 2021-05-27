using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[][] matrix = new char[dimension[0]][];
            FillMatrix(dimension, matrix);

            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> snakeQueue = new Queue<char>(snake);

            for (int i = 0; i < dimension[0]; i++)
            {
                for (int j = 0; j < dimension[1]; j++)
                {
                    if (snakeQueue.Count == 0)
                    {                    
                        snakeQueue = new Queue<char>(snake); ;
                    }

                    matrix[i][j] = snakeQueue.Dequeue();
                }
                
                if (i % 2 != 0)
                {
                    Array.Reverse(matrix[i]);
                }
            }
            
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[] dimension, char[][] matrix)
        {
            for (int i = 0; i < dimension[0]; i++)
            {
                matrix[i] = new char[dimension[1]];
            }
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[i]));
            }
        }
    }
}