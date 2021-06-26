using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));


            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };
            

            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                int ingredient = ingredients.Peek();
                int freshness = freshnessLevel.Peek();

                int product = ingredient * freshness;
                
                if (product == 150 || product == 250 || product == 300 || product == 400) 
                {
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                    if (product == 150)
                    {
                        dishes["Dipping sauce"]++;
                    }
                    else if (product == 250)
                    {
                        dishes["Green salad"]++;
                    }
                    else if (product == 300)
                    {
                        dishes["Chocolate cake"]++;
                    }
                    else if(product == 400)
                    {
                        dishes["Lobster"]++;
                    }
                }
                else if(ingredient == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    freshnessLevel.Pop();
                    int temp = ingredients.Dequeue() + 5;
                    List<int> tempIngredients = new List<int>(ingredients);
                    tempIngredients.Add(temp);
                    
                    ingredients = new Queue<int>(tempIngredients);
                }
            }

            if (!dishes.Any(d => d.Value == 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var kvp in dishes.Where(d => d.Value != 0).OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
            }
        }
    }
}