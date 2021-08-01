using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] beeTerritory = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < beeTerritory.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < beeTerritory.GetLength(1); col++)
                {
                    if (rowData[col] != 'B')
                    {
                        beeTerritory[row, col] = rowData[col];
                        continue;
                    }

                    beeTerritory[row, col] = '.';
                    beeRow = row;
                    beeCol = col;
                }
            }

            int pollinatedFlowers = 0;
            bool isOutside = false;
            
            while (!isOutside)
            {
                string direction = Console.ReadLine();

                if (direction == "End")
                {
                    break;
                }
                
                Move(direction, ref beeRow, ref beeCol);

                if(IsBeeOutside(beeRow, beeCol, beeTerritory))
                {
                    isOutside = true;
                    break;
                }
                
                if (beeTerritory[beeRow, beeCol] == 'O')
                {
                    beeTerritory[beeRow, beeCol] = '.';
                    Move(direction, ref beeRow, ref beeCol);
                }
                
                if (beeTerritory[beeRow, beeCol] == 'f')
                {
                    beeTerritory[beeRow, beeCol] = '.';
                    pollinatedFlowers++;
                }
                
            }

            if (isOutside)
            {
                Console.WriteLine("The bee got lost!");
            }
            else
            {
                beeTerritory[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine(
                    $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            for (int row = 0; row < beeTerritory.GetLength(0); row++)
            {
                for (int col = 0; col < beeTerritory.GetLength(1); col++)
                {
                    Console.Write(beeTerritory[row, col]);
                }

                Console.WriteLine();
            }

        }

        private static void Move(string direction, ref int beeRow, ref int beeCol)
        {
            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "right":
                    beeCol++;
                    break;
                case "left":
                    beeCol--;
                    break;
            }
        }

        private static bool IsBeeOutside(int beeRow, int beeCol, char[,] beeTerritory)
            =>  beeRow < 0 || beeRow >= beeTerritory.GetLength(0) ||
                beeCol < 0 || beeCol >= beeTerritory.GetLength(1);
     
    }
}