using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            Console.WriteLine(GetLatestProjects(db));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                
                foreach (var employee in department.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project)
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            result.ForEach(a => 
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees"));

            return sb.ToString().TrimEnd();
        }
        
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employeesWithProjects = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project)
                });
            
            
            StringBuilder sb = new StringBuilder();
            
            foreach (var e in employeesWithProjects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                
                foreach (var project in e.Projects)
                {
                    string startDate = project.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    
                    string endDate = project.EndDate == null
                        ? "not finished"
                        : project.EndDate.Value
                            .ToUniversalTime()
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    
                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            
            context.Addresses.Add(newAddress);
            
            Employee employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = newAddress;
            
            context.SaveChanges();

            List<string> addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e =>  e.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            addresses.ForEach(a => sb.AppendLine(a));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new {e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary})
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            result.ForEach(e => 
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new {e.FirstName, e.Salary})
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            result.ForEach(e => sb.AppendLine($"{e.FirstName} - {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
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
