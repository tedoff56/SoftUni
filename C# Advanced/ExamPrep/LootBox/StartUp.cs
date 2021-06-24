using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> lootedItems = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();
            
                if (sum % 2 == 0)
                {
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                
                    lootedItems.Add(sum);
                }
                else
                {
                    int tempItem = secondLootBox.Pop();
                
                    List<int> tempBox = new List<int>(firstLootBox);
                    tempBox.Add(tempItem);
                
                    firstLootBox = new Queue<int>(tempBox);
                }
                
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int itemsSum = lootedItems.Sum();
            
            if (itemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {itemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {itemsSum}");
            }
            
        }
    }
}