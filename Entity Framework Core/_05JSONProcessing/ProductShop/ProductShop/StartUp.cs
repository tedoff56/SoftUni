using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Models.DTOs;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string jsonResultUsers = File.ReadAllText("../../../Datasets/users.json");
            string jsonResultProducts = File.ReadAllText("../../../Datasets/products.json");
            string jsonResultCategories = File.ReadAllText("../../../Datasets/categories.json");
            string jsonResultCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            
            Console.WriteLine(ImportUsers(db, jsonResultUsers));
            Console.WriteLine(ImportProducts(db, jsonResultProducts));
            Console.WriteLine(ImportCategories(db, jsonResultCategories));
            Console.WriteLine(ImportCategoryProducts(db, jsonResultCategoryProducts));
            //Console.WriteLine(GetProductsInRange(db));
            Console.WriteLine(GetSoldProducts(db));
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = context
                .Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
            
            string jsonResult = JsonConvert.SerializeObject(result, jsonSettings);

            return jsonResult;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string jsonResult = JsonConvert.SerializeObject(result, settings);

            return jsonResult;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> cp = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(cp);
            context.SaveChanges();

            return $"Successfully imported {cp.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();
            
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Count}";
        }
        
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            
            context.AddRange(users);
            context.SaveChanges();
            
            return $"Successfully imported {users.Count()}";
        }


    }
}