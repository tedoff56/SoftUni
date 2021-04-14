using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData_04
{
    class Car
    {
        public string Model { get; set; }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }

        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Car car = new Car()
                {
                    Model = tokens[0],
                    EngineSpeed = int.Parse(tokens[1]),
                    EnginePower = int.Parse(tokens[2]),
                    CargoWeight = int.Parse(tokens[3]),
                    CargoType = tokens[4]
                };
                
                cars.Add(car);
                
            }

            string command = Console.ReadLine();

            List<Car> result = new List<Car>();
            
            
            if (command == "fragile")
            {
                result = cars.Where(c => c.CargoType == command && c.CargoWeight < 1000).ToList();
            }
            else if (command == "flamable")
            {
                result = cars.Where(c => c.CargoType == command && c.EnginePower > 250).ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}