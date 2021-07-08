using System;

namespace Vehicles.Models
{
    public class Vehicle
    {
        
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = FuelConsumption * distance;
            if (FuelQuantity >= neededFuel)
            {
                FuelQuantity -= neededFuel;
                return $"travelled {distance} km";
            }

            return "needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
        
        public override string ToString()
        {
            return $"{Math.Round(FuelQuantity, 2):F2}";
        }
    }
}