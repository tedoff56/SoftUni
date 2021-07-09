using System;
using System.Linq;
using System.Text;

namespace Vehicles
{
    public class StartUp
    {
        private static void Main()
        {
            
            double[] carData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] busData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();

            Vehicle car = new Car(carData[0], carData[1], carData[2]);
            Vehicle truck = new Truck(truckData[0], truckData[1], truckData[2]);
            Bus bus = new Bus(busData[0], busData[1], busData[2]);
            
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
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(double.Parse(commandData[2])));
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
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(double.Parse(commandData[2]));
                        }
                        break;
                    
                    case "DriveEmpty":
                        bus.DriveEmpty = true;
                        Console.WriteLine(bus.Drive(double.Parse(commandData[2])));
                        break;
                }
                
            }

            StringBuilder sb = new StringBuilder()
                .AppendLine($"{car}")
                .AppendLine($"{truck}")
                .AppendLine($"{bus}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}