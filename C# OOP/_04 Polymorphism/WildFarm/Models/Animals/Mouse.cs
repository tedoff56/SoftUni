using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double CALORIES_MULTIPLIER = 0.10;
        
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;

        public override ICollection<Type> DesiredFoods 
            => new List<Type>() {typeof(Vegetable), typeof(Fruit)};

        public override string ProduceSound() => "Squeak";

        public override string ToString()
            => $"{base.ToString()} {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        
    }
}