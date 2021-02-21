using System;

namespace Counter_Strike_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int battlesWon = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End of battle")
                {
                    Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
                    break;
                }

                int distance = int.Parse(line);

                if (energy < distance) //energy - distance < 0
                {
                    Console.WriteLine(
                        $"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    break;
                }

                energy -= distance;
                battlesWon++;
                if (battlesWon % 3 == 0)
                {
                    energy += battlesWon;
                }
            }
        }
    }
}