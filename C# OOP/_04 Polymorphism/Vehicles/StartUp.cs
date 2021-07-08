using System;
using System.Linq;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        private static void Main()
        {
            //Car {fuel quantity} {liters per km}"
            string[] carData = Console.ReadLine().Split().Skip(1).ToArray();
            string[] truckData = Console.ReadLine().Split().Skip(1).ToArray();

            Vehicle car = new Car(double.Parse(carData[0]), double.Parse(carData[1]));
            Vehicle truck = new Truck(double.Parse(truckData[0]), double.Parse(truckData[1]));
            
            int totalCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalCommands; i++)
            {
                string[] commandData = Console.ReadLine().Split();

                string vehicleType = commandData[1];
                
                switch (commandData[0])
                {
                    case "Drive":
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(double.Parse(commandData[2])));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(commandData[2])));
                        }
                        break;
                    
                    case "Refuel":
                        if (vehicleType == "Car")
                        {
                            car.Refuel(double.Parse(commandData[2]));
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(double.Parse(commandData[2]));
                        }
                        break;
                }
            }
            
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}