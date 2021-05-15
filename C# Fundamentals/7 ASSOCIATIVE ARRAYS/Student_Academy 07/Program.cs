using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> gradesByStudent = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradesByStudent.ContainsKey(name))
                {
                    gradesByStudent.Add(name, new List<double>());
                }
                
                gradesByStudent[name].Add(grade);
                
            }

            Dictionary<string, List<double>> result = gradesByStudent
                .OrderByDescending(n => n.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                string student = kvp.Key;
                double averageGrade = kvp.Value.Average();
                if (averageGrade >= 4.5)
                {
                    Console.WriteLine($"{student} -> {averageGrade:F2}");
                }
            }

        }
    }
}