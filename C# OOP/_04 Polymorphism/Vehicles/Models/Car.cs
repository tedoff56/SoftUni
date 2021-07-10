namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        
        private const double AIR_CONDITIONING_FUEL_CONSUMPTION = 0.9;
            
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            
        }

        public override double FuelConsumption 
            => base.FuelConsumption + AIR_CONDITIONING_FUEL_CONSUMPTION;
    }
}