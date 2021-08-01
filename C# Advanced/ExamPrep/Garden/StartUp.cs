using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class StartUp
    {
        static void Main()
        {
            int[] gardenSizeData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = gardenSizeData[0];
            int m = gardenSizeData[1];
            
            int[][] garden = new int[n][];

            for (int row = 0; row < n; row++)
            {
                garden[row] = new int[m];
            }

            List<int[]> flowersCoordinates = new List<int[]>();
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    break;
                }
                
                int[] sizeData = command.Split().Select(int.Parse).ToArray();
                int row = sizeData[0];
                int col = sizeData[1];

                if (IsOutside(row, col, garden))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                
                flowersCoordinates.Add(new[] {row, col});
            }

            foreach (var flowerCoordinate in flowersCoordinates)
            {
                int row = flowerCoordinate[0];
                int col = flowerCoordinate[1];

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[row][i]++;
                    if (i == row)
                    {
                        continue;
                    }
                    garden[i][col]++;
                }
                
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(' ', row));
            }

        }

        private static bool IsOutside(int row, int col, int[][] garden)
            => row < 0 || row >= garden.GetLength(0) ||
               col < 0 || col >= garden[row].Length;

    }
}