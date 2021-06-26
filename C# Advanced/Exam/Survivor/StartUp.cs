using System;
using System.Linq;

namespace Survivor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] beach = new char[n][];

            int tokens = 0;
            int opponentTokens = 0;
            for (int i = 0; i < n; i++)
            {
                beach[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
            }
            
            while (true)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Gong")
                {
                    break;
                }
                
                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                
                switch (command)
                {
                    case "Find":
                        if (IsValid(row, col, beach))
                        {
                           tokens += CollectIfToken(row, col, beach);
                        }

                        break;
                    case "Opponent":
                        if (IsValid(row, col, beach))
                        {
                            string direction = data[3];
                            
                            opponentTokens += CollectIfToken(row, col, beach);

                            if (direction == "up")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    row--;
                                    if (IsValid(row, col, beach))
                                    {
                                        opponentTokens += CollectIfToken(row, col, beach);
                                    }
                                    else
                                    {
                                        ++row;
                                        break;
                                    }
                                }
                            }
                            else if (direction == "down")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    row++;
                                    if (IsValid(row, col, beach))
                                    {
                                        opponentTokens += CollectIfToken(row, col, beach);
                                    }
                                    else
                                    {
                                        --row;
                                        break;
                                    }
                                }
                            }
                            else if (direction == "left")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    col--;
                                    if (IsValid(row, col, beach))
                                    {
                                        opponentTokens += CollectIfToken(row, col, beach);
                                    }
                                    else
                                    {
                                        ++col;
                                        break;
                                    }
                                }
                            }
                            else if (direction == "right")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    col++;
                                    if (IsValid(row, col, beach))
                                    {
                                        opponentTokens += CollectIfToken(row, col, beach);
                                    }
                                    else
                                    {
                                        --col;
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(' ', row));
            }

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
            
        }
        
        private static bool IsValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int CollectIfToken(int row, int col, char[][] beach)
        {
            if (beach[row][col] == 'T')
            {
                beach[row][col] = '-';
                return 1;
            }

            return 0;
        }
    }
    
    
}