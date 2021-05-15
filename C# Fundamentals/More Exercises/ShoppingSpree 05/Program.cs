using System;
using System.Collections.Generic;

namespace ShoppingSpree_05
{
    class Person
    {
        public string Name { get; set; }

        public decimal Money { get; set; }

        public List<string> Products { get; set; }
        
    }

    class Product
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            
            string[] personTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var personToken in personTokens)
            {
                string[] tokens = personToken.Split("=", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person()
                {
                    Name = tokens[0],
                    Money = decimal.Parse(tokens[1]),
                    Products = new List<string>()
                };
                
                persons.Add(person.Name, person);
                
            }

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] productTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var productToken in productTokens)
            {
                string[] tokens = productToken.Split("=", StringSplitOptions.RemoveEmptyEntries);

                Product product = new Product()
                {
                    Name = tokens[0],
                    Cost = decimal.Parse(tokens[1])
                };
                
                products.Add(product.Name, product);
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string productName = tokens[1];

                if (!persons.ContainsKey(name))
                {
                    continue;
                }

                bool hasEnoughMoney = persons[name].Money >= products[productName].Cost;

                if (!hasEnoughMoney)
                {
                    Console.WriteLine($"{name} can't afford {productName}");
                    continue;
                }

                persons[name].Money -= products[productName].Cost;
                    
                persons[name].Products.Add(productName);
                    
                Console.WriteLine($"{name} bought {productName}");
                
            }

            foreach (var kvp in persons)
            {
                string name = kvp.Key;
                
                if (kvp.Value.Products.Count == 0)
                {
                    Console.WriteLine($"{name} - Nothing bought");
                        continue;
                }
                
                Console.WriteLine($"{name} - {string.Join(", ", kvp.Value.Products)}");
            }

        }
    }
}