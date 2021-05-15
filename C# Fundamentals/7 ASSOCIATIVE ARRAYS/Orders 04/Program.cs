using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tokens[0] == "buy")
                {
                    break;
                }

                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                double quantity = int.Parse(tokens[2]);

                if (products.ContainsKey(product))
                {
                    products[product][1] += quantity;
                    products[product][0] = price;
                }
                else
                {
                    products.Add(product, new List<double>(){price, quantity});
                }
                
            }

            foreach (var product in products)
            {
                double totalPrice = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {totalPrice:F2}");
            }
            
        }
    }
}