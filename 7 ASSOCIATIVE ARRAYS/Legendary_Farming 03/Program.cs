using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming_03
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            bool gotLegendary = false;
            while (!gotLegendary)
            {
                List<string> input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                
                for (int i = 0; i < input.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        continue;
                    }
                    
                    string material = input[i].ToLower();
                    int quantity = int.Parse(input[i - 1]);

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            gotLegendary = true;
                            keyMaterials[material] -= 250;
                            string item = "Shadowmourne";
                            
                            if (material == "fragments")
                            {
                                item = "Valanyr";
                            }
                            else if (material == "motes")
                            {
                                item = "Dragonwrath";
                            }
                            
                            Console.WriteLine($"{item} obtained!");
                            break;
                        }
                        
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials.Add(material, quantity);
                        }
                        else
                        {
                            junkMaterials[material] += quantity;
                        }
                        
                    }
                    
                }
            }

            foreach (var kvp in keyMaterials
                .OrderByDescending(n => n.Value)
                .ThenBy(n => n.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }

            foreach (var kvp in junkMaterials
                .OrderBy(n => n.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}