namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        
        private double _fuelConsumption;
        
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            
        }
        
        public override double FuelConsumption
        {
            get => _fuelConsumption;
            set => _fuelConsumption = value + 0.9;
        }

        public override string Drive(double distance)
        {
            return $"{nameof(Car)} {base.Drive(distance)}";
        }
        
        public override string ToString()
        {
            return $"{nameof(Car)}: {base.ToString()}";
        }
    }
}