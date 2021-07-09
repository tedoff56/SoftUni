namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.6;
        
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionerFuelConsumption;

        public override double Refuel(double amount)
        {            
            double fuelЕxcess = this.TankCapacity - (this.FuelQuantity + amount * 0.95);
            return base.Refuel(fuelЕxcess < 0 ? amount : amount * 0.95);
        }
        
        public override string Drive(double distance)
        {
            return $"Truck {base.Drive(distance)}";
        }
        
        public override string ToString()
        {
            return $"Truck: {base.ToString()}";
        }


    }
}