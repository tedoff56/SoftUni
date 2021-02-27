using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int totalWorkers = int.Parse(Console.ReadLine());

            int competingFactoryBiscuits = int.Parse(Console.ReadLine());

            int biscuitsPerDay = biscuitsPerWorker * totalWorkers;
            double biscuitsPerMonth = 0;

            for (int i = 1; i <= 30; i++)
            {
                if(i % 3 == 0)
                {
                    biscuitsPerMonth += Math.Round(biscuitsPerDay * 0.75, MidpointRounding.ToNegativeInfinity);
                }
                else
                {
                    biscuitsPerMonth += biscuitsPerDay;
                }
            }

            double difference = Math.Abs(competingFactoryBiscuits - biscuitsPerMonth);
            double formula = difference / competingFactoryBiscuits * 100;
            
            Console.WriteLine($"You have produced {biscuitsPerMonth} biscuits for the past month.");
            if (biscuitsPerMonth > competingFactoryBiscuits)
            {
                Console.WriteLine($"You produce {formula:F2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {formula:F2} percent less biscuits.");
            }
        }
    }
}