using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            int foodQuantity = 0;
            
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    if (rowData[col] != 'S')
                    {
                        territory[row, col] = rowData[col];
                        continue;
                    }
                    
                    snakeRow = row;
                    snakeCol = col;
                    territory[row, col] = '.';
                }
            }

            bool isSnakeOutside = false;
            while (foodQuantity < 10 && !isSnakeOutside)
            {
                
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }
                
                if(IsSnakeOutside(snakeRow, snakeCol, territory))
                {
                    isSnakeOutside = true;
                    break;
                }
                
                if (territory[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                else if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';
                    GoInsideBurrow(ref snakeRow, ref snakeCol, territory);
                }

                territory[snakeRow, snakeCol] = '.';

            }

            if (isSnakeOutside)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                territory[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");


            PrintTerritory(territory);

        }

        private static bool IsSnakeOutside(int snakeRow, int snakeCol, char[,] territory)
         => snakeRow < 0 || snakeRow >= territory.GetLength(0) ||
            snakeCol < 0 || snakeCol >= territory.GetLength(1);
        
        private static void GoInsideBurrow(ref int snakeRow, ref int snakeCol, char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    if (territory[row, col] == 'B')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        return;
                    }
                }
            }
        }

        private static void PrintTerritory(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
            
        }
    }
}