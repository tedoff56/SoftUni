using System;
using System.Linq;

namespace _07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? string.Empty);

            char[][] board = new char[size][];

            for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();

                board[i] = row.ToArray();
            }

            int minimumKnights = int.MaxValue;
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int toBeRemoved = 0;
                    
                    if (board[i][j] == '0')
                    {
                        continue;
                    }

                    if (isKnight(i - 1, j + 2, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i + 1, j + 2, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i - 1, j - 2, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i + 1, j - 2, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i - 2, j + 1, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i + 2, j + 1, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i - 2, j - 1, board))
                    {
                        toBeRemoved++;
                    }
                    else if (isKnight(i + 2, j - 1, board))
                    {
                        toBeRemoved++;
                    }

                    if (toBeRemoved < minimumKnights)
                    {
                        minimumKnights = toBeRemoved;
                    }
                }
            }

            Console.WriteLine(minimumKnights);
            
        }
        
        private static bool isKnight(int row, int col, char[][] board)
        {
            bool isIndexValid = row >= 0 && row < board.GetLength(0) && 
                                col >= 0 && col < board.GetLength(1);
            
            return isIndexValid && board[row][col] == 'K';
        }


    }
}