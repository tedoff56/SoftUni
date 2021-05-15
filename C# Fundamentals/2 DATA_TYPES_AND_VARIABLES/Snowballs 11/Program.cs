using System;
using System.Numerics;

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
            BigInteger highestSnowballValue = int.MinValue;

            for (int i = 0; i < totalSnowballsN; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue =  BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                
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