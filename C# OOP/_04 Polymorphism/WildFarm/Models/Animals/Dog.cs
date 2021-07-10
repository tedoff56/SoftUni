using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double CALORIES_MULTIPLIER = 0.4;
        
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;

        public override ICollection<Type> DesiredFoods 
            => new List<Type>() { typeof(Meat) };
        
        public override string ProduceSound() => "Woof!";
        
        public override string ToString()
            => $"{base.ToString()} {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        
    }
}