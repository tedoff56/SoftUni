using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class StartUp
    {
        private static void Main()
        {
            List<ICheckable> visitors = new List<ICheckable>();
            
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split();

                if (tokens.Length == 3)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    visitors.Add(citizen);
                }
                else if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    visitors.Add(robot);
                }

                line = Console.ReadLine();
            }

            string invalidLastDigits = Console.ReadLine();

            foreach (var visitor in visitors
                .Where(v => v.Id.Substring(v.Id.Length - invalidLastDigits.Length) == invalidLastDigits))
            {
                Console.WriteLine(visitor.Id);
            }
        }
    }
}