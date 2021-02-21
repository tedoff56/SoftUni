using System;
using System.Collections.Generic;
using System.Linq;

namespace Heart_Delivery_0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int neighborhoodCnt = neighborhood.Count;
            
            int houseIndex = 0;
            while (true)
            {
                string line = Console.ReadLine();
                int failedHousesCnt = neighborhood.Where(n => n != 0).Count();
                if (line == "Love!")
                {
                    Console.WriteLine($"Cupid's last position was {houseIndex}.");
                    if (neighborhood.Where(n => n == 0).Count() == neighborhoodCnt)
                    {
                        Console.WriteLine("Mission was successful.");
                    }
                    else
                    {
                        Console.WriteLine($"Cupid has failed {failedHousesCnt} places.");
                    }
                    break;
                }

                string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                int length = int.Parse(commands[1]);
                
                houseIndex += length;
                
                if (houseIndex >= neighborhood.Count)
                {
                    houseIndex = 0;
                }
                if(neighborhood[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                    continue;
                }
                neighborhood[houseIndex] -= 2;
                if (neighborhood[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                }

            }
            
        }
    }
}