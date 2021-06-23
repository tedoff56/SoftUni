using System;
using System.Linq;

namespace Garden
{
    class StartUp
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();;

            int n = dimensions[0];
            int m = dimensions[1];

            int[,] garden = new int[n, m];

            string line = Console.ReadLine();
            while (line != "Bloom Bloom Plow")
            {
                int[] position = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int row = position[0];
                int col = position[1];

                bool isValid = row >= 0 && row < n && col >= 0 && col < m;
                if (!isValid)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                
                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[i, col]++;
                }
                
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[row, j]++;
                }

                garden[row, col]--;
                
                line = Console.ReadLine();
            }


            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

    }
}