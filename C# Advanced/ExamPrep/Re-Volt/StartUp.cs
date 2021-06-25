using System;

namespace Re_Volt
{
    class StartUp
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            
            int totalCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;
            
            for (int i = 0; i < size; i++)
            {
                string rowData = Console.ReadLine();
                
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rowData[j];

                    if (matrix[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            int count = 0;
            bool finished = false;
            int[] posData = new int[] { };
            
            while (count != totalCommands && !finished)
            {
                string direction = Console.ReadLine();
                count++;
                
                matrix[playerRow, playerCol] = '-';
                
                posData = MoveToDirection(playerRow, playerCol, direction, size);
                
                playerRow = posData[0];
                playerCol = posData[1];
                
                int currentSymbol = matrix[playerRow, playerCol];
                
                if (currentSymbol == 'F')
                {
                    Console.WriteLine("Player won!");
                    finished = true;
                }
                else if (currentSymbol == 'T')
                {
                    if (direction == "up")
                    {
                        playerRow++;
                    }
                    else if (direction == "down")
                    {
                        playerRow--; }
                    else if (direction == "left")
                    {
                        playerCol++;
                    }
                    else if (direction == "right")
                    {
                        playerCol--;
                    }

                }
                else if (currentSymbol == 'B')
                {
                    posData = MoveToDirection(playerRow, playerCol, direction, size);

                    playerRow = posData[0];
                    playerCol = posData[1];

                }
            }
            
            matrix[playerRow, playerCol] = 'f';
            
            if (!finished)
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
        private static bool IsValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
        
        private static int[] MoveToDirection(int playerRow, int playerCol, string direction, int size)
        {
            switch (direction)
            {
                case "up":
                    playerRow--;
                    playerRow = !IsValid(playerRow, playerCol, size) ? size - 1 : playerRow;
                    break;
                
                case "down":
                    playerRow++;
                    playerRow = !IsValid(playerRow, playerCol, size) ? 0 : playerRow;
                    break;
                
                case "left":
                    playerCol--;
                    playerCol = !IsValid(playerRow, playerCol, size) ? size - 1 : playerCol;
                    break;
                
                case "right":
                    playerCol++;
                    playerCol = !IsValid(playerRow, playerCol, size) ? 0 : playerCol;
                    break;
            }

            return new[] {playerRow, playerCol};
        }
    }
}