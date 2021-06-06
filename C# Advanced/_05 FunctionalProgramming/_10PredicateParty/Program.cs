using System;
using System.Collections.Generic;

namespace _10PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partyList = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            string line = Console.ReadLine();

            while (line != "Party!")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        partyList.RemoveAll(predicate);
                        break;
                    case "Double":
                        List<string> matches = partyList.FindAll(predicate);
                        if(matches.Count > 0)
                        {
                            partyList.InsertRange(partyList.IndexOf(matches[0]), matches);
                        }
                        break;
                }

                line = Console.ReadLine();
            }

            string result = partyList.Count > 0
                ? string.Join(", ", partyList) + " are going to the party!"
                : "Nobody is going to the party!";
            
            Console.WriteLine(result);
            
        }

        private static Predicate<string> GetPredicate(string criteria, string value)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return name => name.StartsWith(value);
                case "EndsWith":
                    return name => name.EndsWith(value);
                case "Length":
                    return name => name.Length == int.Parse(value);
                default:
                    throw new ArgumentException("Wrong criteria!");
            }
        }
    }
}