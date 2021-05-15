using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue_06
{

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        
        public static double GetAvgHp(List<Vehicle> vehicles, string type)
        {
            var vehiclesByType = vehicles.Where(v => v.Type == type);
            double sum = 0.0;
            foreach (var vehicle in vehiclesByType)
            {
                sum += vehicle.Horsepower;
            }

            int count = vehiclesByType.Count();
            if (count == 0)
            {
                return 0;
            }
            return sum / vehiclesByType.Count();

        }
        
    }
        class Program
        {
            static void Main(string[] args)
            {
                List<Vehicle> vehiclesCatalogue = new List<Vehicle>(50);

                while (true)
                {
                    string line = Console.ReadLine();
                    if (line == "End")
                    {
                        break;
                    }

                    string[] vehicleData = line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string type = vehicleData[0];
                    string model = vehicleData[1];
                    string color = vehicleData[2];
                    int horsepower = int.Parse(vehicleData[3]);

                    if (type == "car")
                    {
                        type = "Car";
                    }
                    if (type == "truck")
                    {
                        type = "Truck";
                    }

                    Vehicle vehicle = new Vehicle()
                    {
                        Type = type,
                        Model = model,
                        Color = color,
                        Horsepower = horsepower
                    };
                    vehiclesCatalogue.Add(vehicle);
                }

                while (true)
                {
                    string model = Console.ReadLine();
                    if (model == "Close the Catalogue")
                    {
                        break;
                    }

                    var modelMatches = vehiclesCatalogue.Where(v => v.Model == model);
                    if (modelMatches.Count() == 0)
                    {
                        continue;
                    }

                    foreach (var match in modelMatches)
                    {
                        Console.WriteLine($"Type: {match.Type}");
                        Console.WriteLine($"Model: {match.Model}");
                        Console.WriteLine($"Color: {match.Color}");
                        Console.WriteLine($"Horsepower: {match.Horsepower}");
                    }

                }
                
                Console.WriteLine($"Cars have average horsepower of: {Vehicle.GetAvgHp(vehiclesCatalogue, "Car"):F2}.");
                Console.WriteLine($"Trucks have average horsepower of: {Vehicle.GetAvgHp(vehiclesCatalogue, "Truck"):F2}.");
            }
            
        }
}