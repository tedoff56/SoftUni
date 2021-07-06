using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : Person, IBuyer
    {
        
        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            Group = group;
        }

        public string Group { get; set; }
        public int Food { get; set; }
        
        public void BuyFood()
        {
            this.Food += 5;
        }
        
    }
}