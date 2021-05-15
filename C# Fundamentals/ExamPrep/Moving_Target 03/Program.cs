using System;
using System.Collections.Generic;
using System.Linq;

namespace Moving_Target_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(n => n >= 1 && n <= 10000)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    Console.WriteLine(string.Join('|', targets));
                    break;
                }

                string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                int index = int.Parse(commands[1]);
                bool targetExists = index >= 0 && index < targets.Count;

                if (command == "Shoot")
                {
                    int power = int.Parse(commands[2]);

                    if (targetExists)
                    {
                        targets[index] -= power;
                        
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (command == "Add")
                {
                    int value = int.Parse(commands[2]);

                    if (targetExists)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command == "Strike")
                {
                    int radius = int.Parse(commands[2]);
                    if (targetExists)
                    {
                        if (index - radius >= 0 && index + radius < targets.Count)
                        {
                            targets.RemoveRange(index - radius, radius * 2 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                    }
                }
            }
        }
    }
}