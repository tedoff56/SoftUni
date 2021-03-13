using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceUsers = new Dictionary<string, string>();
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }
                
                if (input.Contains(" | "))
                {
                    string[] parts = input
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = parts[0];
                    string forceUser = parts[1];
                    
                                        
                    if(forceUsers.ContainsKey(forceUser))
                    {
                        continue;;
                    }
                    
                    if(!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }
                    forceSides[forceSide].Add(forceUser);
                    forceUsers.Add(forceUser,forceSide);

                }
                else if (input.Contains(" -> "))
                {
                    string[] parts = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }
                    
                    if (forceUsers.ContainsKey(forceUser))
                    {
                        string currentSide = forceUsers[forceUser];
                        
                        forceSides[currentSide].Remove(forceUser);
                        forceSides[forceSide].Add(forceUser);
                        forceUsers[forceUser] = forceSide;
                        
                    }
                    else
                    {
                        forceSides[forceSide].Add(forceUser);
                        forceUsers.Add(forceUser, forceSide);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    
                }
                
            }

            Dictionary<string, List<string>> result = forceSides
                .Where(n => n.Value.Count > 0)
                .OrderByDescending(n => n.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                string forceSide = kvp.Key;
                int totalMembers = kvp.Value.Count;

                    Console.WriteLine($"Side: {forceSide}, Members: {totalMembers}");
                    kvp.Value.Sort();
                    foreach (var user in kvp.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
            }
            
        }
    }
}