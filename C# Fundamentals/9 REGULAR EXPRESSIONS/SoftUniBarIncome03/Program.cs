using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome03
{
    class Customer
    {
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public double GetTotalPrice()
        {

            return Count * Price;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {

            Regex orderRegex = new Regex
                (@"%(?<customer>[A-Z][a-z]+)%(?:[^|$%.])*<(?<product>\w+)>(?:[^|$%.])*\|(?<count>\d+)\|(?:[^|$%.]*?)(?<price>\d+\.?\d*)\$");
            
            double totalIncome = 0.0;
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of shift")
                {
                    break;
                }

                Match validOrder = orderRegex.Match(line);
                if (!validOrder.Success)
                {
                    continue;
                }
                
                Customer customer = new Customer()
                {
                    CustomerName = validOrder.Groups["customer"].Value,
                    Product = validOrder.Groups["product"].Value,
                    Count = int.Parse(validOrder.Groups["count"].Value),
                    Price = double.Parse(validOrder.Groups["price"].Value)
                };
                
                totalIncome += customer.GetTotalPrice();
                
                Console.WriteLine($"{customer.CustomerName}: {customer.Product} - {customer.GetTotalPrice():F2}");
                
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
            
        }
    }
}