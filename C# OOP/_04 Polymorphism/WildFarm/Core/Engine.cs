using System;

using System.Collections.Generic;

using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;


namespace WildFarm.Core
{
    public class Engine : IEngine
    {

        public IAnimal Animal { get; private set; }

        public IFood Food { get; private set; }
        
        
        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();
                
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] animalData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] foodData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                this.Animal = new AnimalFactory().ProduceAnimal(animalData);
                this.Food = new FoodFactory().ProduceFood(foodData);

                Console.WriteLine(this.Animal.ProduceSound());

                try
                {
                    this.Animal.Feed(Food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(this.Animal);
                
                command = Console.ReadLine();
            }
            
            animals.ForEach(a => Console.WriteLine(a));
        }
    }
}