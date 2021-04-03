using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<string, List<string>> emailsByUser = new Dictionary<string, List<string>>();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Statistics")
                {
                    break;
                }

                string[] tokens = line.Split(new string[]{"->"}, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string username = tokens[1];

                if (command == "Add")
                {
                    if (emailsByUser.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                        continue;
                    }
                    emailsByUser.Add(username,new List<string>());
                }
                else if (command == "Send")
                {
                    string email = tokens[2];
                    
                    if (emailsByUser.ContainsKey(username))
                    {
                        emailsByUser[username].Add(email);
                    }
                }
                else if (command == "Delete")
                {
                    if(!emailsByUser.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} not found!");
                        continue;
                    }

                    emailsByUser.Remove(username);
                }
            }

            Console.WriteLine($"Users count: {emailsByUser.Count}");

            Dictionary<string, List<string>> result = emailsByUser
                .OrderByDescending(u => u.Value.Count)
                .ThenBy(u => u.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var user in result)
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}