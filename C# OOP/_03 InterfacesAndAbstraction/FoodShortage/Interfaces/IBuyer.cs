namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        
        public void BuyFood();
    }
}