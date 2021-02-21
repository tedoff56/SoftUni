using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_List_02
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> shoppingList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Go Shopping!")
                {
                    Console.WriteLine(string.Join(", ", shoppingList));
                    break;
                }
                
                string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string item = commands[1];

                if (command == "Urgent")
                {
                    if (!shoppingList.Contains(item))
                    {
                        shoppingList.Insert(0, item);
                    }
                }
                else if (command == "Unnecessary")
                {
                    if (shoppingList.Contains(item))
                    {
                        shoppingList.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string oldItem = item;
                    string newItem = commands[2];
                    int oldItemIndex = shoppingList.IndexOf(item);
                    
                    if (shoppingList.Contains(oldItem))
                    {
                        shoppingList.Remove(oldItem);   
                        shoppingList.Insert(oldItemIndex, newItem);
                    }
                }
                else if (command == "Rearrage")
                {
                    if (shoppingList.Contains(item))
                    {
                        shoppingList.Remove(item);  
                        shoppingList.Add(item);
                    }
                }
            }
            
        }
    }
}