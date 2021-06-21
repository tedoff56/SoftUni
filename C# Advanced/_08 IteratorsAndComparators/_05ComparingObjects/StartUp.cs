using System;
using System.Collections.Generic;

namespace _05ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string line = Console.ReadLine();
            while (line != "END")
            {
                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                persons.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
                
                line = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int matches = 0;
            int notEqual = 0;

            foreach (Person person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    matches++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (matches < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {notEqual} {persons.Count}");
            }
        }
    }
}