using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = ReadContests();

            Dictionary<string, Dictionary<string, int>> users = ReadUsers(contests);

            var bestCandidate = users
                .OrderByDescending(d => d.Value.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(d=>d.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(d=>d.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }

        static Dictionary<string, string> ReadContests()
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line?.ToLower() == "end of contests")
                {
                    break;
                }

                string[] tokens = line.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = tokens[0];
                string password = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            return contests;
        }
        
        static Dictionary<string, Dictionary<string, int>> ReadUsers(Dictionary<string, string> contests)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line?.ToLower() == "end of submissions")
                {
                    break;
                }

                string[] tokens = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = tokens[0];
                string password = tokens[1];
                
                bool isContestValid = contests.ContainsKey(contest) && contests[contest] == password;
                if (!isContestValid)
                {
                    continue;
                }
                
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }
                
                if (!users[username].ContainsKey(contest))
                {
                    users[username].Add(contest, points);
                }
                else
                {
                    int oldPoints = users[username][contest];
                    if(points > oldPoints)
                    {
                        users[username][contest] = points;
                    }
                    else
                    {   
                        users[username][contest] = oldPoints;
                    }
                }
            }

            return users;
        }
    }
}