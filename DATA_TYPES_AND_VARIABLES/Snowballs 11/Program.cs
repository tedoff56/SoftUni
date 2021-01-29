using System;

namespace Snowballs_11
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int totalSnowballsN = int.Parse(Console.ReadLine());
            
            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            int highestSnowballQuality = 0;
            double highestSnowballValue = int.MinValue;

            for (int i = 0; i < totalSnowballsN; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                double snowballValue = Math.Pow((double)snowballSnow / snowballTime, snowballQuality);
                
                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballSnow = snowballSnow;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuality= snowballQuality;
                    highestSnowballValue = snowballValue;
                }
            }
            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");
            
        }
    }
}