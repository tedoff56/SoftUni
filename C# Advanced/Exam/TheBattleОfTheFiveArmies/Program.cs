using System;

namespace TheBattleОfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            int armyRow = -1;
            int armyCol = -1;
            
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (rowData[col] != 'A')
                    {
                        field[row, col] = rowData[col];
                        continue;
                    }

                    field[row, col] = '-';
                    armyRow = row;
                    armyCol = col;
                }
            }

            bool armyWon = false;
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                int orcRow = int.Parse(tokens[1]);
                int orcCol = int.Parse(tokens[2]);

                field[orcRow, orcCol] = 'O';

                if (direction == "up" && armyRow > 0)
                {
                    armyRow--;
                }
                else if (direction == "down" && armyRow < field.GetLength(0) - 1)
                {
                    armyRow++;
                }
                else if (direction == "left" && armyCol > 0)
                {
                    armyCol--;
                }
                else if( direction == "right" && armyCol < field.GetLength(1) - 1)
                {
                    armyCol++;
                }

                armor--;

                if (field[armyRow, armyCol] == 'M')
                {
                    field[armyRow, armyCol] = '-';
                    armyWon = true;
                    break;
                }
                
                if (armor <= 0)
                {
                    break;
                }
                
                if (field[armyRow, armyCol] == 'O')
                {
                    armor -= 2;

                    if (armor <= 0)
                    {
                        field[armyRow, armyCol] = 'X';
                        break;
                    }
                    else
                    {
                        field[armyRow, armyCol] = '-';
                    }
                }

            }


            if (armyWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");

            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
            
        }
    }
}