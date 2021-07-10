using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Contracts;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        
        public IAnimal ProduceAnimal(string[] animalData)
        {
            
            string animalType = animalData[0];
            
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            
            IAnimal animal = null;
            
            if(animalType == "Mouse")
            {
                string livingRegion = animalData[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if( animalType == "Dog")
            {
                string livingRegion = animalData[3];
                animal = new Dog(name, weight, livingRegion);
            } 
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if(animalType == "Cat")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}