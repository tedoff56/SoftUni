using System;

namespace _07KnightGame
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine() ?? string.Empty);

            char[][] board = new char[size][];

            for (int i = 0; i < size; i++)
            {
                board[i] = Console.ReadLine()?.ToCharArray();
            }

            int removedKnights = 0;
            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttacks = 0;
                
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i][j] == '0')
                        {
                            continue;
                        }

                        int attacks = CountAttacks(i, j, board);
                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            knightRow = i;
                            knightCol = j;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[knightRow][knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnights);

        }
        
        private static int CountAttacks(int row, int col, char[][] board)
        {
            int attacks = 0;
            
            if (IsKnight(row - 1, col + 2, board))
                attacks++;
            
            if (IsKnight(row + 1, col + 2, board))
                attacks++;

            if (IsKnight(row - 1, col - 2, board))
                attacks++;

            if (IsKnight(row + 1, col - 2, board))
                attacks++;

            if (IsKnight(row - 2, col + 1, board))
                attacks++;

            if (IsKnight(row + 2, col + 1, board))
                attacks++;

            if (IsKnight(row - 2, col - 1, board))
                attacks++;

            if (IsKnight(row + 2, col - 1, board))
                attacks++;

            return attacks;
        }

        private static bool IsKnight(int row, int col, char[][] board)
        {
            return row >= 0 && row < board.GetLength(0) && 
                   col >= 0 && col < board.GetLength(0) && 
                   board[row][col] == 'K';
        }

    }
}