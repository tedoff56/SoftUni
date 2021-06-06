using System;
using System.Collections.Generic;
using System.Linq;

namespace _11PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> filters = new List<string>();
            
            string line = Console.ReadLine();
            while (line != "Print")
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                
                string filter = $"{tokens[1]}:{tokens[2]}";
                
                switch (tokens[0])
                {
                    case "Add filter":
                        filters.Add(filter);
                        break;
                    case "Remove filter":
                        filters.Remove(filter);
                        break;
                    default:
                        throw new ArgumentException("Wrong command!");
                }

                line = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(':');
                
                Predicate<string> predicate = GetPredicate(tokens[0], tokens[1]);

                names = names.Where(name => !predicate(name)).ToArray();
            }

            Console.WriteLine(string.Join(' ', names));
            
        }

        private static Predicate<string> GetPredicate(string filter, string p)
        {
            switch (filter)
            {
                case "Starts with":
                    return name => name.StartsWith(p);
                case "Ends with":
                    return name => name.EndsWith(p);
                case "Length":
                    return name => name.Length == int.Parse(p);
                case "Contains":
                    return name => name.Contains(p);
                default:
                    throw new ArgumentException("Wrong filter!");
            }
        }
    }
}