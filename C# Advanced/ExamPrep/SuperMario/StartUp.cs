using System;
using System.Linq;

namespace SuperMario
{
    class StartUp
    {
        static void Main()
        {
            int lives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] dungeon = new char[rows][];

            int marioRow = -1;
            int marioCol = -1;

            bool reachedThePrincess = false;
            
            for (int i = 0; i < rows; i++)
            {
                dungeon[i] = Console.ReadLine().ToCharArray();
                if (dungeon[i].Contains('M'))
                {
                    marioRow = i;
                    marioCol = dungeon[i].ToList().IndexOf('M');
                }
            }

            dungeon[marioRow][marioCol] = '-';
            
            while (lives > 0 && !reachedThePrincess)
            {
                char[] tokens = Console.ReadLine().Split().Select(char.Parse).ToArray();

                char command = tokens[0];
                int spawnRow = tokens[1] - '0';
                int spawnCol = tokens[2] - '0';

                dungeon[spawnRow][spawnCol] = 'B';

                lives--;
                
                switch (command)
                {
                    case 'W':
                        marioRow = IsValid(marioRow - 1, marioCol, dungeon) ? --marioRow : marioRow;
                        break;
                    case 'S':
                        marioRow = IsValid(marioRow + 1, marioCol, dungeon) ? ++marioRow : marioRow;
                        break;
                    case 'A':
                        marioCol = IsValid(marioRow, marioCol - 1, dungeon) ? --marioCol : marioCol;
                        break;
                    case 'D':
                        marioCol = IsValid(marioRow, marioCol + 1, dungeon) ? ++marioCol : marioCol;
                        break;
                }

                int currentSymbol = dungeon[marioRow][marioCol];

                if (currentSymbol == 'B')
                {
                    lives = lives - 2;
                    
                }
                else if (currentSymbol == 'P')
                {
                    reachedThePrincess = true;
                }

                if (lives <= 0)
                {
                    dungeon[marioRow][marioCol] = 'X';
                }
                else
                {
                    dungeon[marioRow][marioCol] = '-';
                }
            }

            if (reachedThePrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            foreach (var row in dungeon)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static bool IsValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}