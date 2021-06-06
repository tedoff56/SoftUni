using System;
using System.Collections.Generic;
using System.Linq;

namespace _06SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToTrack = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < carsToTrack; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                if (!cars.Any(c => c.Model == car.Model))
                {
                    cars.Add(car);
                }
            }
            
            string line = Console.ReadLine();
            while (line?.ToUpper() != "END")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);
                
                Car currentCar = cars.Find(c => c.Model == model);
                
                currentCar.Drive(currentCar, amountOfKm);
                
                line = Console.ReadLine();
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.TravelledDistance}"));
        }
    }
}