using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy_05
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = new Dictionary<string, SortedDictionary<string, int[]>>();
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] parts = line.Split();

                string type = parts[0];
                string name = parts[1];
                int damage = parts[2] == "null" ? 45 : int.Parse(parts[2]);
                int health = parts[3] == "null" ? 250 : int.Parse(parts[3]);
                int armor = parts[4] == "null" ? 10 : int.Parse(parts[4]);

                if (!data.ContainsKey(type))
                {
                    data.Add(type, new SortedDictionary<string, int[]>());
                }

                if (data[type].ContainsKey(name))
                {
                    data[type][name][0] = damage;
                    data[type][name][1] = health;
                    data[type][name][2] = armor;
                    continue;
                }
                
                data[type].Add(name, new []{damage, health, armor});
                
            }

            foreach (var kvp in data)
            {
                string type = kvp.Key;
                
                double avgDamage = data[type].Select(d => d.Value[0]).Average();
                double avgHealth = data[type].Select(d => d.Value[1]).Average();
                double avgArmor = data[type].Select(d => d.Value[2]).Average();
                
                Console.WriteLine($"{type}::({avgDamage:F2}/{avgHealth:F2}/{avgArmor:F2})");

                foreach (var kvp2 in data[type])
                {
                    string name = kvp2.Key;

                    Console.WriteLine($"-{name} -> damage: {kvp2.Value[0]}, health: {kvp2.Value[1]}, armor: {kvp2.Value[2]}");
                }

            }

        }
        
    }
}
