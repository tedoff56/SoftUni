using System;
using System.Linq;

namespace MuOnline_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int initialBitcoins = 0;
            
            int currentHealth = initialHealth;
            int currentBitcoins = initialBitcoins;

            string line = Console.ReadLine();

            string[] rooms = line
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = currentRoom[0];
                int amount = int.Parse(currentRoom[1]);
                int bestRoom = i + 1;


                if (command == "potion")
                {
                    
                    if (currentHealth + amount <= initialHealth)
                    {
                        currentHealth += amount;
                        Console.WriteLine($"You healed for {amount} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {initialHealth - currentHealth} hp.");
                        currentHealth = 100;

                    }

                    Console.WriteLine($"Current health: {currentHealth} hp.");
                    
                }
                else if (command == "chest")
                {
                    currentBitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    string monster = command;
                    currentHealth -= amount;

                    if (currentHealth > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {bestRoom}");
                        break;
                    }
                }
            }
            if(currentHealth > 0)
            {
                Console.WriteLine($"You've made it!", "Bitcoins: {bitcoins}", $"Health: {currentHealth}");
                Console.WriteLine($"Bitcoins: {currentBitcoins}");
                Console.WriteLine($"Health: {currentHealth}");
            }

        }
    }
}