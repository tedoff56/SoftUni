using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses_06
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "end")
                {
                    break;
                }

                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>(){studentName});
                }
                else
                {
                    courses[courseName].Add(studentName);
                }
                
            }

            foreach (var course in courses.OrderByDescending(n => n.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var name in course.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}