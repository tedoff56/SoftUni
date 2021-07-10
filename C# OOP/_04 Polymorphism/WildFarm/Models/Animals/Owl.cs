using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double CALORIES_MULTIPLIER = 0.25;
        
        public Owl(string name, double weight, double wingsSize) 
            : base(name, weight, wingsSize)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;
        
        public override ICollection<Type> DesiredFoods 
            => new List<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}