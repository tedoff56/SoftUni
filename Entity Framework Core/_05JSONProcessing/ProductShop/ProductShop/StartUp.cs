using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Newtonsoft.Json;
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