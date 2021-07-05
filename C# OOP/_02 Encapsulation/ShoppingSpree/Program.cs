using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            
            foreach (var personData in peopleData.Select(p => p.Split('=')))
            {
                try
                {
                    var person = new Person(personData[0], decimal.Parse(personData[1]));
                    people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            foreach (var productData in productsData.Select(p =>p.Split('=')))
            {
                try
                {
                    var product = new Product(productData[0], decimal.Parse(productData[1]));
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            
            string nameAndProduct = Console.ReadLine();
            while (nameAndProduct != "END")
            {
                string[] tokens = nameAndProduct.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = people.Find(p => p.Name == tokens[0]);
                Product product = products.Find(p => p.Name == tokens[1]);
                
                person.BuyProduct(product);
                
                nameAndProduct = Console.ReadLine();
            }
            foreach (var person in people)
            {
                string resultMessage = person.Bag.Count == 0 ? "Nothing bought" : string.Join(", ", person.Bag);
                
                Console.WriteLine($"{person.Name} - {resultMessage}");
            }
            
            
        }
    }
}