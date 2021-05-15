using System;
using System.Collections.Generic;
using System.Linq;

namespace Shoot_for_the_Win_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetsHealth = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int count = 0;
            while (true)
            {

                string line = Console.ReadLine();
                if (line == "End")
                {
                    Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", targetsHealth)}");
                    break;
                }

                int target = int.Parse(line);

                if (target < targetsHealth.Count && targetsHealth[target] != -1)
                {
                    int currentTargetHealth = targetsHealth[target];
                    targetsHealth[target] = -1;
                    count++;

                    for (int i = 0; i < targetsHealth.Count; i++)
                    {
                        if (targetsHealth[i] != -1)
                        {
                            if (targetsHealth[i] > currentTargetHealth)
                            {
                                targetsHealth[i] -= currentTargetHealth;
                            }
                            else
                            {
                                targetsHealth[i] += currentTargetHealth;
                            }
                        }
                    }
                }
                
            }
        }
    }
}