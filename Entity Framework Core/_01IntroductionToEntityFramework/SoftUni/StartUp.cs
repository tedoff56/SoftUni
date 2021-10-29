using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            Console.WriteLine(GetEmployeesFullInformation(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new {e.EmployeeId, e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary})
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            result.ForEach(e => 
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }
    }
}
