using System;
using System.Collections.Generic;

namespace _10Crossroads
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();

            var totalCarsPassed = 0;

            while (true)
            {
                var greenLight = greenLightDuration;
                var freeWindow = freeWindowDuration;

                var command = Console.ReadLine();

                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");

                    return;
                }

                if (command == "green")
                {
                    while (greenLight > 0 && carsQueue.Count > 0)
                    {
                        var firstCar = carsQueue.Dequeue();

                        greenLight -= firstCar.Length;

                        if (greenLight > 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            freeWindow += greenLight;

                            if (freeWindow < 0)
                            {
                                var characterHit = firstCar[freeWindow + firstCar.Length];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstCar} was hit at {characterHit}.");
                                return;
                            }

                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }
        }
    }
}