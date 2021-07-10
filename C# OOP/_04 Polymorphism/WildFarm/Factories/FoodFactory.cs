using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood ProduceFood(string[] foodData)
        {
            
            string foodType = foodData[0];
            int quantity = int.Parse(foodData[1]);

            IFood food = null;

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}