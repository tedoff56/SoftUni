using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CALORIES_MULTIPLIER = 0.3;
        
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;

        public override ICollection<Type> DesiredFoods 
            => new List<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound() => "Meow";
    }
}