using System;

using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity { get; private set; }
        
        public virtual double FuelConsumption { get; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity < neededFuel)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }

        public override string ToString() 
            => $"{this.GetType().Name}: {Math.Round(this.FuelQuantity, 2):F2}";
    }
}