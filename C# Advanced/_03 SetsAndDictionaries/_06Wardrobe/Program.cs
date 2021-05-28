using System;
using System.Collections.Generic;

namespace _06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];
                string[] clothes = tokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var cloth in clothes)
                {
                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 1);
                    }
                    else
                    {
                        wardrobe[color][cloth]++;
                    }
                }
            }

            string[] lookForData = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == lookForData[0] && cloth.Key == lookForData[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}