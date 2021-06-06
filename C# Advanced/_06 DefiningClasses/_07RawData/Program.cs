using System;
using System.Collections.Generic;
using System.Linq;

namespace _07RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                
                Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);

                Tire tire1 = new Tire(double.Parse(tokens[5]), int.Parse(tokens[6]));
                Tire tire2 = new Tire(double.Parse(tokens[7]), int.Parse(tokens[8]));
                Tire tire3 = new Tire(double.Parse(tokens[9]), int.Parse(tokens[10]));
                Tire tire4 = new Tire(double.Parse(tokens[11]), int.Parse(tokens[12]));
                
                Car currentCar = new Car(tokens[0], engine, cargo, new List<Tire>(){tire1, tire2, tire3, tire4});
                
                cars.Add(currentCar);
            }

            (Console.ReadLine() == "flamable" ? 
                    cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250) : 
                    cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    ).ToList().ForEach(c => Console.WriteLine(c.Model));
            
        }
    }
}