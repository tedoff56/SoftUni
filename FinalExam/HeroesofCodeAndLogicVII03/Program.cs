using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesofCodeAndLogicVII03
{
    class Hero
    {
        public string Name { get; set; }

        public int HitPoints { get; set; }

        public int ManaPoints { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            
            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = heroData[0];
                int hitPoints = int.Parse(heroData[1]);
                int manaPoints = int.Parse(heroData[2]);
                
                if (hitPoints > 100 || manaPoints > 200)
                {
                    continue;
                }
                
                Hero hero = new Hero()
                {
                    Name = name,
                    HitPoints = hitPoints,
                    ManaPoints = manaPoints
                };
                
                if (!heroes.ContainsKey(hero.Name))
                {
                    heroes.Add(hero.Name, hero);
                }
                
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string heroName = tokens[1];
                
                if(action == "CastSpell")
                {
                    int manaCost = int.Parse(tokens[2]);
                    string spellName = tokens[3];
                    
                    if (heroes[heroName].ManaPoints >= manaCost)
                    {
                        heroes[heroName].ManaPoints -= manaCost;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroes[heroName].HitPoints -= damage;
                    
                    if (heroes[heroName].HitPoints > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HitPoints} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(tokens[2]);
                    
                    heroes[heroName].ManaPoints += amount;

                    if (heroes[heroName].ManaPoints > 200)
                    {
                        amount = 200 - (heroes[heroName].ManaPoints - amount);
                        heroes[heroName].ManaPoints = 200;
                    }
                    
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(tokens[2]);
                    
                    heroes[heroName].HitPoints += amount;

                    if (heroes[heroName].HitPoints > 100)
                    {
                        amount = 100 - (heroes[heroName].HitPoints - amount);
                        heroes[heroName].HitPoints = 100;
                    }

                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
            }

            Dictionary<string, Hero> result = heroes
                .Where(h => h.Value.HitPoints > 0)
                .OrderByDescending(h => h.Value.HitPoints)
                .ThenBy(h => h.Value.Name)
                .ToDictionary(k => k.Key, v => v.Value);
            
            foreach (var hero in result.Values)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HitPoints}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }
            
        }
    }
}