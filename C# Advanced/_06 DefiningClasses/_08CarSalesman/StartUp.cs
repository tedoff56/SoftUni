using System;
using System.Collections.Generic;

namespace _08CarSalesman
{
    class StartUp
    {
        static void Main()
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            var engines = ReadEngines(numberOfEngines);
            
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = ReadCars(numberOfCars, engines);

            cars.ForEach(c => Console.WriteLine(c));
        }

        private static List<Car> ReadCars(int numberOfCars, List<Engine> engines)
        {
            
            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                Engine engine = engines.Find(e => e.Model == carData[1]);

                Car currentCar = new Car(model, engine);

                if (carData.Length > 2)
                {
                    if (int.TryParse(carData[2], out int weight))
                    {
                        currentCar.Weight = weight;
                    }
                    else
                    {
                        currentCar.Color = carData[2];
                    }
                    
                    if (carData.Length > 3)
                    {
                        currentCar.Color = carData[3];
                    }
                }
                
                cars.Add(currentCar);
            }

            return cars;
        }

        private static List<Engine> ReadEngines(int numberOfEngines)
        {
            List<Engine> engines = new List<Engine>();
            
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                
                Engine currentEngine = new Engine(model, power);

                if (engineData.Length > 2)
                {
                    if (int.TryParse(engineData[2], out int displacement))
                    {
                        currentEngine.Displacement = displacement;
                    }
                    else
                    {
                        currentEngine.Efficiency = engineData[2];
                    }
                    
                    if (engineData.Length > 3)
                    {
                        currentEngine.Efficiency = engineData[3];
                    }
                }
                
                engines.Add(currentEngine);
            }

            return engines;
        }
    }
}