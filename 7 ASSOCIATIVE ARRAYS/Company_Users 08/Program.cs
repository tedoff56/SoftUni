using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }

                string company = input[0];
                string employeeId = input[1];
                if (companies.ContainsKey(company))
                {
                    if(!companies[company].Contains(employeeId))
                    {
                        companies[company].Add(employeeId);
                    }
                }
                else
                {
                    companies.Add(company, new List<string>(){employeeId});
                }
                
            }
            

            foreach (var company in companies.OrderBy(n => n.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}