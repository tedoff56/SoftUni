namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int _size = 5;
        
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            
        }

        public override int Size => _size;
        
        public override void Eat()
        {
            _size += 2;
        }
    }
}