using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double CALORIES_MULTIPLIER = 1.0;
        
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            
        }

        public override double CaloriesMultiplier => CALORIES_MULTIPLIER;

        public override ICollection<Type> DesiredFoods 
            => new List<Type>() { typeof(Meat) };
        
        public override string ProduceSound() => "ROAR!!!";
    }
}