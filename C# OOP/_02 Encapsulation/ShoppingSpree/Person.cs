using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string _name;
        private decimal _money;
        private readonly List<string> _bag;
        
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            _bag = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                _name = value;
            }
        }

        public decimal Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                _money = value;
            }
        }

        public IReadOnlyList<string> Bag => _bag;

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.Money -= product.Cost;
                this._bag.Add(product.Name);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }
    }
}