using System;
using System.Collections.Generic;
using System.Linq;

namespace Students_04
{
    class Student
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Student> studentsList = new List<Student>();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split();

                Student student = new Student()
                {
                    FirstName = studentData[0],
                    LastName = studentData[1],
                    Grade = double.Parse(studentData[2])
                };
                studentsList.Add(student);
            }

            List<Student> sortedList = studentsList
                .OrderByDescending(s => s.Grade)
                .ToList();

            foreach (var student in sortedList)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}