using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const double CaloriesPerGram = 2;
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        
        private string _flourType;
        private string _bakingTechnique;
        private double _weight;
        private readonly IReadOnlyDictionary<string, double> _modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5},
            {"wholegrain", 1},
            {"crispy", 0.9},
            {"chewy", 1.1 },
            {"homemade", 1}
        };

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string BakingTechnique
        {
            get => _bakingTechnique;
            private set
            {
                if(!_modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                
                _bakingTechnique = value.ToLower();
            }
        }

        public string FlourType
        {
            get => _flourType;
            private set
            {
                if(!_modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                _flourType = value.ToLower();
            }
        }

        public double Weight
        {
            get => _weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                _weight = value;
            }
        }

        public double TotalCalories => CalculateCalories();
        private double CalculateCalories()
        {
            return CaloriesPerGram * this.Weight * _modifiers[this.FlourType] * _modifiers[this.BakingTechnique];
        }
    }
}