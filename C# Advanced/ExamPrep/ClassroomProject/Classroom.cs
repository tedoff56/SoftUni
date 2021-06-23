using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> _students;

        public Classroom(int capacity)
        {
            _students = new List<Student>();
            Capacity = capacity;
        }

        public int Capacity { get;}

        public int Count => _students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count == Capacity)
            {
                return $"No seats in the classroom";
            }

            _students.Add(student);
            return $"Added student {student.FullName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = GetStudent(firstName, lastName);

            if (_students.Remove(student))
            {
                return $"Dismissed student {student.FullName}";
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            var result = _students.Where(s => s.Subject == subject).ToArray();
            
            if (result.Count() == 0)
            {
                return $"No students enrolled for the subject";
            }
            
            foreach (var student in result)
            {
                sb.AppendLine(student.FullName);
            }
            
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return _students.Find(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}