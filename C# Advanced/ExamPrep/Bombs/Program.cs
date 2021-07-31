using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Dictionary<string, int> bombPouch = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };
            
            Dictionary<int, string> bombValues = new Dictionary<int, string>()
            {
                {40, "Datura Bombs"},
                {60, "Cherry Bombs"},
                {120, "Smoke Decoy Bombs"}
            };

            bool pouchIsFilled = false;
            while (bombEffects.Count != 0 && bombCasings.Count != 0 && !pouchIsFilled)
            {
                int sum = bombEffects.Peek() + bombCasings.Peek();

                if (!bombValues.ContainsKey(sum))
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                    continue;
                }
                
                string bombName = bombValues[sum];
                bombPouch[bombName]++;

                bombEffects.Dequeue();
                bombCasings.Pop();

                pouchIsFilled = bombPouch.All(b => b.Value >= 3);

            }

            if (pouchIsFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            string bombEffectsResult = bombEffects.Count == 0 ? "empty" : string.Join(", ", bombEffects);
            Console.WriteLine($"Bomb Effects: {bombEffectsResult}");

            string bombCasingsResult = bombCasings.Count == 0 ? "empty" : string.Join(", ", bombCasings);
            Console.WriteLine($"Bomb Casings: {bombCasingsResult}");

            foreach (var kvp in bombPouch.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}