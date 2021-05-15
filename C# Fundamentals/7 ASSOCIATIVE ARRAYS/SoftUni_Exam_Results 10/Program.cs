using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> maxpointsByUsername = new Dictionary<string, int>();
            Dictionary<string, int> submissionsByLanguage = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] parts = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string username = parts[0];

                if (parts.Length == 3)
                {
                    string language = parts[1];
                    int points = int.Parse(parts[2]);

                    if (!maxpointsByUsername.ContainsKey(username))
                    {
                        maxpointsByUsername.Add(username, points);
                    }
                    else
                    {
                        if (points > maxpointsByUsername[username])
                        {
                            maxpointsByUsername[username] = points;
                        }
                    }
                    
                    if (!submissionsByLanguage.ContainsKey(language))
                    {
                        submissionsByLanguage.Add(language, 1);
                    }
                    else
                    {
                        submissionsByLanguage[language]++;
                    }
                }
                else if(parts.Length == 2)
                {
                    maxpointsByUsername.Remove(username);
                }

            }
            
            Console.WriteLine("Results:");
            foreach (var kvp in maxpointsByUsername.OrderByDescending(n => n.Value)
                .ThenBy(n => n.Key))
            {
                string username = kvp.Key;
                int points = kvp.Value;
                Console.WriteLine($"{username} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissionsByLanguage.OrderByDescending(n=>n.Value)
                .ThenBy(n=> n.Key))
            {
                string language = kvp.Key;
                int submissions = kvp.Value;
                Console.WriteLine($"{language} - {submissions}");
            }
        }
    }
}