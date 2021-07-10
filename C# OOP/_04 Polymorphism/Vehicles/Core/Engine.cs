using System;

using Vehicles.Contracts;
using Vehicles.Core.Contracts;
using Vehicles.Core.Models; 

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new VehicleFactory().ProduceVehicle(carData);
            IVehicle truck = new VehicleFactory().ProduceVehicle(truckData);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    RunCommand(commandTokens, car, truck);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void RunCommand(string[] commandTokens, IVehicle car, IVehicle truck)
        {
            string action = commandTokens[0];
            string vehicleType = commandTokens[1];
            double arg = double.Parse(commandTokens[2]);

            if (action == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(arg));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(arg));
                }
            }
            else if (action == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(arg);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(arg);
                }
            }
        }
    }
}