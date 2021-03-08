using System;
using System.Collections.Generic;

namespace SoftUni_Parking_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> usersDataBase = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string command = tokens[0];
                string name = tokens[1];

                if (command == "register")
                {
                    string licensePlateNumber = tokens[2];

                    if (usersDataBase.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        usersDataBase.Add(name, licensePlateNumber);
                        Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
                    }

                }
                else if (command == "unregister")
                {
                    if (!usersDataBase.ContainsKey((name)))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        usersDataBase.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    
                }
            }

            foreach (var user in usersDataBase)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}