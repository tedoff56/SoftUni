using System;
using System.Text.RegularExpressions;

namespace ExtractEmails_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Regex emailRegex = new Regex(@"(^|(?<=\s))[A-Za-z\d]+(?:[-._][A-Za-z\d]+)*@(?:[A-Za-z]+[-.])+[A-Za-z]+");
            MatchCollection matches = emailRegex.Matches(line);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}