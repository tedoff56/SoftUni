using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> distanceByName = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(n => n,d =>  0);


            Regex nameRegex = new Regex(@"[A-Za-z]+");
            Regex distanceRegex = new Regex(@"\d");
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of race")
                {
                    break;
                }
                
                MatchCollection nameMatches = nameRegex.Matches(line);
                StringBuilder nameSb = new StringBuilder();
                foreach (var letter in nameMatches)
                {
                    nameSb.Append(letter);
                }
                string name = nameSb.ToString();

                MatchCollection distanceMatches = distanceRegex.Matches(line);
                int distance = 0;
                foreach (Match digit in distanceMatches)
                {
                    distance += int.Parse(digit.Value);
                }

                if (!distanceByName.ContainsKey(name))
                {
                    continue;;
                }

                distanceByName[name] += distance;
            }

            string[] winners = distanceByName
                .OrderByDescending(d => d.Value)
                .Take(3)
                .Select(r => r.Key)
                .ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
            
        }
    }
}