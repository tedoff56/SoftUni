using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string _name;
        private decimal _cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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

        public decimal Cost
        {
            get => _cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                _cost = value;
            }
        }
        
        
    }
}