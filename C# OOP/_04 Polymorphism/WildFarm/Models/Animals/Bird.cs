namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingsSize) 
            : base(name, weight)
        {
            this.WingsSize = wingsSize;
        }

        public double WingsSize { get; private set; }

        public override string ToString() 
            => $"{base.ToString()} {this.WingsSize}, {this.Weight}, {this.FoodEaten}]";
        
    }
}