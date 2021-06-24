using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class StartUp
    {
        static void Main()
        {

            int totalWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> wave = new Stack<int>();

            int counter = 0;
            
            for (int i = 0; i < totalWaves; i++)
            {
                
                wave = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
                
                if ((i + 1) % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }
                
                while (plates.Count > 0 && wave.Count > 0)
                {
                    int warrior = wave.Peek();
                    int plate = plates.Peek();

                    if (warrior > plate)
                    {
                        wave.Push(wave.Pop() - plates.Dequeue());
                    }
                    else if (warrior < plate)
                    {
                        int plateTemp = plates.Dequeue() - wave.Pop();
                    
                        List<int> platesTemp = new List<int>(plates);
                        platesTemp.Insert(0, plateTemp);
                    
                        plates = new Queue<int>(platesTemp);
                    }
                    else
                    {
                        wave.Pop();
                        plates.Dequeue();
                    }
                }

                counter++;

                if (plates.Count == 0)
                {
                    Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");
                    return;
                }
            }
            
            if (plates.Count > 0)
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}