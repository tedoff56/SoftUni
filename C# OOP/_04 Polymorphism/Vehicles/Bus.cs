namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.4;
        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public bool DriveEmpty { get; set; }

        public override double FuelConsumption => this.DriveEmpty 
            ? base.FuelConsumption 
            : base.FuelConsumption + AirConditionerFuelConsumption;
        
        public override string Drive(double distance)
        {
            string result = $"Bus {base.Drive(distance)}";
            this.DriveEmpty = false;
            return result;
        }
        
        public override string ToString()
        {
            return $"Bus: {base.ToString()}";
        }
    }
}