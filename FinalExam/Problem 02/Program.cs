using System;
using System.Text.RegularExpressions;

namespace Problem_02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex registerRegex =
                new Regex(@"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}\d+)P@\$");

            int count = 0;
            
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                
                Match regMatch = registerRegex.Match(line);
                
                if (!regMatch.Success)
                {
                    Console.WriteLine("Invalid username or password");
                    continue;
                }

                count++;


                Console.WriteLine("Registration was successful");
                Console.WriteLine($"Username: {regMatch.Groups["username"]}, Password: {regMatch.Groups["password"]}");
                
            }

            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}