using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            
            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                pumps.Enqueue(data);
            }

            bool hasPetrol = true;
            
            for (int i = 0; i < n; i++)
            {
                int currentPetrol = 0;

                for (int j = 0; j < n; j++)
                {
                    int[] pump = pumps.Dequeue();
                    pumps.Enqueue(pump);
                    
                    currentPetrol += pump[0];
                    currentPetrol -= pump[1];

                    if (currentPetrol < 0)
                    {
                        hasPetrol = false;
                    }
                }

                pumps.Enqueue(pumps.Peek());
                pumps.Dequeue();

                if (hasPetrol == true)
                {
                    Console.WriteLine(i);
                    break;
                }

                hasPetrol = true;
            }
        }
    }
}