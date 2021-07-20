namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int _size = 3;
        
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            
        }


        public override int Size => _size;

        public override void Eat()
        {
            _size += 3;
        }
    }
}