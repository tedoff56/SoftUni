using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Legendary_Farming_03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            bool gotLegenday = false;
            
            while (!gotLegenday)
            {
                List<string> input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 0; i < input.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        string ore = input[i].ToLower();
                        int amount = int.Parse(input[i - 1]);
                    
                        if (materials.ContainsKey(ore))
                        {
                            materials[ore] += amount;
                            amount = materials[ore];
                        }
                        else
                        {
                            materials.Add(ore, amount);
                        }


                        if (IsKeyMaterial(ore) && amount >= 250)
                        {
                            keyMaterials.Add(ore, amount);
                            string item = string.Empty;
                            materials[ore] = Math.Abs(amount - 250);
                            gotLegenday = true;
                            
                            if (ore == "shards")
                            {
                                item = "Shadowmourne";
                            }
                            else if (ore == "fragments")
                            {
                                item = "Valanyr";
                            }
                            else if (ore == "motes")
                            {
                                item = "Dragonwrath";
                            }
                            Console.WriteLine($"{item} obtained!");
                            
                            break;
                        }
                        
                    }
                }
                
            }

            keyMaterials = materials.Where(mat => IsKeyMaterial(mat.Key)).ToDictionary();
            
            foreach (var resource in materials)
            {
                if (IsKeyMaterial(resource.Key))
                {
                    Console.WriteLine($"{resource.Key}: {resource.Value}");
                }
            }

            static  bool IsKeyMaterial(string ore)
            {
                if (ore == "shards" || ore == "fragments" || ore == "motes")
                {
                    return true;
                }

                return false;
            }
            
        }
    }
}