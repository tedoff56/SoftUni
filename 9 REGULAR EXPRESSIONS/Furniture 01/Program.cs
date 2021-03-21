using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> boughtFurniture = new List<string>();
            double totalSum = 0;

            string pattern = @"(?<name>\w+)<<(?<price>[0-9.]+)!(?<quantity>[0-9]+)";
            Regex regex = new Regex(pattern);
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                var match = regex.Match(input);
                if (!regex.IsMatch(input))
                {
                    continue;
                }
                
                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                boughtFurniture.Add(name);
                totalSum += price * quantity;

            }

            Console.WriteLine("Bought furniture:");
            foreach (var furniture in boughtFurniture)
            {
                Console.WriteLine($"{furniture}");
            }

            Console.WriteLine($"Total money spend: {totalSum:F2}");
        }
    }
}