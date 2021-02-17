using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers_05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int bombNumber = line[0];
            int bombPower = line[1];
            
            DetonateBomb(numbersList, bombNumber, bombPower);
            
            Console.WriteLine($"{numbersList.Sum()}");
        }

        static void DetonateBomb(List<int> numbers, int bombNumber, int bombPower)
        {
            while (true)
            {
                int bombIndex = numbers.IndexOf(bombNumber);
                int startIndex = bombIndex - bombPower;
                if (bombIndex == -1)
                {
                    break;
                }
                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int count = bombPower * 2 + 1;
                int lastIndex = numbers.Count - 1;
                if (bombPower > lastIndex - bombIndex)
                {
                    count = lastIndex - 1;
                }
                numbers.RemoveRange(startIndex, count);
            }

        }

    }
}