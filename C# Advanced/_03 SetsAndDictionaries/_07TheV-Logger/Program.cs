using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> followersByName = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> followingByName = new Dictionary<string, HashSet<string>>();
            
            string line = Console.ReadLine();

            while (line?.ToLower() != "statistics")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstVlogger = tokens[0];
                string action = tokens[1];

                switch (action)
                {
                    case "joined":
                        if (!followersByName.ContainsKey(firstVlogger))
                        {
                            followersByName.Add(firstVlogger, new HashSet<string>());
                            followingByName.Add(firstVlogger, new HashSet<string>());
                        }

                        break;
                    case "followed":
                        string secondVlogger = tokens[2];
                        bool isValid = followersByName.ContainsKey(firstVlogger) &&
                                       followersByName.ContainsKey(secondVlogger) &&
                                       firstVlogger != secondVlogger;
                        if (isValid)
                        {
                            followingByName[firstVlogger].Add(secondVlogger);
                            followersByName[secondVlogger].Add(firstVlogger);
                        }

                        break;
                }

                line = Console.ReadLine();
            }

            Dictionary<string, HashSet<string>> result = followersByName
                .OrderByDescending(d => d.Value.Count)
                .ThenBy(d => followingByName[d.Key].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {followersByName.Count} vloggers in its logs.");
            
            int cnt = 0;
            foreach (var kvp in result)
            {
                cnt++;
                
                Console.WriteLine($"{cnt}. {kvp.Key} : {kvp.Value.Count} followers, {followingByName[kvp.Key].Count} following");
                
                if (cnt != 1)
                    continue;
                
                foreach (var follower in followersByName[kvp.Key].OrderBy(d => d))
                {
                    Console.WriteLine($"*  {follower}");
                }

            }
        }
    }
}