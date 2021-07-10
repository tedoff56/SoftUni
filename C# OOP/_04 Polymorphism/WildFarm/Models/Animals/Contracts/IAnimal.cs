using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public string ProduceSound();

        public void Feed(IFood food);
    }
}