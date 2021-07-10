using System;
using System.Collections.Generic;

using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        
        public string Name { get; }
        
        public double Weight { get; private set; }
        
        public int FoodEaten { get; private set; }

        public abstract double CaloriesMultiplier {get; }
        public abstract ICollection<Type> DesiredFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!DesiredFoods.Contains(food.GetType()))
            {
                throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * CaloriesMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
            =>$"{this.GetType().Name} [{this.Name},";
        
    }
}