using System;
namespace Vehicles
{
    public abstract class Vehicle
    {
        private double _fuelQuantity;
        private double _tankCapacity;
        
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity
        {
            get => _fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    _fuelQuantity = 0;
                    return;
                }

                _fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity
        {
            get => _tankCapacity;
            private set
            {
                if (value > 0)
                {
                    _tankCapacity = value;
                }
            }
        }
        
        public virtual string Drive(double distance)
        {
            bool canDrive = this.FuelQuantity < distance * this.FuelConsumption ? false : true;
            if (!canDrive)
            {
                return $"needs refueling";
            }
            
            this.FuelQuantity -= distance * this.FuelConsumption;
            
            return $"travelled {distance} km";
        }
        
        public virtual double Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return 0;
            }
            
            double fuelЕxcess = this.TankCapacity - (this.FuelQuantity + amount);
            if (fuelЕxcess < 0)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                return 0;
            }

            return this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{Math.Round(this.FuelQuantity, 2):F2}";
        }
    }
}
