using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            List<DepartmentImportDto> departments = JsonConvert
                .DeserializeObject<List<DepartmentImportDto>>(jsonString);

            var result = new StringBuilder();

            var departmentsDb = new List<Department>();
            
            foreach (var department in departments)
            {
                if(!IsValid(department) || !department.Cells.All(IsValid))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }
            
                Department departmentDb = new Department()
                {
                    Name = department.Name,
                };
            
                foreach (var cell in department.Cells)
                {
                    departmentDb.Cells.Add(new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow,
                        Department = context.Departments.FirstOrDefault(d => d.Name == department.Name)
                    });
                }
            
                departmentsDb.Add(departmentDb);
                result.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }
            
            context.AddRange(departmentsDb);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            List<PrisonerImportDto> prisoners = JsonConvert
                .DeserializeObject<List<PrisonerImportDto>>(jsonString);

            var result = new StringBuilder();

            var prisonersDb = new List<Prisoner>();
            
            foreach (var prisoner in prisoners)
            {
                if(!IsValid(prisoner) || !prisoner.Mails.All(IsValid))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }
                
                if (!DateTime.TryParseExact(
                    prisoner.IncarcerationDate, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, 
                    out DateTime incarceration))
                {
                    result.AppendLine("InvalidData");
                    continue;
                }


                if (!DateTime.TryParseExact(prisoner.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime release))
                {
                    result.AppendLine("InvalidData");
                    continue;
                }
                

                Prisoner prisonerDb = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarceration,
                    ReleaseDate = release,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                };

                foreach (var mail in prisoner.Mails)
                {
                    prisonerDb.Mails.Add(new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }
                
                prisonersDb.Add(prisonerDb);
                result.AppendLine($"Imported {prisonerDb.FullName} {prisoner.Age} years old");
            }

            context.AddRange(prisonersDb);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}