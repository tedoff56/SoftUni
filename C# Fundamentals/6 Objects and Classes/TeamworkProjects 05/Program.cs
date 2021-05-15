using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects_05
{
    class Team
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Member { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Team team = new Team();

            Dictionary<string, Team> teamByCreator = new Dictionary<string, Team>();
            Dictionary<string, Team> teamByName = new Dictionary<string, Team>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);

                string user = tokens[0];
                string teamName = tokens[1];

                team = new Team()
                {
                    Name = teamName,
                    Creator = user,
                    Member = new List<string>()
                };

                if (teamByName.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                
                if (teamByCreator.ContainsKey(user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }
                
                teamByCreator.Add(user, team);
                teamByName.Add(teamName, team);
                
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of assignment")
                {
                    break;
                }

                string[] tokens = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

                string user = tokens[0];
                string teamName = tokens[1];

                if (!teamByName.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (MemberAlreadyInTeam(teamByName, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                teamByName[teamName].Member.Add(user);

            }

            Dictionary<string, Team> validTeams = teamByName
                .Where(t => t.Value.Member.Count() != 0)
                .OrderByDescending(t=>t.Value.Member.Count())
                .ThenBy(t=>t.Value.Name)
                .ToDictionary(k => k.Key, v => v.Value);

            Dictionary<string, Team> invalidTeams = teamByName
                .Where(t => t.Value.Member.Count() == 0)
                .OrderBy(t=>t.Value.Name)
                .ToDictionary(k => k.Key, v => v.Value);
            
            foreach (var kvp in validTeams)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"- {kvp.Value.Creator}");
                foreach (var member in kvp.Value.Member.OrderBy(m=>m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            
            foreach (var kvp in invalidTeams)
            {
                Console.WriteLine(kvp.Key);
            }
        }

        private static bool MemberAlreadyInTeam(Dictionary<string, Team> team, string user)
        {
            foreach (var kvp in team)
            {
                List<string> members = kvp.Value.Member;
                if (members.Contains(user) || kvp.Value.Creator == user)
                {
                    return true;
                }
            }

            return false;
        }
    }
}