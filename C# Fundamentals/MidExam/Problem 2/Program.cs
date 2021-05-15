using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[]args)
        {
            List<string> friends = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Report")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = tokens[0];

                if (action == "Blacklist")
                {
                    string name = tokens[1];

                    if (friends.Contains(name))
                    {
                        friends[friends.IndexOf(name)] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                    
                }
                else if (action == "Error")
                {
                    int index = int.Parse(tokens[1]);
                    string name = friends[index];
                    
                    if (name != "Blacklisted")
                    {
                        if (name != "Lost")
                        {
                            friends[index] = "Lost";
                            Console.WriteLine($"{name} was lost due to an error.");
                        }
                    }
                    
                }
                else if (action == "Change")
                {
                    int index = int.Parse(tokens[1]);
                    string newName = tokens[2];

                    bool indexInRange = index >= 0 && index < friends.Count;

                    if (indexInRange)
                    {
                        string currentName = friends[index];
                        friends[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }

                command = Console.ReadLine();
            }

            int blacklistedCnt = friends.Where(n => n == "Blacklisted").Count();
            int lostCnt = friends.Where(n => n == "Lost").Count();
            
            Console.WriteLine($"Blacklisted names: {blacklistedCnt}");
            Console.WriteLine($"Lost names: {lostCnt}");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}