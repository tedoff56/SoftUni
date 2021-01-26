using System;

namespace Poke_Mon_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());
            int totalTargets = 0;
            int originalN = pokePowerN;
            
            while (!(pokePowerN < distanceM))
            {

                pokePowerN -= distanceM;
                totalTargets++;

                if (pokePowerN == originalN * 0.5 && exhaustionFactorY != 0)
                {
                    pokePowerN /= exhaustionFactorY;
                }
            }

            Console.WriteLine($"{pokePowerN}\n{totalTargets}");
        }
    }
}