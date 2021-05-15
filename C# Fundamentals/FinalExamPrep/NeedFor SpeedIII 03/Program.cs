using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Dictionary<string, int> mileageByCar = new Dictionary<string, int>();
            Dictionary<string, int> fuelByCar = new Dictionary<string, int>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string car = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                if (mileageByCar.ContainsKey(car))
                {
                    continue;
                }
                mileageByCar.Add(car, mileage);
                fuelByCar.Add(car, fuel);
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Stop")
                {
                    break;
                }

                string[] tokens = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string car = tokens[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (!(fuelByCar[car] - fuel > 0))
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        mileageByCar[car] += distance;
                        fuelByCar[car] -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (mileageByCar[car] >= 100000)
                        {
                            mileageByCar.Remove(car);
                            fuelByCar.Remove(car);

                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                    
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);

                    if (fuelByCar[car] + fuel > 75)
                    {
                        fuel = 75 - fuelByCar[car];

                        fuelByCar[car] = 75;
                    }
                    else
                    {
                        fuelByCar[car] += fuel;
                    }
                    
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(tokens[2]);

                    if (mileageByCar[car] - kilometers < 10000)
                    {
                        mileageByCar[car] = 10000;
                    }
                    else
                    {
                        mileageByCar[car] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
                
            }

            Dictionary<string, int> result = mileageByCar
                .OrderByDescending(m => m.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value} kms, Fuel in the tank: {fuelByCar[kvp.Key]} lt.");
            }
        }
    }
}