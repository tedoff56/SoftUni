using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace AdAstra_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex foodRegex = new Regex(@"(\||#)(?<type>[A-Za-z\s]+)\1(?<expDate>\d{2,}\/\d{2,}\/\d{2,})\1(?<calories>\d{1,5})\1");

            MatchCollection foodMatches = foodRegex.Matches(text);

            int totalCalories = foodMatches.Select(f => int.Parse(f.Groups["calories"].Value)).Sum();
            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match foodMatch in foodMatches)
            {
                string type = foodMatch.Groups["type"].Value;
                string bestBefore = foodMatch.Groups["expDate"].Value;
                string calories = foodMatch.Groups["calories"].Value;

                Console.WriteLine($"Item: {type}, Best before: {bestBefore}, Nutrition: {calories}");
            }

        }
    }
}