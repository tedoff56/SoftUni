using System;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.WriteLine("DB Created");
            
            Console.WriteLine(ImportUsers(db, @"Datasets/users.xml"));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {

            var xmlSerializer = ConfigureXmlSerializer(typeof(ImportUserDto[]), "Users");

            using var sr = new StringReader(inputXml);
            
            var usersDtos = (ImportUserDto[]) 
                xmlSerializer.Deserialize(sr);

            var count = 0;
            foreach (var userDto in usersDtos)
            {
                var user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = int.Parse(userDto.Age)
                };

                context.Add(user);
                count++;
            }
            context.SaveChanges();
            
            return $"Successfully imported {count}";
        }

        private static XmlSerializer ConfigureXmlSerializer(Type type, string rootXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootXml);

            return new XmlSerializer(typeof(ImportUserDto[]), root);
        }
    }
}