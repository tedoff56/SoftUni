using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex placesRegex = new Regex(@"(=|\/)(?<place>[A-Z][A-Za-z]{2,})\1");

            string input = Console.ReadLine();

            MatchCollection placesMatches = placesRegex.Matches(input);

            List<string> places = new List<string>();
            
            foreach (Match placeMatch in placesMatches)
            {
                string place = placeMatch.Groups["place"].Value;
                places.Add(place);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", places)}");

            int travelPoints = places.Select(p => p.Length).Sum();

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}