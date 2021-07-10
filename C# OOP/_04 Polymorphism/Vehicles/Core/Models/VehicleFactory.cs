using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core.Models
{
    public class VehicleFactory
    {
        public IVehicle ProduceVehicle(string[] data)
        {
            string vehicleType = data[0];
            
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            
            IVehicle vehicle = null;
            
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}