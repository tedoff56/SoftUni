using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers_05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombData[0];
            int bombPower = bombData[1];
            
            while (numbers.Contains(bombNumber))
            {
                
                int sideBomb = (bombPower*2 + 1) / 2;
                int startIndex = numbers.IndexOf(bombNumber) - sideBomb;
                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int endIndex = numbers.IndexOf(bombNumber) + sideBomb;
                if (endIndex > numbers.Count - 1)
                {
                    endIndex = numbers.Count - 1;
                }
                
                for (int i = startIndex; i <= endIndex; i++)
                {
                    numbers.RemoveAt(startIndex);
                }
                
            }
            
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}