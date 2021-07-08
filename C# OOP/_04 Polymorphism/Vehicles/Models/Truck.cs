namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double _fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            
        }
        
        public override double FuelConsumption
        {
            get => _fuelConsumption;
            set => _fuelConsumption = value + 1.6;
        }

        public override string Drive(double distance)
        {
            return $"{nameof(Truck)} {base.Drive(distance)}";
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
        
        public override string ToString()
        {
            return $"{nameof(Truck)}: {base.ToString()}";
        }
        
    }
}