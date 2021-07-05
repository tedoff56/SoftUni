using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private const double CaloriesPerGram = 2;
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        
        private double _weight;
        private string _type;
        private readonly IReadOnlyDictionary<string, double> _modifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9 }
        };

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        
        public string Type
        {
            get => _type;
            private set
            {
                if (!_modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                _type = value;
            }
        }
        
        public double Weight
        {
            get => _weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                _weight = value;
            }
        }
        
        public double TotalCalories => CalculateCalories();
        private double CalculateCalories()
        {
            return (CaloriesPerGram * this.Weight) * _modifiers[this.Type.ToLower()];
        }
    }
}