using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : Person, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        :base(name, age)
        {
            Id = id;
            BirthDate = birthDate;
        }

        public string Id { get; set; }

        public string BirthDate { get; set; }
        public int Food { get; set; }
        
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}