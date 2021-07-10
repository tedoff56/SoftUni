using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double CALORIES_MULTIPLIER = 0.35;
        
        public Hen(string name, double weight, double wingsSize) 
            : base(name, weight, wingsSize)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;

        public override ICollection<Type> DesiredFoods 
            => new List<Type>() {typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};

        public override string ProduceSound() => "Cluck";
        
    }
}