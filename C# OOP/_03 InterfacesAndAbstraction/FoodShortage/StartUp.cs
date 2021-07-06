using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Interfaces;
using FoodShortage.Models;

namespace FoodShortage
{
    class StartUp
    {
        private static void Main()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                
                if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(name, age, tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(name, age, tokens[2]));
                } 
            }

            string line = Console.ReadLine().Replace(" ", "");
            while (line != "End")
            {
                IBuyer buyer = buyers.Find(b => b.Name == line);

                if (buyer != default)
                {
                    buyer.BuyFood();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(buyers.Select(b => b.Food).Sum());
        }
    }
}