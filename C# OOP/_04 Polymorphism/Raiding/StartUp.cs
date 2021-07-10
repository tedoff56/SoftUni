using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Raiding.Models;

namespace Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            
            int n = int.Parse(Console.ReadLine());
            
            while (raidGroup.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    switch (heroType)
                    {
                        case "Druid":
                            raidGroup.Add(new Druid(heroName, heroType));
                            break;
                        case "Paladin":
                            raidGroup.Add(new Paladin(heroName, heroType));
                            break;
                        case "Rogue":
                            raidGroup.Add(new Rogue(heroName, heroType));
                            break;
                        case "Warrior":
                            raidGroup.Add(new Warrior(heroName, heroType));
                            break;
                        default:
                            Console.WriteLine("Invalid hero!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                
            }

            Console.WriteLine(raidGroup.Sum(h => h.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}