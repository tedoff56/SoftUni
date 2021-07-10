namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONING_FUEL_CONSUMPTION = 1.6;
        
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            
        }

        public override double FuelConsumption 
            => base.FuelConsumption + AIR_CONDITIONING_FUEL_CONSUMPTION;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}