using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> namesWhitelist = new List<string>(n);
            
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = command[0];

                if (command.Length == 3)
                {
                    if(namesWhitelist.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        namesWhitelist.Add(name);
                    }
                }
                else if (command.Length == 4)
                {
                    if (namesWhitelist.Contains(name))
                    {
                        for (int j = 0; j < namesWhitelist.Count; j++)
                        {
                            if (namesWhitelist[j] == name)
                            {
                                namesWhitelist.RemoveAt(j);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", namesWhitelist));
        }
    }
}