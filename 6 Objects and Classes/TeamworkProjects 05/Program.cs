using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects_05
{
    class Team
    {
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Users { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();
            
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamInfo = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string teamCreator = teamInfo[0];
                string teamName = teamInfo[1];
                
                var teamNameMatch = teams.Where(t => t.Name == teamName);
                var creatorMatch = teams.Where(t => t.Creator == teamCreator);
                if (teamNameMatch.Count() != 0)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (creatorMatch.Count() != 0)
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }
                
                Team team = new Team()
                {
                    Creator = teamCreator,
                    Name = teamName,
                    Users = new List<string>()
                };
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of assignment")
                {
                    break;
                }

                string[] joinData = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string user = joinData[0];
                string teamName = joinData[1];
                var teamNameMatch = teams.Where(t => t.Name == teamName);
                var teamUsersMatch = teams.Where(t => t.Users.Contains(user));
                var teamCreatorMatch = teams.Where(t => t.Creator == user);

                if (teamNameMatch.Count() == 0)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teamUsersMatch.Count() > 0)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }
                else if (teamCreatorMatch.Count() > 0)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                foreach (var team in teams)
                {
                    if (team.Name == teamName)
                    {
                        team.Users.Add(user);
                    }
                }
                
            }

            var validTeams = teams
                .Where(t => t.Users.Count() != 0)
                .OrderByDescending(t=>t.Users.Count())
                .ThenBy(t=>t.Name);
            var invalidTeams = teams.Where(t => t.Users.Count() == 0);

            foreach (var team in validTeams)
            {
                string teamName = team.Name;
                string creator = team.Creator;
                
                List<string> users = team.Users.OrderBy(t=> t).ToList();
                Console.WriteLine($"{teamName}");
                Console.WriteLine($"- {creator}");
                foreach (var user in users)
                {
                    Console.WriteLine($"-- {user}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in invalidTeams)
            {
                Console.WriteLine($"{team.Name}");
            }
        }
    }
}