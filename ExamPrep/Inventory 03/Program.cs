using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(",", StringSplitOptions.TrimEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Craft!")
                {
                    break;
                }

                string[] commands = line.Split("-", StringSplitOptions.TrimEntries);

                string action = commands[0];
                string item = commands[1];

                if (action == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    items.Remove(item);
                }
                else if (action == "Combine Items")
                {
                    string[] parameters = item.Split(":", StringSplitOptions.TrimEntries).ToArray();

                    string oldItem = parameters[0];
                    string newItem = parameters[1];
                    
                    if (items.Contains(oldItem))
                    {
                        items.Insert(items.IndexOf(oldItem) + 1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    if (items.Contains(item))
                    {
                        items.Add(item);
                        items.Remove(item);
                    }
                }

            }

            Console.WriteLine(string.Join(", ", items));

        }
    }
}