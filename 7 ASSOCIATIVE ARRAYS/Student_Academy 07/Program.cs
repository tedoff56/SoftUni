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

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<double>(){grade});
                }
                else
                {
                    studentsGrades[name].Add(grade);
                }
            }

            foreach (var student in studentsGrades
                .Where(n =>
            {
                foreach (var grade in n.Value)
                {
                    if (grade >= 4.5)
                    {
                        return true;
                    }
                }
                
                return false;
            })
                .OrderByDescending(n => n.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
            }

        }
    }
}