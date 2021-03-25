using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace Pirates03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Sail")
                {
                    break;
                }

                string[] tokens = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new int[]{population, gold});
                }
                else
                {
                    cities[city][0] += population;
                    cities[city][1] += gold;
                }

            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] eventData = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = eventData[0];
                string city = eventData[1];
                
                if (action == "Plunder")
                {
                    int people = int.Parse(eventData[2]);
                    int gold = int.Parse(eventData[3]);

                    cities[city][0] -= people;
                    cities[city][1] -= gold;
                    
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
                    
                    bool check = cities[city][0] <= 0 || cities[city][1] <= 0;
                    if (check)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }

                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(eventData[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;;
                    }

                    cities[city][1] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");

                }
                
            }

            var result = cities.OrderByDescending(c => c.Value[1])
                .ThenBy(c => c.Key);

            if (result.Count() > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {result.Count()} wealthy settlements to go to:");
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}