using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int PizzaNameMaxSize = 15;
        private const int MaxToppingsCount = 10;
        
        private string _name;
        private Dough _dough;
        private readonly List<Topping> _toppings = new List<Topping>();

        public Pizza()
        {
        }
        
        public Pizza(string name)
        {
            Name = name;
        }
        
        public Pizza(string name, Dough dough)
        :this(name)
        {
            Dough = dough;
        }
        
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > PizzaNameMaxSize)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and {PizzaNameMaxSize} symbols.");
                }

                _name = value;
            }
        }

        public Dough Dough
        {
            get => _dough;
            set => _dough = value;
        }
        
        public int ToppingsCount => _toppings.Count;
        
        public double TotalCalories => CalculateCalories();
        private double CalculateCalories()
        {
            return _dough.TotalCalories + _toppings.Select(t => t.TotalCalories).Sum();
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == MaxToppingsCount)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }
            
            _toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}