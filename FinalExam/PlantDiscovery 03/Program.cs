using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlantDiscovery_03
{
    class Plant
    {
        public string Name { get; set; }

        public int Rarity { get; set; }
        
        public List<int> Ratings { get; set; }

        public double GetAvgRating()
        {
            if (Ratings.Count == 0)
            {
                return 0.0;
            }

            return Ratings.Average();
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            
            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (plants.ContainsKey(name))
                {
                    plants[name].Rarity = rarity;
                    continue;
                }

                Plant plant = new Plant()
                {
                    Name = name,
                    Rarity = rarity,
                    Ratings = new List<int>()
                };
                plants.Add(name, plant);
                
            }

            Regex regex = new Regex(@"^[A-Z][a-z]+: \w+(?: - \d+$)?");
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Exhibition")
                {
                    break;
                }
                
                if (!regex.Match(line).Success)
                {
                    Console.WriteLine("error");
                    continue;
                }
            
                string[] tokens = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                
                string command = tokens[0];
            
                tokens = tokens[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                
                if (!plants.ContainsKey(name))
                {
                    Console.WriteLine("error");
                    continue;;
                }
                
                if (command == "Rate")
                {
                    int rating = int.Parse(tokens[1]);
                    
                    plants[name].Ratings.Add(rating);
                }
                else if (command == "Update")
                {
                    int newRarity = int.Parse(tokens[1]);
                    
                    plants[name].Rarity = newRarity;
                }
                else if (command == "Reset")
                {
                    plants[name].Ratings.Clear();
                }
            }

            Dictionary<string, Plant> result = plants

                .OrderByDescending(p => p.Value.Rarity)
                .ThenByDescending(p => p.Value.GetAvgRating())
                .ToDictionary(k => k.Key, v => v.Value);
            
            Console.WriteLine("Plants for the exhibition:");

            foreach (var kvp in result)
            {
                string name = kvp.Key;
                int rarity = kvp.Value.Rarity;
                double avgRating = kvp.Value.GetAvgRating();

                Console.WriteLine($"- {name}; Rarity: {rarity}; Rating: {avgRating:F2}");
            }
            
        }
    }
}