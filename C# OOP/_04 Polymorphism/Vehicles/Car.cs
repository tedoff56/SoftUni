namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelConsumption = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionerFuelConsumption;

        public override string Drive(double distance)
        {
            return $"Car {base.Drive(distance)}";
        }

        public override string ToString()
        {
            return $"Car: {base.ToString()}";
        }
        
    }
}