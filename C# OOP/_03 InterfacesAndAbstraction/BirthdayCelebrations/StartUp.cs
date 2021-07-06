using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelebrations.Interfaces;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations
{
    class Program
    {
        public static void Main()
        {
            List<IBirthday> birthdays = new List<IBirthday>();
            
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Citizen":
                        Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        birthdays.Add(citizen);
                        break;
                    
                    case "Pet":
                        Pet pet = new Pet(tokens[1], tokens[2]);
                        birthdays.Add(pet);
                        break;
                }

                line = Console.ReadLine();
            }

            string year = Console.ReadLine();
            
            foreach (var birthday in birthdays.Where(b => b.BirthDay.Contains(year)))
            {
                Console.WriteLine(birthday.BirthDay);
            }
        }
    }
}